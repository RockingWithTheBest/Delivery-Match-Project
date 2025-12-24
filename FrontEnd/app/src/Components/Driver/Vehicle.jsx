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
    const [brand, setBrand] = useState("")
    const [model, setModel] = useState("")
    const [makeYear, setMakeYear] = useState("")
    const [maxWeight, setMaxWieght] = useState("")
    const [maxVolume, setMaxVolume] = useState("")
    const [color, setColor] = useState("")
    const [licensePlate, setLicensePlate] = useState("")
    const [vehicleId, setVehicleId]=useState("")
    const [btnName, setBtnName] =  useState("Edit Profile")

    const url ="https://localhost:7216/api"

    const handleEditAndDisableVehicleData =async()=>{
        if(disableTrue==true){
            setDisableToTrue(false)
            setBtnName("Save Profile")
            //putVehicle()
            
        }
        else if(disableTrue == false){
            setDisableToTrue(true)
            setBtnName("Edit Profile")
            putVehicle()
        }
        // console.log("VEH",driverDetails)
    }
    
    const putVehicle=async()=>{
        try{
            const vehicleInfo ={
                Brand:brand,
                Model:model,
                MakeYear:makeYear,
                Color:color,
                LicensePlate:licensePlate,
                MaxWeight:parseFloat(maxWeight),
                MaxVolume:parseFloat(maxVolume),
                DriverId:parseInt(DriverId)
            }
            
            await axios.put(`${url}/Vehicle/Edit-Vehcile`,vehicleInfo,{
                params:{
                    Id:parseInt(vehicleId)
                }
            })            
            //console.log("Update successful",vehicleInfo )
        }
        catch(e){
            console.log("ERROR",e)
        }
    }
    
    const handleReloads=async()=>{
        const response = await axios.get(`${url}/Vehicle/Get-Vehicle-By-DriverId`,{
                params:{
                    DriverId:parseInt(DriverId)
                }
            })
            
            setBrand(response.data.Brand)
            setModel(response.data.Model)
            setMakeYear(response.data.MakeYear)
            setColor(response.data.Color)
            setLicensePlate(response.data.LicensePlate)
            setMaxVolume(response.data.MaxVolume)
            setMaxWieght(response.data.MaxWeight)
    }
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
            {/* <div className="photo-to-upload"></div> */}
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
                        <label htmlFor="">Make_Year</label>
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
                        <label htmlFor="">Max_Weight</label>
                        <input 
                            type="text"
                            value={maxWeight}
                            onChange={(e)=>setMaxWieght(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div>
                    
                    <div className="input-group-info">
                        <label htmlFor="">Max_Volume</label>
                        <input 
                            type="text"
                            value={maxVolume}
                            onChange={(e)=>setMaxVolume(e.target.value)} 
                            disabled={disableTrue}
                        />
                    </div>                  

                </form>
            </div>
        </div>
    )
}
export default Vehicle