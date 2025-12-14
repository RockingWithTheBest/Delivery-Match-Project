import {useState} from 'react'
import axios from 'axios'
import {useNavigate} from 'react-router-dom'
import BackArrow from './Icons/arrow-back.svg'
import './AuthStyle.css'

const Registration=()=>{

    const [loginbool, setLoginBool] = useState(true)
    const [regirsterbool, setRegisterBool] = useState(false)
    const [userType, setUserType] = useState('Client'); // State to manage user type\
    const [email, setEmail] = useState('')
    const [first_name, setFirstName] = useState('')
    const [last_name, setLastName] = useState('')
    const [password, setPassword] =useState('')
    const [confirm_password, setConfirmPassword] = useState('')
    const [phone_number, setPhoneNumber] = useState('')
    const [message, setMessage] = useState("");
    const api_url ="https://localhost:7216/api"
    const navigate = useNavigate()
// navigate()
    const loginUser=(async)=>{
        try{
            
        }
        catch(error){
            console.log("Message error", error)
        }
    }

    const [businessName, setBusinessName] = useState(null)
    const [businessType, setBusinessType] = useState(null)
    const [tax_dentification, setTaxIdentification] = useState(null)
    const [rating, setRating] = useState('4.5')

    const [driverLicense, setDriverLicense] = useState(null)
    const [licenseExpiry, setLicenseExpiry] = useState(null)
    const [completionRate, setCompletionRate] = useState('20%')
    const registerUser = async()=> {
        // e.preventDefault()

        try{
            if(userType == 'Client'){
                const Client = {
                    Email:email,
                    Phone:phone_number,
                    First_Name:first_name,
                    Last_Name:last_name,
                    Password:password,
                    Customer:{
                        Business_Name:businessName,
                        Business_Type:businessType,
                        Tax_Identification:tax_dentification,
                        Rating:rating,
                    }
                }
                console.log("ABOUT TO",Client)
               
                const response = await axios.post(`${api_url}/User/Add-User-With-Client`, Client)
                setMessage("Successfully registrated-client ", response.data);
                alert("Successfully registered Client")
            }
            else if(userType=='Driver'){
                const Driver = {
                    Email:email,
                    Phone:phone_number,
                    First_Name:first_name,
                    Last_Name:last_name,
                    Password:password,
                    Driver:{
                        Drivers_License:driverLicense,
                        License_Expiry:licenseExpiry,
                        Is_Verified: true,
                        Is_Available:false,
                        Rating:'3.0',
                        Completion_Rate:completionRate,
                        Total_Earnings: parseFloat(0)               
                    }
                }
                
                const response = await axios.post(`${api_url}/User/Add-User-With-Driver`,Driver)
                setMessage("Successfully registrated-driver ", response.data);
                console.log("USER",response)
                alert("Successfully registered Driver")
            }
        }
        catch(error){
           console.log("Registration error", error);
            console.log("Response data:", error.response?.data);
            setMessage("Registration failed: " + (error.response?.data?.message || error.message))
        }
    }
    
    const SwitchToLogin=(event)=>{
        event.preventDefault()
        setLoginBool(true)
        setRegisterBool(false)
    }
    const SwitchToRegistration=(event)=>{
        event.preventDefault()
        setRegisterBool(true)
        setLoginBool(false)        
    }

    const handleSignIn =async()=>{
       
        if(userType =='Client'){
            const responseUsers = await axios.get("https://localhost:7216/api/User/Get-All-Users")
            const responseClients = await axios.get("https://localhost:7216/api/Customer/Get-All-Customers")

            const allUsers = responseUsers.data
            const allClients = responseClients.data

            const user = allUsers.find(d=> d.Email === email && d.Password === password)
            console.log("RESPONSE", user)
            if(user.Customer!=null){
                const client = allClients.find(d=>d.UserId === user.Id)
                navigate(`/client/${user.Email}/${user.Password}/${client.Id}`)
            }
            else {
                alert("Click the Driver Option and enter your correct login details")
            }
        }
        else if(userType =='Driver'){
            const responseUsers = await axios.get("https://localhost:7216/api/User/Get-All-Users")
            const responseDrivers = await axios.get("https://localhost:7216/api/Driver/Get-All-Drivers")
           
            const allUsers = responseUsers.data
            const allDrivers = responseDrivers.data

            const user = allUsers.find(d=> d.Email === email && d.Password === password)
          
            if(user.Driver!=null){
                const driver = allDrivers.find(d=>d.UserId === user.Id)
                navigate(`/driver/${user.Email}/${user.Password}/${driver.Id}`)
            }
            else{
                alert("Click the Client Option and enter your correct login details")
            }
        }
    }
    const handleClient = (event) => {
        event.preventDefault()
        console.log("Clicked Client")
        setUserType('Client');
        
    };

    const handleDriver=(event)=>{
        event.preventDefault()
         setUserType('Driver');
         console.log("Clicked Driver")     
    }

    const handleNavigateBackToMainPage =()=>{
        navigate("/")
    }
  
    
    return(
        <div className='AuthComponent'>
            <h3>Authentication Page</h3>          
            <p className='continue-as'>Continue as {userType}</p>
            <div className='auth-container'>  
                
                <form action="" className="auth_form">
                    <img src={BackArrow} alt="" className='back-arrow-class'  title="Click to go back to main page" onClick={()=>handleNavigateBackToMainPage()} />
                    <div className="form-selector">
                        <button onClick={SwitchToLogin} disabled={loginbool} className="">
                            Login
                        </button>
                        <button onClick={SwitchToRegistration} disabled={regirsterbool}  className="">
                            Sign Up
                        </button>
                        <div className={`indicator ${loginbool ? 'login' : 'signup'}`}></div>
                    </div>

                    <div className="user-type-selector">
                        <button className='choice_user_selector' onClick={handleClient}>
                            <div>
                                <input
                                    id="client_selection"
                                    type="radio"
                                    value="Client"
                                    checked={userType === 'Client'}
                                    onChange={handleClient}
                                />
                                Ship goods and packages
                            </div>        
                        </button>
                        <button className='choice_user_selector' onClick={handleDriver}>
                            <div>
                                <input
                                    id="driver_selection"
                                    type="radio"
                                    value="Driver"
                                    checked={userType === 'Driver'}
                                    onChange={handleDriver}
                                />
                                Drive and earn money
                            </div>
                         
                        </button>
                            
                    
                    </div>
                    {loginbool && (
                        <>
                            <div className='form-group'>
                                <label htmlFor="email">Email</label>
                                <input 
                                    type="email" 
                                    id="email" 
                                    placeholder='john@example.com'
                                    value={email}
                                    onChange={(e)=>setEmail(e.target.value)}/>
                            </div>
                            <div className='form-group'>
                                <label htmlFor="password"/>
                                <input 
                                    type="password" 
                                    id="password" 
                                    placeholder='Enter your password' 
                                    value={password}
                                    onChange={(e)=>setPassword(e.target.value)}/>
                            </div>
                            <div className='form-group-button'>
                                <button type='button' onClick={()=>handleSignIn()} className='submit-button'>auth.signin</button>
                            </div>
                            <div className="form-footer">
                                <p className="forgot-password">Forgot your password?</p>
                                <p className="signup-prompt">Don't have an account?  <a href="/signup">Sign Up</a></p>
                            </div>
                        </>
                    )}
                    {regirsterbool && (
                        <>
                            <span>I want to:</span>
                            <div className='form-group'>
                                <label htmlFor="name">First Name</label>
                                <input 
                                    type="text" 
                                    required
                                    id="first_name" 
                                    placeholder='John'
                                    value={first_name}
                                    onChange={(e)=>setFirstName(e.target.value)}/>
                            </div>
                            <div className='form-group'>
                                <label htmlFor="name">Last Name</label>
                                <input 
                                    type="text" 
                                    required
                                    id="last_name" 
                                    placeholder='Doe'
                                    value={last_name}
                                    onChange={(e)=>setLastName(e.target.value)}/>
                            </div>
                            <div className='form-group'>
                                <label htmlFor="email">Email</label>
                                <input 
                                    type="email" 
                                    id="email" 
                                    required
                                    placeholder='john@example.com'
                                    value={email}
                                    onChange={(e)=>setEmail(e.target.value)}/>
                            </div>
                            <div className='form-group'>
                                <label htmlFor="number">Phone</label>
                                <input 
                                    type="tel" 
                                    required
                                    id="phone_number" 
                                    placeholder='+1 (555) 123-4567'
                                    value={phone_number}
                                    onChange={(e)=>setPhoneNumber(e.target.value)}/>
                            </div>
                            <div className='form-group'>
                                <label htmlFor="password">Password</label>
                                <input 
                                    type="password" 
                                    required
                                    id="password" 
                                    placeholder='Enter your password' 
                                    value={password}
                                    onChange={(e)=>setPassword(e.target.value)}/>
                            </div>
                            <div className='form-group'>
                                <label htmlFor="password">Confirm Password</label>
                                <input 
                                    type="password" 
                                    id="confirm_password" 
                                    required
                                    placeholder='Enter your password' 
                                    value={confirm_password}
                                    onChange={(e)=>setConfirmPassword(e.target.value)}/>
                            </div>
                             {userType=='Client' &&(
                                <div>
                                    <div className='form-group'>
                                        <label htmlFor="password">Business Name</label>
                                        <input 
                                            type="text" 
                                            id="business_name" 
                                            required
                                            placeholder='Enter your Business Name' 
                                            value={businessName}
                                            onChange={(e)=>setBusinessName(e.target.value)}/>
                                    </div>
                                    <div className='form-group'>
                                        <label htmlFor="password">Business Type</label>
                                        <input 
                                            type="text" 
                                            id="business_type" 
                                            required
                                            placeholder='Enter your Business Type' 
                                            value={businessType}
                                            onChange={(e)=>setBusinessType(e.target.value)}/>
                                    </div>
                                    <div className='form-group'>
                                        <label htmlFor="password">Tax Identififcation</label>
                                        <input 
                                            type="text" 
                                            id="tax_identififcation" 
                                            required
                                            placeholder='Enter your Tax Identififcation' 
                                            value={tax_dentification}
                                            onChange={(e)=>setTaxIdentification(e.target.value)}/>
                                    </div>
                                </div>
                            )}

                             {userType=='Driver' &&(
                                <div>
                                    <div className='form-group'>
                                        <label htmlFor="password">Driver License</label>
                                        <input 
                                            type="text" 
                                            id="driver_license" 
                                            required
                                            placeholder='Enter your Driver License' 
                                            value={driverLicense}
                                            onChange={(e)=>setDriverLicense(e.target.value)}/>
                                    </div>  
                                    <div className='form-group'>
                                        <label htmlFor="password">License Expiry Date</label>
                                        <input 
                                            type="date" 
                                            id="license_expiry" 
                                            required
                                            placeholder='Enter your License Expiry Date' 
                                            value={licenseExpiry}
                                            onChange={(e)=>setLicenseExpiry(e.target.value)}/>
                                    </div>   
                                </div>           
                            )}
                            <div>
                                <input type='checkbox' id="termsofagreement"/>
                                <label>I agree to the Terms of Service and Privacy Policy</label>
                            </div>
                            <div className='form-group-button'>
                                <button type='button' onClick={()=>registerUser()} className='signup-button'>Sign Up</button>
                            </div>
                            <div className="form-footer">
                                <p className="signup-prompt">Already have an account? <a href="/authpage">auth.signin</a></p>
                            </div>
                        </>                      
                    )}                                 
                </form>
            </div>
            


            
        </div>
    );
}
export default Registration