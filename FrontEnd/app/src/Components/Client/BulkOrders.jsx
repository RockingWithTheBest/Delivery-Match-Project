import DocumentUploadIcon from "../Icons/document-upload-svgrepo-com.svg"
import UploadIcon from "../Icons/upload-minimalistic-svgrepo-com.svg"
import DownFacingUploadIcon from "../Icons/upload-svgrepo-com.svg"
import ExcelUploadIcon from "../Icons/upload-excel-svgrepo-com.svg"
import * as XLSX from 'xlsx';
import { saveAs } from 'file-saver';
import './BulkOrders.css'
import axios from "axios";
import { useParams } from "react-router-dom";

const BulkOrders =()=>{
    const url = "https://localhost:7216/api/"
    const {ClientId} = useParams()

     const downloadTemplate = () => {
        // Create worksheet data with headers
        const worksheetData = [
            {
                'Pick_Up_Address': '123 Main St, City',
                'Delivery_Up_Address': '456 Oak Ave, City', 
                'Pick_Up_Contact': '+1234567890',
                'Delivery_Contact': '+0987654321',
                'Description': 'Office documents',
                'Status': 'Pending',
                'Price': '25.00',
                'Created_At': '2024-01-15 10:00:00',
                'Scheduled_At': '2024-01-16 14:30:00',
                'Completed_On': '',
                'CustomerId': '1',
                'Item_Name':'CASIO Print',
                'Quantity':'1',
                'Weight_Per_Item':'15.50',
                'Special_Instructions':'Fragile Items',
                'DimensionLength':'100cm',
                'DimensionHeight':'50cm',
                'DimensionWidth':'20cm'
            },
            {
                'Pick_Up_Address': '789 Pine Rd, City',
                'Delivery_Up_Address': '321 Elm St, City',
                'Pick_Up_Contact': '+1122334455', 
                'Delivery_Contact': '+5566778899',
                'Description': 'Electronics equipment',
                'Status': 'Pending',
                'Price': '345.50',
                'Created_At': '2024-01-15 11:30:00',
                'Scheduled_At': '2024-01-17 09:00:00',
                'Completed_On': '',
                'CustomerId': '1',
                'Item_Name':'Iphone',
                'Quantity':'2',
                'Weight_Per_Item':'5.50',
                'Special_Instructions':'Fragile Items',
                'DimensionLength':'15cm',
                'DimensionHeight':'2cm',
                'DimensionWidth':'5cm'
            }
        ];

        // Create workbook and worksheet
        const workbook = XLSX.utils.book_new();
        const worksheet = XLSX.utils.json_to_sheet(worksheetData);

         // Add worksheet to workbook
        XLSX.utils.book_append_sheet(workbook, worksheet, 'Orders Template');
        
        // Generate Excel file and download
        const excelBuffer = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
        const data = new Blob([excelBuffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        
        saveAs(data, 'OrderPlacement_Template.xlsx');
    };

    const handleFileUpload = (event) => {
        const file = event.target.files[0];
        if (!file) return;

        // Validate file type
        const validTypes = ['application/vnd.ms-excel', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'];
        if (!validTypes.includes(file.type)) {
            alert('Please upload a valid Excel file (.xlsx or .xls)');
            return;
        }

        // Validate file size (10MB)
        if (file.size > 10 * 1024 * 1024) {
            alert('File size must be less than 10MB');
            return;
        }

        const reader = new FileReader();
        
        reader.onload = (e) => {
            try {
                const data = new Uint8Array(e.target.result);
                const workbook = XLSX.read(data, { type: 'array' });
                
                // Get first worksheet
                const worksheetName = workbook.SheetNames[0];
                const worksheet = workbook.Sheets[worksheetName];
                
                // Convert to JSON
                const jsonData = XLSX.utils.sheet_to_json(worksheet);
                
                console.log('Uploaded data:', jsonData);
                processUploadedData(jsonData);
                
            } catch (error) {
                console.error('Error reading file:', error);
                alert('Error reading the Excel file. Please check the format.');
            }
        };
         reader.readAsArrayBuffer(file);
    };

    const processUploadedData = async (data) => {
        // Validate and process each row
        const validatedOrders = data.map((row, index) => {
            // Add validation logic here
            return {
                Pick_Up_Address: row.Pick_Up_Address || '',
                Delivery_Up_Address: row.Delivery_Up_Address || '',
                Pick_Up_Contact: row.Pick_Up_Contact || '',
                Delivery_Contact: row.Delivery_Contact || '',
                Description: row.Description || '',
                Status: row.Status || 'Pending',
                Price: parseFloat(row.Price) || 0,
                Created_At: new Date(row.Created_At) || new Date(),
                Scheduled_At: new Date(row.Scheduled_At) || new Date(),
                Completed_On: row.Completed_On ? new Date(row.Completed_On) : null,
                CustomerId: parseInt(row.CustomerId) || 1,
                Order_Items:{
                    Item_Name:row.Item_Name || '',
                    Quantity:parseInt(row.Quantity) || 1,
                    Weight_Per_Item:parseFloat(row.Weight_Per_Item) || '',
                    Special_Instructions:row.Special_Instructions,
                    orderDimension:{
                        Length:parseFloat(row.DimensionLength),
                        Height:parseFloat(row.DimensionHeight),
                        Width:parseFloat(row.DimensionWidth)
                    }
                },
            };
        });

        if(ClientId){
             try{
                await axios.post(`${url}OrderPlacement/Add-Bulk-OrderPlacement`,validatedOrders,{
                    params:{
                        ClientId:parseInt(ClientId)
                    }
                })
            }
            catch(e){
                console.log("ERROR",e)
            }
            alert("Successfully added bulk orders.")
        }
        else{
            alert("You are not correctly logged in.")
        }
        console.log('Processed orders:', validatedOrders);
    };

    return(
        <div className="bulk-order-sections">
            <div className="bulk-part-1">
                <div className="b-o-upload">
                    <img src={DocumentUploadIcon} alt="" className="doc-upload" />
                    <p>Bulk Order Upload</p>
                </div>
                <p className="multiple-orders-upload">Upload multiple orders at once using an Excel file</p>
            </div>
            <div className="bulk-part-2  dotted-border">
                <img src={UploadIcon} alt="" className="upload-icon" />
                <h3>Need a template?</h3>
                <p>Download our Excel template with the required format</p>
                <button className="bulk-upload-btn" onClick={downloadTemplate}>
                    <img src={DownFacingUploadIcon} alt="" className="down-facing-upload-icon" />
                    Download Template
                </button>
            </div>
            <div className="bulk-part-3">
                <img src={ExcelUploadIcon} alt="" className="upload-icon" />
                <h3>Upload your Excel file</h3>
                <p>Support for .xlsx, .xls files up to 10MB</p>
                <div className="file-upload-wrapper">
                    <input 
                        type="file" 
                        id="excel-upload"
                        accept=".xlsx, .xls"
                        onChange={handleFileUpload}
                        style={{ display: 'none' }}
                    />
                    <label htmlFor="excel-upload" className="upload-btn">
                        Choose File
                    </label>
                </div>
                <p className="file-info">No file chosen</p>
            </div>

            <h3>Required Excel Format:</h3>
            <div className="bulk-part-4">
                <div>
                    <h4>Required Columns:</h4>
                    <ul>
                        <li>Pickup Address</li>
                        <li>Delivery Address</li>
                        <li>Weight (kg)</li>
                        <li>Volume (m³)</li>
                        <li>Category</li>
                        <li>Urgency (standard/urgent)</li>
                    </ul>
                </div>
                <div>
                    <h4>Supported Categories:</h4>
                    <ul>
                        <li>Documents</li>
                        <li>Furniture</li>
                        <li>Construction</li>
                        <li>Electronics</li>
                        <li>Food & Beverages</li>
                        <li>Other</li>
                    </ul>
                </div>
            </div>
            <div className="bulk-part-5">
                <h3>Bulk Booking Benefits:</h3>
                <div>
                    <ul>
                        <li>Automatic route optimization</li>
                        <li>Volume discounts available</li>
                        <li>Efficient vehicle utilization</li>
                        <li>Reduced delivery costs</li>
                        <li>Environmental impact reduction</li>
                    </ul>
                </div>
            </div>
        </div>
        
    )
}
export default BulkOrders;