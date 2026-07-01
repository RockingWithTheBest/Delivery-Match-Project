import axios from "axios";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import CarIcon from "../Icons/car.svg"
import './PersonalInfo.css'

const Vehicle =({driverDetails})=>{
  const {password}=useParams()
    const {DriverId}=useParams()
    const [disableTrue,setDisableToTrue] = useState(true)
    const [email, setEmail] = useState("")
    const [phone, setPhone] = useState("")
    const [firstName, setFirstName] = useState("")
    const [lastName, setLastName] = useState("")
    const [completionRate, setCompletionRate] = useState("")
    const [rating, setRating] = useState("")
    const [isVerified, setIsVerified] = useState("")
    const [licenseExpiry, setLicenseExpiry] = useState("")
    const [driverLicense, setDriverLicense] = useState("")
    const [totalEarnings, setTotalEarning] = useState("")

    //Notifications
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });

    //VehicleRecords
    const [brand, setBrand] = useState("")
    const [model, setModel] = useState("")
    const [makeYear, setMakeYear] = useState("")
    const [maxWeight, setMaxWieght] = useState("")
    const [maxVolume, setMaxVolume] = useState("")
    const [color, setColor] = useState("")
    const [licensePlate, setLicensePlate] = useState("")
    const [vehicleId, setVehicleId]=useState("")
    const [length, setLength]=useState("")
    const [height, setHeight]=useState("")
    const [width, setWidth]=useState("")
    const [fileName, setFileName]=useState("")
    const [contentType, setContentType]=useState("")
    const [imageData, setImageData]=useState("")
    const [fileSize, setFileSize]=useState("")
    const [uploadedDate, setUploadedDate]=useState("")
    const [description, setDescription]=useState("")                                       

    //btns
    const [btnName, setBtnName] =  useState("Edit Profile")

    const url ="https://localhost:7216/api"

    const handleEditAndDisableVehicleData =async()=>{
        if(disableTrue==true){
            setDisableToTrue(false)
            setBtnName("Save Profile")
        }
        else if(disableTrue == false){
            setDisableToTrue(true)
            setBtnName("Edit Profile")
            putVehicle()
        }
    }
    
    const putVehicle=async()=>{
        try{
            const user = await axios.get(`${url}/Driver/get-driver-byUserId`,{
                params:{
                    UserId:parseInt(DriverId)
                }
            })

            const vehicleInfo ={
                Brand:brand,
                Model:model,
                MakeYear:makeYear,
                Color:color,
                LicensePlate:licensePlate,
                MaxWeight:parseFloat(maxWeight),
                DriverId:parseInt(user.data.Id),
                Length : length,
                Height : height,
                Width : width,
                FileName : fileName,
                ContentType : contentType,
                ImageData : imageData,
                FileSize : fileSize,
                UploadedDate : uploadedDate,
                Description : description,
            }

            console.log("vehicleInfo",vehicleInfo)
            
            await axios.put(`${url}/Driver/Edit-Vehcile`,vehicleInfo,{
                params:{
                    Id:parseInt(vehicleId)
                }
            })            
            showNotification("Successfully edited the  details","success")
        }
        catch(e){
            showNotification("Error editing the details","error")
            console.log("ERROR",e)
        }
    }
    
    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
    };

    const handleReloads=async()=>{
        const user = await axios.get(`${url}/Driver/get-driver-byUserId`,{
            params:{
                UserId:parseInt(DriverId)
            }
        })
        const response = await axios.get(`${url}/Driver/Get-Vehicle-By-DriverId`,{
                params:{
                    DriverId:parseInt(user.data.Id)
                }
            })

            setBrand(response.data.Brand)
            setModel(response.data.Model)
            setMakeYear(response.data.MakeYear)
            setColor(response.data.Color)
            setLicensePlate(response.data.LicensePlate)
            setMaxWieght(response.data.MaxWeight)
            setLength(response.data.Length)
            setWidth(response.data.Width)
            setHeight(response.data.Height)
            setFileName(response.data.FileName)
            setContentType(response.data.ContentType)
            setImageData(response.data.ImageData)
            setFileSize(response.data.FileSize)
            setUploadedDate(response.data.UploadedDate)
            setDescription(response.data.Description)
    }

    useEffect(() => {    
            window.hideNotification = () => setNotification({ ...notification, show: false });
        }, [notification]); 

    useEffect(()=>{
        handleReloads()
    },[DriverId])

    useEffect(()=>{
            if(driverDetails){
                setLicensePlate(driverDetails.LicensePlate || "")
                setEmail(driverDetails.Email || "")
                setPhone(driverDetails.Phone || "")
                setFirstName(driverDetails.FirstName || "")
                setLastName(driverDetails.LastName || "")
                setCompletionRate(driverDetails.CompletionRate || "")
                setRating(driverDetails.Rating || "")
                setIsVerified(driverDetails.IsVerified || "")
                setLicenseExpiry(driverDetails.LicenseExpiry || "")
                setDriverLicense(driverDetails.DrivingLicense || "")
                setTotalEarning(driverDetails.TotalEarnings || "")
                setBrand(driverDetails.Brand || "")
                setModel(driverDetails.Model || "")
                setMakeYear(driverDetails.MakeYear || "")
                setMaxWieght(driverDetails.MaxWeight || "")
                setMaxVolume(driverDetails.MaxVolume || "")
                setColor(driverDetails.Color || "")
                setVehicleId(driverDetails.VehicleId || "")
            }
        },[driverDetails])


    return(
        <div className="vehicle-info-component">
            <div className="vehicle-info-edit">
                <div className="vehicle-edit-info">
                    <div>
                        <img src={CarIcon} alt="" />
                        <p>Vehicle Information</p>
                    </div>                
                    <button onClick={()=>handleEditAndDisableVehicleData()}>{btnName}</button>
                </div>
                <form action="" className="vehicle-form-info">
                    <div className="input-group-info">
                        <label htmlFor="">Brand</label>
                        <input 
                            type="text"
                            value={brand}
                            onChange={(e)=>setBrand(e.target.value)}
                            disabled={disableTrue}
                        />
                    </div>
                    
                    <div className="input-group-info">
                        <label htmlFor="">Model</label>
                        <input 
                            type="text"
                            value={model}
                            onChange={(e)=>setModel(e.target.value)}
                            disabled={disableTrue}
                        />
                    </div>
                    
                    <div className="input-group-info">
                        <label htmlFor="">Make Year</label>
                        <input 
                            type="text"
                            value={makeYear}
                            onChange={(e)=>setMakeYear(e.target.value)}
                            disabled={disableTrue}
                        />
                    </div>  
                    
                    <div className="input-group-info">
                        <label htmlFor="">Color</label>
                        <input 
                            type="text"
                            value={color}
                            onChange={(e)=>setColor(e.target.value)}
                            disabled={disableTrue}
                        />
                    </div>
                    
                    <div className="input-group-info">
                        <label htmlFor="">Max Weight</label>
                        <input 
                            type="text"
                            value={maxWeight}
                            onChange={(e)=>setMaxWieght(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div>
                    
                    <div className="input-group-info">
                        <label htmlFor="">Length</label>
                        <input 
                            type="text"
                            value={length}
                            onChange={(e)=>setLength(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div>  

                    <div className="input-group-info">
                        <label htmlFor="">Height</label>
                        <input 
                            type="text"
                            value={height}
                            onChange={(e)=>setHeight(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div> 

                    <div className="input-group-info">
                        <label htmlFor="">Width</label>
                        <input 
                            type="text"
                            value={width}
                            onChange={(e)=>setWidth(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div> 

                    <div className="input-group-info">
                        <label htmlFor="">Description</label>
                        <input 
                            type="text"
                            value={description}
                            onChange={(e)=>setDescription(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div>  
                </form>
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
export default Vehicle