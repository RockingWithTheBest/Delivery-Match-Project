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

    const handleToggle = () => {
        setIsActive(!isActive);
        // Here you can also make an API call to update the driver status in your backend
        console.log(`Driver status changed to: ${!isActive ? 'Active' : 'Inactive'}`);
    };

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
            setVehicle(response.data)
            console.log("EEE", response.data)

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

    return (
        <div>
            <div className="dashboard-status">
            <h2>Driver Status</h2>
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
                
                <div className="toggle-container">
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
                                    <span className="value">{vehicle.License_Plate}</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Color:</span>
                                    <span className="value">{vehicle.Color}</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Max Weight:</span>
                                    <span className="value">{vehicle.Max_Weight} kg</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Max Volume:</span>
                                    <span className="value">{vehicle.Max_Volume} m³</span>
                                </div>
                                <div className="info-item">
                                    <span className="label">Year:</span>
                                    <span className="value">{new Date(vehicle.Make_Year).getFullYear()}</span>
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
            </div>
        );
};

export default Dashboard;