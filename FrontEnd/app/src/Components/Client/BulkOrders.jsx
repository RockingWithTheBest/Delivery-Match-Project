import DocumentUploadIcon from "../Icons/document-upload-svgrepo-com.svg"
import UploadIcon from "../Icons/upload-minimalistic-svgrepo-com.svg"
import DownFacingUploadIcon from "../Icons/upload-svgrepo-com.svg"
import ExcelUploadIcon from "../Icons/upload-excel-svgrepo-com.svg"
import * as XLSX from 'xlsx';
import { useState, useEffect } from "react";
import { saveAs } from 'file-saver';
import './BulkOrders.css'
import axios from "axios";
import { format } from "date-fns";
import { useParams } from "react-router-dom";
import CoordinatesVideo from './CoordinatesMedia/actual.mp4'

const BulkOrders =()=>{
    //url api
    const url = "https://localhost:7216/api/"
    const {ClientId} = useParams()

    //state variables
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });

    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
    };
    
    const downloadTemplate = () => {
        // Create worksheet data with headers
        const worksheetData = [
            {
                'Pick_Up_Address': 'Kremlin, Moscow',
                'Pick_Up_Location_Coordinates_latitude_longitude':'55.75100000000001,37.61760000000001',
                'Delivery_Up_Address': 'Samson Fountain, Saint Petersburg', 
                'Delivery_Location_Coordinates_latitude_longitude':'59.88520000000001,29.90910000000001',
                'Status':'Confirmed',
                'Notes':'Awaiting pickup',
                'Pick_Up_Contact': '+1234567890',
                'Delivery_Contact': '+0987654321',
                'Description': 'Office documents',
                'Price': '25.00',
                'Scheduled_At': '2024-01-16 14:30:00',
                'Weight_Per_Item' : '60.00m',
                'Item_Name':'CASIO Print',
                'Quantity':'1',
                'Special_Instructions':'Fragile Items',
                'DimensionLength':'100cm',
                'DimensionHeight':'50cm',
                'DimensionWidth':'20cm'
            },
            {
                'Pick_Up_Address': 'Temple of all Religions, Kazan',
                'Pick_Up_Location_Coordinates_latitude_longitude':'55.80060000000001,48.97470000000001',
                'Delivery_Up_Address': 'Ice Palace, Moscow', 
                'Delivery_Location_Coordinates_latitude_longitude':'55.76670000000001,37.43520000000001',
                'Status':'Confirmed',
                'Notes':'Awaiting pickup',
                'Pick_Up_Contact': '+1122334455', 
                'Delivery_Contact': '+5566778899',
                'Description': 'Electronics equipment',
                'Price': '345.50',
                'Scheduled_At': '2024-01-17 09:00:00',
                'Weight_Per_Item' : '60.00m',
                'Item_Name':'Iphone',
                'Quantity':'2',
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
        const currentDateTime = new Date();
        const formattedDateTime = format(currentDateTime, 'yyyy-MM-dd HH:mm:ss')
        
        // Validate and process each row
        const validatedOrders = data.map((row, index) => {
            // Add validation logic here
            return {
                PickUpAddress: row.Pick_Up_Address || '',
                DeliveryUpAddress: row.Delivery_Up_Address || '',
                PickUpContact: row.Pick_Up_Contact || '',
                DeliveryContact: row.Delivery_Contact || '',
                Description: row.Description || '',
                Status: row.Status || 'Confirmed',
                Price: parseFloat(row.Price) || 0,
                CreatedAt: `${formattedDateTime}.0000000`,
                ScheduledAt: new Date(row.Scheduled_At) || new Date().toISOString(),
                CompletedOn:  null,
                CustomerId: parseInt(ClientId) || 1,
                OrderItems:{
                    ItemName:row.Item_Name || '',
                    Quantity:parseInt(row.Quantity) || 1,
                    SpecialInstructions:row.Special_Instructions || '',
                    WeightPerItem : parseFloat(row.Weight_Per_Item) || '',
                    orderDimension:{
                        Length:parseFloat(row.DimensionLength),
                        Height:parseFloat(row.DimensionHeight),
                        Width:parseFloat(row.DimensionWidth)
                    }
                },
                OrderTrackings:{
                    PickUpLocation: row.Pick_Up_Location_Coordinates_latitude_longitude || "",
                    DeliveryLocation:row.Delivery_Location_Coordinates_latitude_longitude || "",
                    Status: row.Status || 'Confirmed',
                    Notes:row.Notes,
                    TimeStamps: `${formattedDateTime}.0000000`
                }
            };
        });

        if(ClientId){
            try{
                console.log("validatedOrders",validatedOrders)
                await axios.post(`${url}OrderPlacement/Add-Bulk-OrderPlacement`,validatedOrders,{
                    params:{
                        ClientId:parseInt(ClientId)
                    }
                })
                
                showNotification("Successfully added bulk orders.", 'success')              
            }
            catch(e){
                console.log("ERROR",e)
                showNotification("Error occured while adding bulk orders.", 'error')              
            }
            
        }
        else{
            alert("You are not correctly logged in.")
        }
        console.log('Processed orders:', validatedOrders);
    };

    useEffect(() => {
        
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);   
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
            <div className="bulk-part-6 dotted-border">
                <p>Watch the video below to collect coordinates</p>
                <video  controls  width="100%" style={{'display':'none'}}>
                    <source src="/videos/coordinates.mp4" type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
                <video className="video-info" controls>
                    <source src={CoordinatesVideo} type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
                <button 
                    className="link-to-coordinates-video" 
                    onClick={()=>window.open("https://www.gps-coordinates.net/", '_blank')}>
                    Click to link to get coordinates
                </button>
            </div>

            
            <div className="bulk-part-4">
                <h3>Some simple guidelines:</h3>
                {/* <div>
                    <h4>Required Columns:</h4>
                    <ul>
                        <li>Pickup Address</li>
                        <li>Delivery Address</li>
                        <li>Weight (kg)</li>
                        <li>Volume (m³)</li>
                        <li>Category</li>
                        <li>Urgency (standard/urgent)</li>
                    </ul>
                </div> */}
                <div>
                    <h4>Choices of Special Instructions for items: </h4>
                    <ul>
                        <li>Fragile Items</li>
                        <li>Refrigirated transport</li>
                        <li>Oversized items</li>
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

            {/* Notification */}
            <div className={`notificationNew ${notification.show ? 'show' : ''}`} id="notification">
                    <div className="d-flex justify-content-between align-items-start mb-2">
                    <h6 className="mb-0" style={{ color: 
                      notification.type === 'error' ? '#dc3545' : 
                      notification.type === 'success' ? '#28a745' : 
                      notification.type === 'warning' ? '#ffc107' : '#4a6fdc'
                    }}>
                        {notification.type === 'error' ? 'Error' : 
                        notification.type === 'success' ? 'Success' : 
                        notification.type === 'warning' ? 'Warning' : 'Information'}
                    </h6>
                    <button className="btn-close btn-sm" onClick={() => setNotification({ ...notification, show: false })}></button>
                    </div>
                    <div className="notification-body">
                       {notification.message}
                    </div>
            </div> 
        </div>
        
    )
}
export default BulkOrders;