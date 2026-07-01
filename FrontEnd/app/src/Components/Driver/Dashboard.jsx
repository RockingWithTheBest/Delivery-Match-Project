import { act, useEffect, useState } from 'react';
import './Dashboard.css';
import { useParams } from 'react-router-dom';
import { format } from 'date-fns';
import axios from 'axios';

const Dashboard = () => {
    const [isActive, setIsActive] = useState(false); // Default: inactive
    const {DriverId} = useParams()
    const [vehicle, setVehicle]=useState(null)
    const [selectedFile, setSelectedFile] = useState(null);
    const [driverRecord, setDriverRecord] = useState('')
    const url = "https://localhost:7216/api"
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
    const [openModal, setOpenModal] = useState(false)

    const [brand, setBrand] = useState("")
    const [model, setModel] = useState("")
    const [makeYear, setMakeYear] = useState("")
    const [maxWeight, setMaxWieght] = useState("")
    const [length, setLength] = useState("")
    const [color, setColor] = useState("")
    const [height, setHeight] = useState("")
    const [width, setWidth] = useState("")
    const [licenseePlate, setLicensePlate] = useState("")

    const [description, setDescription] = useState('');
    const [images, setImages] = useState('');
    const [uploading, setUploading] = useState(false);
    const [loading, setLoading] = useState(false);
    const [previewUrl, setPreviewUrl] = useState(null);


    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
    };

    const handleToggle = () => {
        setIsActive(!isActive);
        setAvailableBool(!isActive)
    };

    const handleDriverRecord=async()=>{
        try{
            const driver = await axios.get(`${url}/Driver/get-driver-byUserId`,{
                params:{
                    UserId:parseInt(DriverId)
                }
            }) 

            console.log("HEY", driver)

            const response = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
                params:{
                    Id:parseInt(driver.data.Id)
                }
            })
            console.log("HEY", response.data)
            setDriverRecord(response.data)
        }
        catch (error) {
            console.error('Failed to get driver record:', error);
       
        }
    }
    
    const setOrderStatus = async()=>{
        try{
            const driver = await axios.get(`${url}/Driver/get-driver-byUserId`,{
                params:{
                    UserId:parseInt(DriverId)
                }
            }) 

            const response = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
                params:{
                    Id:parseInt(driver.data.Id)
                }
            })
            setIsActive(response.data.IsAvailable)
        }
        catch(error){
            console.error('Error updating:', error.message);
        }
    }
    
    const setAvailableBool=async(avail_parameter)=>{
        try{
            const response = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
                params:{
                    Id:parseInt(DriverId)
                }
            })

            const driver = {
                DriversLicense:response.data.DriversLicense,
                LicenseExpiry:response.data.LicenseExpiry,
                IsVerified:response.data.IsVerified,
                IsAvailable:avail_parameter,
                Rating:response.data.Rating,
                CompletionRate:response.data.CompletionRate,
                TotalEarnings:response.data.TotalEarnings,
                UserId:response.data.UserId,
            }
            setDriverRecord(driver)
            await axios.put(`${url}/Driver/Editing-Driver`,driver,{
                params:{
                    Id:parseInt(DriverId)
                }
            })
            if(avail_parameter){
                showNotification("Driver changed work status to Active", 'success') 
            }
            else{
                showNotification("Driver changed work status to Inactive", 'success') 
            }
                                  
        }
        catch (error) {
            console.error('Error updating:', error);    
        }
    }

    const fetchImages = async (VehicleId) => {
        setLoading(true);
        try {
            const response = await axios.get(`${url}/Driver/images-list`);
            const imagesArray = response.data.filter(i=>i.Id === parseInt(VehicleId))
            console.log("VehicleId",VehicleId)
            console.log("imagesArray",imagesArray[0])
            setImages(imagesArray[0]);
            
        } catch (error) {
            console.error('Error fetching images:', error);
        } finally {
            setLoading(false);
        }
    };

    const fetchDisplay=async()=>{
        try{
            const driver = await axios.get(`${url}/Driver/get-driver-byUserId`,{
                params:{
                    UserId:parseInt(DriverId)
                }
            }) 

            const responseDriverRecord = await axios.get(`${url}/Driver/Get-Vehicle-By-DriverId`,{
                params:{
                    DriverId:parseInt(driver.data.Id)
                }
            })
            const response = await axios.get(`${url}/Driver/images-list`);
            const imagesArray = response.data.filter(i=>i.Id === parseInt(responseDriverRecord.data.Id))
            setImages(imagesArray[0]);
        }
        catch(e){

        }
    }

    const clearSelection = async () => {
        if (!window.confirm('Are you sure you want to delete this image?')) {
            return;
        }

        try {
            setSelectedFile(null);
            setDescription('');
            const vehicleRecord = await axios.get(`${url}/Driver/Get-Vehicle-By-DriverId`,{
                params:{
                    DriverId:parseInt(DriverId)
                }
            })
            
            const response = await axios.put(`${url}/Driver/deleteImage`,null,{
                params:{
                    vehicleId:vehicleRecord.data.Id
                }
            }) 

            console.log("vehicleRecord",response.data)
            
            if (response.data) {
                fetchImages(vehicleRecord.data.Id);
            } else {
                showNotification('Failed to delete image', 'error');
            }
        } catch (error) {
            console.error('Error deleting image:', error);
            showNotification('Error deleting image', 'error');
        }
    };

    const handleFileChange = (event) => {
        console.log("")

        const file = event.target.files[0];
        if (file) {
            setSelectedFile(file);
        }
    };

    const handleUpload = async () => {
        if (!selectedFile) {
            alert('Please select a file first.');
            return;
        }

        if(!description){
            showNotification("Add a description to the image.", "warning")
            setSelectedFile("")
            return;
        }
        
        setUploading(true);
        const formData = new FormData();


        formData.append('image', selectedFile);
        formData.append('description', description);

        try {
            const driver = await axios.get(`{url}/Driver/get-driver-byUserId`,{
                params:{
                    UserId:parseInt(DriverId)
                }
            })            
            
            const vehicle = await axios.get(`${url}/Driver/Get-Vehicle-By-DriverId`,{
                params:{
                    DriverId:parseInt(driver.data.Id)
                }
            })
            console.log("vehicle",vehicle.data)
            const response = await axios.put(`${url}/Driver/Upload`,formData,{
                params:{
                    VehicleId:parseInt(vehicle.data.Id)
                }
            });

            console.log("response", vehicle.data.Id)
            // Reset form
            setSelectedFile(null);
            setDescription('');
            
            // Refresh the image list
            fetchImages(vehicle.data.Id);
            
        } catch (error) {
            console.error('Error uploading file:', error);
            alert(`Upload failed: ${error.message}`);
        } finally {
            setUploading(false);
        }
    };

    const handleDescriptionChange = (event) => {
        setDescription(event.target.value);
    };

    const postVehicleData=async()=>{
        // Basic Validation
        if(!brand || !model || !licenseePlate) {
            showNotification("Please fill in required fields", "warning");
            return;
        }
        try{

            const vehicle = {
                Brand:brand,
                Model:model,
                MakeYear:format(makeYear, 'yyyy-MM-dd'),
                Color:color,
                LicensePlate:licenseePlate,
                MaxWeight:parseFloat(maxWeight),
                Length:parseFloat(length),
                Width:parseFloat(width),
                Height:parseFloat(height),
                DriverId: parseInt(DriverId)
            }
            
            console.log("Vehcile data", vehicle)
            await axios.post(`${url}/Driver/Add-Vehcile`,vehicle)
            setOpenModal(false)
            showNotification("Successfully added vehicle data", "success")

            // Refresh vehicle list
            fetchVehicle(); 

            // Clear form
            setBrand(""); setModel(""); setMakeYear(""); setColor("");
            setLicensePlate(""); setMaxWieght(""); setLength(""); setWidth(""); setHeight("");
        }
        catch(error){
            console.log("ERROR",error)
            showNotification("Errors in processing the vehicle data you provided", "error")
        }
        
    }
    
    const fetchVehicle = async()=>{
        
        try{
            const driver = await axios.get(`${url}/Driver/get-driver-byUserId`,{
                params:{
                    UserId:parseInt(DriverId)
                }
            })

            const response = await axios.get(`${url}/Driver/Get-Vehicle-By-DriverId`,
                {
                    params:{
                        DriverId:parseInt(driver.data.Id)
                    }
            })
            setVehicle(response.data)
        }
        catch(e){
            console.log("ERROR", e)
            showNotification("Vehicle details not yet added", 'error') 
        }
        finally {
            setLoading(false);
        }
    }

    useEffect(()=>{
        fetchVehicle()
        handleDriverRecord()
        setOrderStatus()
        fetchDisplay()
        
    },[DriverId])

    useEffect(() => {    
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);   


    // Create preview when file is selected
    useEffect(() => {
        if (!selectedFile) {
            setPreviewUrl(null);

            return;
        }

        const objectUrl = URL.createObjectURL(selectedFile);
        setPreviewUrl(objectUrl);

        // Clean up the object URL
        return () => URL.revokeObjectURL(objectUrl);
    }, [selectedFile]);

    return (
        <div className='dashboard-component'>
            <div className="dashboard-status">
                
                <div className="toggle-container-dash">
                        <h2>Driver Status</h2>
                        <label className="toggle-label">
                            <input 
                                type="checkbox" 
                                checked={isActive}
                                onChange={handleToggle}
                                className="toggle-input"
                            />
                            <span className="toggle-slider">
                                <span className="toggle-knob"></span>
                            </span>
                        </label>
                </div>
            <div className="status-container">
                <div className="status-info">
                    <span className={`status-text ${isActive ? 'active' : 'inactive'}`}>
                        {isActive ? 'Available' : 'Unavailable'}
                    </span>
                    <p className="status-description">
                        {isActive 
                            ? 'You are available to receive new orders' 
                            : 'You are not available for new orders'
                        }
                    </p>
                </div>
                
                
                <div className="driver-rating">
                    {driverRecord ?(
                        <p><i className="icon-star">⭐</i>{driverRecord.Rating} Rating</p>
                    ):
                        <p>The driver does have a rating</p>}
                </div>
                 <div className="driver-license">
                    {driverRecord?(
                        <p><i className="icon-license">🪪</i> License Id - {driverRecord.DriversLicense}</p>
                    ):
                        <p>The driver does have a License</p>}                    
                </div>
            </div>
            </div>

            <div className="active-vehicles">
                <h3>Vehicle Information</h3>
                {loading?(
                    <p>Loading vehicle details...</p>
                ): vehicle ? (
                    <div className="vehicle-card">
                        <div className="vehicle-image-section">
                            <div className="vehicle-image-container">
                                {images && images.ImageBase64 ? (
                                    <div  className="previewContainerStyle">
                                        <img 
                                            src={`data:${images.ContentType};base64,${images.ImageBase64}`} 
                                            alt={`${images.FileName}`}
                                            className="vehicle-image"
                                        />
                                        <button 
                                            onClick={clearSelection}
                                            className="clear-button"
                                        >
                                            Clear
                                        </button>
                                    </div>

                                ) : (
                                    previewUrl?(
                                        <div className="previewContainerStyle">
                                             <img 
                                                src={previewUrl} 
                                                alt="Preview"
                                                className="vehicle-image"
                                            />
                                            <button 
                                                onClick={() => {
                                                    setSelectedFile(null);
                                                    setPreviewUrl(null);
                                                }}
                                                className="clear-button"
                                            >
                                                Remove
                                            </button>
                                        </div>
                                ):(
                                    <div className="vehicle-placeholder">
                                        🚗
                                    </div>
                                )
                            )}
                            </div>
                            
                            {/* Upload Form */}
                            <div>
                                <div className="previewSectionStyle">
                                    <div style={uploadControlsStyle}>
                                        <input 
                                            type="file" 
                                            accept="image/*" 
                                            onChange={handleFileChange} 
                                            disabled={uploading}
                                            className='fileInputStyle'
                                            id="file-input"
                                        />
                                        <label htmlFor="file-input" className='fileInputLabelStyle'>
                                            Choose Image
                                        </label>
                                        
                                        <input
                                            type="text"
                                            placeholder="Enter description (optional)"
                                            value={description}
                                            onChange={handleDescriptionChange}
                                            disabled={uploading}
                                            className='inputStyle'
                                        />
                                        
                                        <button 
                                            onClick={handleUpload} 
                                            disabled={!selectedFile || uploading}
                                            style={uploadButtonStyle(uploading || !selectedFile)}
                                        >
                                            {uploading ? '⏳ Uploading...' : '📤 Upload to Database'}
                                        </button>
                                    </div>
                                </div>
                            </div> 
                        </div>

                    
                        <div className="vehicle-details">
                            <h4>{vehicle.Brand} {vehicle.Model}</h4>
                            <div className="vehicle-info-grid">
                                <div className="info-item">
                                    <span className="label">License Plate:</span>
                                    <span className="value">{vehicle.LicensePlate}</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Brand:</span>
                                    <span className="value">{vehicle.Brand}</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Color:</span>
                                    <span className="value">{vehicle.Color}</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Max Weight:</span>
                                    <span className="value">{vehicle.MaxWeight} kg</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Max Volume:</span>
                                    <span className="value">{(vehicle.Height * vehicle.Length * vehicle.Width)/1000000} m³</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Year:</span>
                                    <span className="value">{new Date(vehicle.MakeYear).getFullYear()}</span>
                                </div>
                            </div>
                        </div>
                    </div>                        
                    ):(
                        <div className="no-vehicle">
                            <p>No vehicle assigned to this driver</p>
                            <button className="assign-vehicle-btn" onClick={()=>setOpenModal(true)}>
                                Request Vehicle Assignment
                            </button>
                        </div>
                    )}
                    
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

            {/* Modal Section */}
            {openModal &&
                <div className="vehicle-adder-overlay" onClick={()=>setOpenModal(false)}>
                    <div className="vehicle-adder" onClick={(e)=>e.stopPropagation()}>
                        <div className="modal-header">
                            <h3 className=''>Add Vehicle Details</h3>
                            <button className="close-modal-btn" onClick={() => setOpenModal(false)}>&times;</button>
                        </div>
                        <form action="" className="vehicle-form-add" onSubmit={(e)=>{e.preventDefault(); postVehicleData(); }}>
                            <div className="form-grid">
                                <div className="input-group-info-vehicle">
                                <label htmlFor="">Brand</label>
                                    <input 
                                        type="text"
                                        value={brand}
                                        onChange={(e)=>setBrand(e.target.value)}
                                    />
                                </div>
                                
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Model</label>
                                    <input 
                                        type="text"
                                        value={model}
                                        onChange={(e)=>setModel(e.target.value)}
                                    />
                                </div>
                                
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Make Year</label>
                                    <input 
                                        type="text"
                                        value={makeYear}
                                        onChange={(e)=>setMakeYear(e.target.value)}
                                    />
                                </div>  
                                
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Color</label>
                                    <input 
                                        type="text"
                                        value={color}
                                        onChange={(e)=>setColor(e.target.value)}
                                    />
                                </div>
                                
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">License Plate</label>
                                    <input 
                                        type="text"
                                        value={licenseePlate}
                                        onChange={(e)=>setLicensePlate(e.target.value)}
                                    />
                                </div>

                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Max Weight</label>
                                    <input 
                                        type="text"
                                        value={maxWeight}
                                        onChange={(e)=>setMaxWieght(e.target.value)} 
                                    />
                                </div>
                                
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Length</label>
                                    <input 
                                        type="text"
                                        value={length}
                                        onChange={(e)=>setLength(e.target.value)} 
                                    />
                                </div>
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Height</label>
                                    <input 
                                        type="text"
                                        value={height}
                                        onChange={(e)=>setHeight(e.target.value)} 
                                    />
                                </div>     
                                <div className="input-group-info-vehicle">
                                    <label htmlFor="">Width</label>
                                    <input 
                                        type="text"
                                        value={width}
                                        onChange={(e)=>setWidth(e.target.value)} 
                                    />
                                </div>   
                            </div>
                            
                            <div className="modal-actions">
                                <button type="button" className="cancel-btn" onClick={() => setOpenModal(false)}>Cancel</button>
                                <button type="submit" className="submit-btn">Save Vehicle</button>
                            </div>                                       
                        </form>
                    </div>

                </div>
            }
        </div>

        );
};

const uploadButtonStyle = (disabled) => ({
    padding: '10px',
    backgroundColor: disabled ? '#6c757d' : '#007bff',
    color: 'white',
    border: 'none',
    borderRadius: '5px',
    cursor: disabled ? 'not-allowed' : 'pointer',
    fontSize: '16px',
    fontWeight: '500',
    transition: 'background-color 0.3s',
    ':hover': {
        backgroundColor: disabled ? '#6c757d' : '#0056b3'
    }
});

const uploadControlsStyle = {
    flex: 1,
    display: 'flex',
    flexDirection: 'column',
    gap: '10px',
    minWidth: '300px'
};


export default Dashboard;