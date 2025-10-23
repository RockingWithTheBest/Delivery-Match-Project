import {useState} from 'react'
import axios from 'axios'

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
    const api_url ="https://localhost:7216/api/User/Add-Users"

    const loginUser=(async)=>{
        try{

        }
        catch(error){
            console.log("Message error", error)
        }
    }

    const registerUser = async(e)=> {
        e.preventDefault()

        try{
            const user= {
                first_name: first_name,
                last_name: last_name,
                email :email,
                phone_number: phone_number,
                password: password
            }
            const response = await axios.post(api_url, user)
            setMessage("Successfully registrated ", response.data);
            console.log(response.data)


             // Reset form
            setFirstName('')
            setLastName('')
            setEmail('')
            setPhoneNumber('')
            setPassword('')
            setConfirmPassword('')
        }
        catch(error){
            console.log("Registration error", error)
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
    return(
        <div className='AuthComponent'>
            <span>Regitstration</span>
           
          
            {/* <div className="languagedropdown">
                <svg xmlns="http://www.w3.org/2000/svg" className="my-custom-globe-icon">
                    <circle cx="12" cy="12" r="10"></circle>
                    <path d="M12 2a14.5 14.5 0 0 0 0 20 14.5 14.5 0 0 0 0-20"></path>
                    <path d="M2 12h20"></path>
                </svg>
                <span>🇺🇸</span>
               <span data-slot="select-value" class="select-value">
                    <div className="languagedropdown">
                        <span>🇺🇸</span>
                        <span>English</span>
                    </div>
                </span>
            </div> */}
            {/* <div className='auth-container-login'>
              
            </div> */}


            <div className='auth-container'>  
                <form action=""  onSubmit={registerUser}  className="auth_form">
                    <p>User Role {userType}</p>
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
                                <button type='submit' className='submit-button'>auth.signin</button>
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
                            <div>
                                <input type='checkbox' id="termsofagreement"/>
                                <label>I agree to the Terms of Service and Privacy Policy</label>
                            </div>
                            <div className='form-group-button'>
                                <button type='submit' className='signup-button'>Sign Up</button>
                            </div>
                            <div className="form-footer">
                                <p className="signup-prompt">Already have an account? <a href="/signup">auth.signin</a></p>
                            </div>
                        </>
                    )}                   
                </form>
            </div>
            


            
        </div>
    );
}
export default Registration