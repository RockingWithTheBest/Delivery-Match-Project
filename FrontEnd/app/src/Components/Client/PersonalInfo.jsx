import PersonalInfoIcon from "../Icons/personal-info.svg"
import BusinessInfo from "../Icons/businessman-personal-data-paper-svgrepo-com.svg"
import './Profile.css'
import { useEffect, useState } from "react"
import axios from "axios"
import { useParams } from "react-router-dom"

const PersonalInfo=({customerDetails})=>{
    const {password}=useParams()
    const {ClientId}=useParams()
    const [disableTrue,setDisableToTrue] = useState(true)
    const [firstName, setFirstName] = useState(customerDetails.Customer_FirstName || "")
    const [lastName, setLastName] = useState(customerDetails.Customer_LastName || "")
    const [email, setEmail] = useState(customerDetails.Customer_Email || "")
    const [phone, setPhone] = useState(customerDetails.Customer_Phone || "")
    const [businessName, setBusinessName] = useState(customerDetails.Customer_Business_Name || "")
    const [businessTypeName, setBusinessTypeName] = useState(customerDetails.Customer_Business_Type || "")
    const [businessTax, setBusinessTaxIdentification] = useState(customerDetails.Customer_Tax_Identification || "")

    const [btnName, setBtnName] =  useState("Edit Profile")
    const url ="https://localhost:7216/api"

    const handleEdit =async()=> {
        
        if(disableTrue){
            setDisableToTrue(false)
            setBtnName("Save Changes")
        }
        else{

            try{                        
                const customerResponse = await axios.get(`${url}/Customer/Get-GetCustomerDetails-By-Id`,
                    {
                        params:{
                            id:parseInt(ClientId)
                        }
                    }
                )

                const customer = {
                    BusinessName:businessName,
                    BusinessType:businessTypeName,
                    TaxIdentification:businessTax,
                    Rating:customerResponse.data.Rating,
                    TotalOrders:customerResponse.data.Total_Orders,
                    TotalSpent:customerResponse.data.Total_Spent,
                    UserId:customerResponse.data.UserId
                }

                const user = {
                    Email:email,
                    Phone:phone,
                    FirstName:firstName,
                    LastName:lastName,
                    Password:password
                }

                await axios.put(`${url}/User/Editing-User`,user,{
                    params:{
                        Id:parseInt(parseInt(customerResponse.data.UserId))
                    }
                })

                await axios.put(`${url}/Customer/Edit-Customer`,customer,{
                    params:{
                        Id:parseInt(ClientId),
                    }
                })

                setDisableToTrue(true)
                setBtnName("Edit Profile")
                alert("Profile updated successfully!")
            }
            catch(e){
                console.log("ERROR", e.message)             
            }
        }
     
        
       
    }
    useEffect(()=>{
        setBtnName("Edit Profile")
        setFirstName(customerDetails.Customer_FirstName || "")
        setLastName(customerDetails.Customer_LastName || "")
        setEmail(customerDetails.Customer_Email || "")
        setPhone(customerDetails.Customer_Phone || "")
        setBusinessName(customerDetails.Customer_Business_Name || "")
        setBusinessTypeName(customerDetails.Customer_Business_Type || "")
        setBusinessTaxIdentification(customerDetails.Customer_Tax_Identification || "")
    },[customerDetails])
    return(
        <div>                                         
            <form onSubmit={(e)=>e.preventDefault()} action="">
                           
                <div className="info-btn">
                    <div className="informational-personal">
                        <img src={PersonalInfoIcon} alt="" className="personal-info" />
                            <p>Personal Information</p>
                    </div>                            
                    <button type="button" onClick={()=>handleEdit()}>{btnName}</button>                                                                
                </div>
                <div className="two-two-display">
                    <div className="">
                        <label htmlFor="">First Name</label>
                        <input 
                            type="text" 
                                disabled={disableTrue}
                                value={firstName}
                                onChange={(e)=>setFirstName(e.target.value)}
                            />
                    </div>
                    <div className="">
                        <label htmlFor="">Last Name</label>
                        <input 
                           type="text" 
                           disabled={disableTrue} 
                           value={lastName}
                           onChange={(e)=>setLastName(e.target.value)}
                       />
                    </div>
                    </div>
                        
                    <div className="input-personal">
                        <label htmlFor="">Email</label>
                        <input 
                            type="email"
                            disabled={disableTrue}  
                            value={email}
                            onChange={(e)=>setEmail(e.target.value)}
                        />
                    </div>
                    <div className="input-personal">
                        <label htmlFor="">Phone Number</label>
                        <input 
                            type="number" 
                            disabled={disableTrue}
                            value={phone}
                            onChange={(e)=>setPhone(e.target.value)}
                        />
                    </div>
                </form>

                <form  onSubmit={(e)=>e.preventDefault()} action="">
                    <div className="business-personal">
                        <img src={BusinessInfo} alt="" className="business-info" />
                        <p>Business Information</p>
                    </div>                          
                    <div className="input-personal">
                        <label htmlFor="">Business Name</label>
                        <input 
                            type="text" 
                            disabled={disableTrue}
                            value={businessName}
                            onChange={(e)=>setBusinessName(e.target.value)}
                        />
                    </div>
                    <div className="input-personal">
                        <label htmlFor="">Business Type</label>
                        <input 
                            type="text" 
                            disabled={disableTrue}
                            value={businessTypeName}
                            onChange={(e)=>setBusinessTypeName(e.target.value)}
                        />
                    </div>
                    <div className="input-personal">
                        <label htmlFor="">Taxt Identification</label>
                        <input 
                            type="text" 
                            disabled={disableTrue}
                            value={businessTax}
                            onChange={(e)=>setBusinessTaxIdentification(e.target.value)}
                        />
                    </div>
                </form>
        </div>
    )
    
}

export default PersonalInfo    