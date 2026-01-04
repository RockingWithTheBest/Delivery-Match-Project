import { useEffect, useState } from 'react';
import './Dashboard.css';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const Dashboard = () => {
    const [isActive, setIsActive] = useState(false); // Default: inactive
    const {DriverId} = useParams()
    const urlGetVehicle = "https://localhost:7216/api/Vehicle/Get-Vehicle-By-DriverId"
    const [vehicle, setVehicle]=useState(null)
    const [loading, setLoading] = useState(true);
    const [uploading, setUploading] = useState(false);
    const [selectedFile, setSelectedFile] = useState(null);
    const [driverRecord, setDriverRecord] = useState('')
    const url = "https://localhost:7216/api"
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
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
            const response = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
                params:{
                    Id:parseInt(DriverId)
                }
            })
            setDriverRecord(response.data)
        }
        catch (error) {
            console.error('Failed to get driver record:', error);
       
        }
    }
    
    const setOrderStatus = async()=>{
        try{
            const response = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
                params:{
                    Id:parseInt(DriverId)
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
            console.error('Error updating:', error.message);    
        }
    }

    const handleFileSelect = (event) => {
        const file = event.target.files[0];
        if (file) {
            // Validate file type
            if (!file.type.startsWith('image/')) {
                alert('Please select an image file');
                return;
            }
            
            // Validate file size (max 5MB)
            if (file.size > 5 * 1024 * 1024) {
                alert('File size must be less than 5MB');
                return;
            }
            
            setSelectedFile(file);
        }
    };

    const handleImageUpload = async () => {
        if (!selectedFile || !vehicle) return;

        try {
            setUploading(true);
            
            // Create FormData to send the file
            const formData = new FormData();
            formData.append('image', selectedFile);
            formData.append('vehicleId', vehicle.Id.toString());

            const response = await axios.post(urlUploadImage, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            });

            // Update vehicle state with new image URL
            setVehicle(prev => ({
                ...prev,
                ImageUrl: response.data.imageUrl
            }));
            
            setSelectedFile(null);
            alert('Image uploaded successfully!');
            
        } catch (error) {
            console.error('Upload failed:', error);
            alert('Failed to upload image');
        } finally {
            setUploading(false);
        }
    };

    const handleRemoveFile = () => {
        setSelectedFile(null);
    };

    const fetchVehicle = async()=>{
        
        try{
            const response = await axios.get(urlGetVehicle,
                {
                    params:{
                        DriverId:parseInt(DriverId)
                    }
            })
            console.log("response", response.data)
            setVehicle(response.data)
        }
        catch(e){
            console.log("ERROR", e.Message)
        }
        finally {
            setLoading(false);
        }
    }
    useEffect(()=>{
        if(DriverId){
            fetchVehicle()
        }
    },[DriverId])

    useEffect(()=>{
        handleDriverRecord()
        setOrderStatus()
    },[DriverId])

    useEffect(() => {    
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);   

    return (
        <div className='dashboard-component'>
            <div className="dashboard-status">
                
                <div className="toggle-container">
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
                                {vehicle.ImageUrl ? (
                                    <img 
                                        src={vehicle.ImageUrl} 
                                        alt={`${vehicle.Brand} ${vehicle.Model}`}
                                        className="vehicle-image"
                                    />
                                ) : (
                                    <div className="vehicle-placeholder">
                                        🚗
                                    </div>
                                )}
                            </div>
                            
                            <div className="upload-section">
                                <div className="upload-controls">
                                    <input
                                        type="file"
                                        id="vehicle-image-upload"
                                        accept="image/*"
                                        onChange={handleFileSelect}
                                        className="file-input"
                                        disabled={uploading}
                                    />
                                    <label htmlFor="vehicle-image-upload" className="upload-btn">
                                        Choose Image
                                    </label>
                                    
                                    {selectedFile && (
                                        <div className="file-info">
                                            <span>{selectedFile.name}</span>
                                            <button 
                                                type="button" 
                                                onClick={handleRemoveFile}
                                                className="remove-btn"
                                            >
                                                ×
                                            </button>
                                        </div>
                                    )}

                                    {selectedFile && (
                                        <button
                                            onClick={handleImageUpload}
                                            disabled={uploading}
                                            className="upload-submit-btn"
                                        >
                                            {uploading ? 'Uploading...' : 'Upload Image'}
                                        </button>
                                    )}

                                </div>
                                <p className="upload-hint">Supported formats: JPG, PNG, GIF. Max size: 5MB</p>
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
                            <button className="assign-vehicle-btn">
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
            </div>
        );
};

export default Dashboard;