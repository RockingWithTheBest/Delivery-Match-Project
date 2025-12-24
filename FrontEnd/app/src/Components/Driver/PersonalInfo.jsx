import axios from "axios";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PersonalInfoIcon from "../Icons/personal-info.svg"
import './PersonalInfo.css'

const PersonalInfo =({driverDetails})=>{
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
    const [btnName, setBtnName] =  useState("Edit Profile")
    const url ="https://localhost:7216/api"


    const handleEditAndDisable =async()=>{
        if(disableTrue==true){
            setDisableToTrue(false)
            setBtnName("Save Profile")
        }
        else if(disableTrue == false){
            setDisableToTrue(true)
            setBtnName("Edit Profile")
            putUserAndDriver()
        }
    }
        
    const putUserAndDriver=async()=>{
        try{
            const user = {
                UserId:driverDetails.UserId,
                FirstName:firstName,
                LastName:lastName,
                Phone:phone,
                Email:email,
                Password:driverDetails.Password
            }
  
            await axios.put(`${url}/User/Editing-User`,user,{
                params:{
                    Id:parseInt(user.UserId)
                }
            })
          
            const driver = {
                DriversLicense:driverLicense,
                LicenseExpiry:licenseExpiry,
                IsVerified:isVerified,
                IsAvailable:driverDetails.IsAvailable,
                Rating:rating,
                CompletionRate:completionRate,
                TotalEarnings:parseFloat(totalEarnings),
                UserId:parseInt(user.UserId)
            }
            
            await axios.put(`${url}/Driver/Editing-Driver`,driver,{
                params:{
                    Id:parseInt(DriverId)
                }
            })        
        }
        catch(e){
            console.log("ERROR", e)
        }
    }
    const handleReloadz=async()=>{        
        const responseDriver = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
            params:{
                Id:parseInt(DriverId)
            }
        })

        const responseUser = await axios.get(`${url}/User/Get-Users-By-Id`,{
            params:{
                id:parseInt(responseDriver.data.UserId)
            }
        })
        setFirstName(responseUser.data.FirstName)
        setLastName(responseUser.data.LastName)
        setEmail(responseUser.data.Email)
        setPhone(responseUser.data.Phone)
        setDriverLicense(responseDriver.data.DriversLicense)
        setLicenseExpiry(responseDriver.data.LicenseExpiry)
    }

    useEffect(()=>{
        handleReloadz()
    },[DriverId])

    useEffect(()=>{
        if(driverDetails){
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
        }
    },[driverDetails])

    
    return(
        <div className="persoal-info-driver">
            <div className="person-edit-info">
                <div>
                    <img src={PersonalInfoIcon} alt="" />
                    <p>Personal Information</p>
                </div>                
                <button onClick={()=>handleEditAndDisable()}>{btnName}</button>
            </div>
            <form action="" className="driver-form-personal-info">
                <div className="input-group-info">
                    <label htmlFor="">First Name</label>
                    <input 
                        type="text"
                        value={firstName}
                        onChange={(e)=>setFirstName(e.target.value)} 
                        disabled={disableTrue}
                    />
                </div>
                
                <div className="input-group-info">
                    <label htmlFor="">Last Name</label>
                    <input 
                        type="text"
                        value={lastName}
                        onChange={(e)=>setLastName(e.target.value)}
                        disabled={disableTrue} 
                    />
                </div>
                
                <div className="input-group-info">
                    <label htmlFor="">Email Address</label>
                    <input 
                        type="email" 
                        value={email}
                        onChange={(e)=>setEmail(e.target.value)}
                        disabled={disableTrue}
                    />    
                </div>
                
                <div className="input-group-info">
                    <label htmlFor="">Phone</label>
                   <input 
                        type="number" 
                        value={phone}
                        onChange={(e)=>setPhone(e.target.value)}
                        disabled={disableTrue}
                    /> 
                </div>
                
                <div className="input-group-info">
                    <label htmlFor="">Driver License</label>
                    <input 
                        type="text"
                        value={driverLicense}
                        onChange={(e)=>setDriverLicense(e.target.value)} 
                        disabled={disableTrue}
                        />
                </div>
                                
                <div className="input-group-info">
                    <label htmlFor="">License Expiry</label>
                    <input 
                        type="date"
                        value={licenseExpiry}
                        onChange={(e)=>setLicenseExpiry(e.target.value)} 
                        disabled={disableTrue}
                        />
                </div>
            </form>
        </div>
    )
}
export default PersonalInfo


