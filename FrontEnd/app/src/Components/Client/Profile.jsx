import React, { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import axios from 'axios';
import BusinessInfo from "../Icons/businessman-personal-data-paper-svgrepo-com.svg"
import PersonalInfo from "./PersonalInfo"
import Address from "./Address"
import './Profile.css'

const Profile=()=>{
    const {ClientId} = useParams()
    const url = "https://localhost:7216/api/"
    const [customerDetails, setCustomerDetails] = useState(null)
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [activeNav, setActiveNav] = useState('Profile');
    const [personal, setPersonal] = useState(true)
    const [address, setAddress] = useState(false)
    const [payment, setPayement] = useState(false)
    const [preferences, setPreferences] = useState(false)
    const [statistics, setStatistics] = useState(false)
    const [disableTrue,setDisableToTrue] = useState(true)

    const getSingleCustomer =async()=>{
        try{
            setLoading(true)
            setError(null);
            const customer = await axios.get(`${url}Customer/Get-GetCustomerDetails-By-Id`,{
                params:{
                    id:parseInt(ClientId)
                }           
            })
           
            const user = await axios.get(`${url}User/Get-Users-By-Id`,{
                params:{
                    id:parseInt(customer.data.UserId)
                }
            })
  
            const details = {
                Customer_FirstName:user.data.FirstName || "",
                Customer_LastName:user.data.LastName || "",
                Customer_Tax_Identification:customer.data.TaxIdentification || "",
                Customer_Total_Orders:customer.data.TotalOrders || "",
                Customer_Total_Spent:customer.data.TotalSpent || "",
                Customer_Email:user.data.Email || "",
                Customer_Phone:user.data.Phone || "",
                Customer_Business_Name:customer.data.BusinessName || "",
                Customer_Business_Type:customer.data.BusinessType || "",
                Customer_Rating:customer.data.Rating || ""
            }
            setCustomerDetails(details)
                  
        }
        catch(e){
            console.log("ERROR",e.message)
        }  
        finally{
            setLoading(false);  
        }      
    }

    useEffect(()=>{
        if(ClientId){
            getSingleCustomer();
        }
        else{
            setLoading(false)
        }
    },[ClientId])
    
    // Show loading state
    if (loading) {
        return (
            <div className="client-profile">
                <div className="loading">Loading profile...</div>
            </div>
        );
    }

    if (error) {
        return (
            <div className="client-profile">
                <div className="error">Error loading profile: {error}</div>
            </div>
        );
    }

    if (!customerDetails) {
        return (
            <div className="client-profile">
                <div className="error">No customer data available</div>
            </div>
        );
    } 
    
    const handlePersonal = () => {
        setActiveNav('Profile');
        setPersonal(true)
        setAddress(false)
    }
    const handleAddress = () =>{
        setActiveNav('Address');
        setAddress(true)
        setPersonal(false)
    } 
    const handlePayment = () => setActiveNav('Track Orders');
    const handlePrefernces = () => setActiveNav('Find Drivers');
    const handleStatistics = () => setActiveNav('Notification');
    const handleEdit =()=> setDisableToTrue(false)

    return(
        <div className="client-profile">
            <div className="profile-first-part">
                  <div className="client-abbreviation">
                    {customerDetails.Customer_FirstName?.charAt(0).toUpperCase()}
                    {customerDetails.Customer_LastName?.charAt(0).toUpperCase()}
                </div>
                <div className="client-details">
                    <h3>{customerDetails.Customer_FirstName} {customerDetails.Customer_LastName}</h3>
                    <p>Business: {customerDetails.Customer_Business_Name}</p>
                    <p style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                        <span style={{ color: '#ffc107', fontSize: '1.2rem' }}>★</span>
                        <span>{customerDetails.Customer_Rating} rating</span>
                        <span>{customerDetails.Customer_Total_Orders} Total Orders</span>
                    </p>                  
                </div>
            </div>
            <div className="client-nav">        
                    <nav 
                        className={activeNav === 'Profile' ? 'active' : ''} 
                        onClick={()=>handlePersonal()}
                    >
                        {activeNav === 'Profile' && <span className="nav-indicator"></span>}
                        Personal
                    </nav>
                    <nav 
                        className={activeNav === 'Address' ? 'active' : ''} 
                        onClick={()=>handleAddress()}
                    >
                        {activeNav === 'Address' && <span className="nav-indicator"></span>}
                        Address
                    </nav>
                    <nav 
                        className={activeNav === 'Track Orders' ? 'active' : ''} 
                        onClick={()=>handlePayment()}
                    >
                        {activeNav === 'Track Orders' && <span className="nav-indicator"></span>}
                        Payment
                    </nav>
                    <nav 
                        className={activeNav === 'Find Drivers' ? 'active' : ''} 
                        onClick={()=>handlePrefernces()}
                    >
                        {activeNav === 'Find Drivers' && <span className="nav-indicator"></span>}
                        Preferences
                    </nav>
                    <nav 
                        className={activeNav === 'Notification' ? 'active' : ''} 
                        onClick={()=>handleStatistics()}
                    >
                        {activeNav === 'Notification' && <span className="nav-indicator"></span>}
                        Statistics
                    </nav>                
            </div>
            <div className="seperation-zone">
                {personal &&(                
                    <PersonalInfo customerDetails ={customerDetails}/> 
                )}
                {address&&(
                    <Address  customerDetails ={customerDetails}/>
                )}              
            </div>        
        </div>
        
        
    )
}

export default Profile