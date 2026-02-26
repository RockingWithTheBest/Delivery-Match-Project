import axios from "axios";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PersonalInfo from "./PersonalInfo";
import Vehicle from "./Vehicle"
import Statistics from "./Statistics"
import Documents from "./Documents"
import './Profile.css'


const Profile=()=>{
    const [driverDetails, setDriverDetails]= useState("")
    const {DriverId} = useParams()
    const [completionPercentage, setCompletionPercentage] = useState(0)
    
    const [activatePersonalInfo, setPersonalInfo] = useState(true);
    const [activateVehicleInfo, setVehicleInfo] = useState(false);
    const [activateDocuments, setDocuments] = useState(false);
    const [activateStatistics, setStatistics] = useState(false);


    const url = "https://localhost:7216/api"
  

    const getDriverDetails = async()=>{
        const driver = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
            params:{
                Id:parseInt(DriverId)
            }
        })

        const user = await axios.get(`${url}/User/Get-Users-By-Id`,{
                params:{
                    id:parseInt(driver.data.UserId)
                }
        })
        
        const vehicle = await axios.get(`${url}/Driver/Get-Vehicle-By-DriverId`,{
            params:{
                DriverId:parseInt(DriverId)
            }
        })
       
        const details = {
            VehicleId:vehicle.data.Id || "",
            FirstName:user.data.FirstName || "",
            LastName:user.data.LastName || "",
            Email:user.data.Email || "",
            Phone:user.data.Phone || "",
            DrivingLicense:driver.data.DriversLicense || "",
            LicenseExpiry:driver.data.LicenseExpiry || "",
            IsVerified: driver.data.IsVerified || "",
            Rating : driver.data.Rating || "",
            CompletionRate :driver.data.CompletionRate || "",
            TotalEarnings: driver.data.TotalEarnings || 0.00,
            IsAvailable:driver.data.IsAvailable || "",
            Brand:vehicle.data.Brand || "",
            Model:vehicle.data.Model || "",
            MakeYear:vehicle.data.MakeYear || "",
            Color:vehicle.data.Color || "",
            LicensePlate:vehicle.data.LicensePlate || "",
            MaxWeight:vehicle.data.MaxWeight || "",
            MaxVolume:vehicle.data.MaxVolume || "",
            UserId:driver.data.UserId || "",
            DriverId:DriverId || "",
            Password:user.data.Password,
            IsAvailable:driver.data.IsAvailable
        }
    
        setDriverDetails(details)
        setCompletionPercentage(parseInt(details.CompletionRate))
    }

   
    const handlePersonalInfo =()=>{
        setPersonalInfo(true)
        setVehicleInfo(false)
        setDocuments(false)
        setStatistics(false)
    }

    const handleVehicleInfo =()=>{
        setPersonalInfo(false)
        setVehicleInfo(true)
        setDocuments(false)
        setStatistics(false)
    }

    const handleDocuments =()=>{
        setPersonalInfo(false)
        setVehicleInfo(false)
        setDocuments(true)
        setStatistics(false)
    }

    const handleStatistics =()=>{
        setPersonalInfo(false)
        setVehicleInfo(false)
        setDocuments(false)
        setStatistics(true)
    }    


    useEffect(()=>{
        getDriverDetails()
    },[DriverId])
    return(
        <div className="driver-profile">
            <div className="profile-first-part">
                <div className="client-abbreviation">
                    {driverDetails.FirstName?.charAt(0).toUpperCase()}
                    {driverDetails.LastName?.charAt(0).toUpperCase()}
                </div>
                <div className="client-details">
                    <h3>{driverDetails.FirstName} {driverDetails.LastName}</h3>
                    <p>{driverDetails.Brand} {driverDetails.Model}</p>
                    <p style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                        <span style={{ color: '#ffc107', fontSize: '1.2rem' }}>★</span>
                        <span>{driverDetails.Rating} rating</span>
                    </p>                  
                </div>
            </div>
            <div className="completion-bar">
                <div className="completion-header">
                    <span className="completion-label">Profile Completion</span>
                    <span className="completion-percentage">{completionPercentage}%</span>
                </div>
                <div className="progress-container">
                    <div 
                        className="progress-bar"
                        style={{ width: `${completionPercentage}%` }}
                    ></div>
                </div>
            </div>
            <div className="driver-sub-nav">
                <nav onClick={()=>handlePersonalInfo()}>Personal Info</nav>
                <nav onClick={()=>handleVehicleInfo()}>Vehicle Info</nav>
                <nav onClick={()=>handleDocuments()}>Documents</nav>
                <nav onClick={()=>handleStatistics()}>Statistics</nav>
            </div>
            {activatePersonalInfo && <PersonalInfo driverDetails={driverDetails}/>}
            {activateVehicleInfo && <Vehicle driverDetails={driverDetails}/>}
            {activateDocuments && <Documents/>}
            {activateStatistics && <Statistics/>}
         
        </div>
    )
}
export default Profile