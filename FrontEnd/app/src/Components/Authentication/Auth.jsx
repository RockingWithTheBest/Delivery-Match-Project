import {useEffect, useState} from 'react'
import axios from 'axios'
import {useNavigate} from 'react-router-dom'
import BackArrow from './Icons/arrow-back.svg'
import RequestEmail from './RequestEmail'
import PasswordChanger from './PasswordChanger'
import * as yup from 'yup';
import './AuthStyle.css'


const Registration=()=>{

    const [openEmailRequest, setEmailRequest] = useState(false)
    const [openPasswordChanger, setPasswordChanger] = useState(false)
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
    const [businessNameField, setBusinessName] = useState(null)
    const [businessTypeField, setBusinessType] = useState(null)
    const [tax_dentification_Field, setTaxIdentification] = useState(null)
    const [rating, setRating] = useState('4.5')
    const [driverLicenseField, setDriverLicense] = useState(null)
    const [licenseExpiryField, setLicenseExpiry] = useState(null)
    const [completionRateField, setCompletionRate] = useState('20%')
    const [termsAccepted, setTermsAccepted] = useState(false);
    const [errors, setErrors] = useState({});
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [isValid, setIsValid] = useState(false);
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });

    const api_url ="https://localhost:7216/api"
    const navigate = useNavigate()

    const loginUser=(async)=>{
        try{
            
        }
        catch(error){
            console.log("Message error", error)
        }
    }
    
    const clientSchema = yup.object().shape({
        firstName: yup
            .string()
            .required('First name is required')
            .min(2, 'First name must be at least 2 characters')
            .max(50, 'First name cannot exceed 50 characters')
            .matches(/^[a-zA-Z\s]*$/, 'First name can only contain letters'),

        lastName: yup
            .string()
            .required('Last name is required')
            .min(2, 'Last name must be at least 2 characters')
            .max(50, 'Last name cannot exceed 50 characters')
            .matches(/^[a-zA-Z\s]*$/, 'Last name can only contain letters'),

        email: yup
            .string()
            .required('Email is required')
            .email('Please enter a valid email address')
            .matches(/^[^\s@]+@[^\s@]+\.[^\s@]+$/, 'Invalid email format'),

        phoneNumber: yup
            .string()
            .required('Phone number is required')
            .matches(/^[0-9]{10}$/, 'Phone number must be 10 digits'),

        password: yup
            .string()
            .required('Password is required')
            .min(8, 'Password must be at least 8 characters')
            .matches(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]/,
            'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character'
            ),

        confirmPassword: yup
            .string()
            .required('Please confirm your password')
            .oneOf([yup.ref('password'), null], 'Passwords must match'),

        businessName: yup
            .string()
            .required('Business Name is required')
            .min(8, 'Business Name must be at least 8 characters')
            .max(20, 'Business Name cannot exceed 20 characters')
            .matches(/^[a-zA-Z\s]*$/, 'Business name can only contain letters'),
        
        businessType: yup
            .string()
            .required('Business Type is required')
            .min(8, 'Business Type must be at least 8 characters')
            .max(20, 'Business Type cannot exceed 20 characters')
            .matches(/^[a-zA-Z\s]*$/, 'Business type can only contain letters'),

        taxIdentification: yup
            .string()
            .required('Tax Identification is required')
            .min(8, 'Tax Identification must be at least 8 characters')
            .max(20, 'Tax Identification cannot exceed 20 characters')
            .matches(/^(?=.*[0-9])(?=.*[A-Z])[A-Z0-9]+$/, 'Tax Identification must contain numbers and letters'),

        termsAccepted: yup
            .boolean()
            .oneOf([true], 'You must accept the terms and conditions'),
    });

    const driverSchema = yup.object().shape({
        firstName: yup
            .string()
            .required('First name is required')
            .min(2, 'First name must be at least 2 characters')
            .max(50, 'First name cannot exceed 50 characters')
            .matches(/^[a-zA-Z\s]*$/, 'First name can only contain letters'),

        lastName: yup
            .string()
            .required('Last name is required')
            .min(2, 'Last name must be at least 2 characters')
            .max(50, 'Last name cannot exceed 50 characters')
            .matches(/^[a-zA-Z\s]*$/, 'Last name can only contain letters'),

        email: yup
            .string()
            .required('Email is required')
            .email('Please enter a valid email address')
            .matches(/^[^\s@]+@[^\s@]+\.[^\s@]+$/, 'Invalid email format'),

        phoneNumber: yup
            .string()
            .required('Phone number is required')
            .matches(/^[0-9]{10}$/, 'Phone number must be 10 digits'),

        password: yup
            .string()
            .required('Password is required')
            .min(8, 'Password must be at least 8 characters')
            .matches(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]/,
            'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character'
            ),

        confirmPassword: yup
            .string()
            .required('Please confirm your password')
            .oneOf([yup.ref('password'), null], 'Passwords must match'),

        driversLicense: yup
            .string()
            .required('Driver License is required')
            .min(5, 'Driver License must be at least 5 characters')
            .max(20, 'Driver License cannot exceed 20 characters')
            .matches(/^[A-Z0-9]+$/, 'Driver License must contain only uppercase letters and numbers'),

        licenseExpiry: yup
            .date()
            .required('License Expiry Date is required')
            .min(new Date(), 'License must not be expired')
            .typeError('Please enter a valid date'),

        termsAccepted: yup
            .boolean()
            .oneOf([true], 'You must accept the terms and conditions')
            .required('You must accept the terms and conditions'),
    });

    const currentSchema =(userType)=>{
        console.log(" user type",userType)
        if(userType === 'Client'){
            return clientSchema
        }
        else if(userType === 'Driver'){
            return driverSchema
        }
    }

    // Function to validate a single field
    const validateOnChange  = async(fieldName, value)=>{
        try{
            // Create a temporary object with all form values
            const formData = {
                firstName: first_name,
                lastName: last_name,
                email: email,
                phoneNumber: phone_number,
                password: password,
                confirmPassword: confirm_password,           
                //Client & Driver
                termsAccepted: termsAccepted
            };        

            if (userType === 'Client') {
                //Client
                formData.businessName = businessNameField
                formData.businessType = businessTypeField
                formData.taxIdentification = tax_dentification_Field

            } else if(userType === 'Driver'){
                //Driver
                formData.driversLicense = driverLicenseField
                formData.licenseExpiry = licenseExpiryField
            }

            // Update the field being changed
            formData[fieldName] = value;

            // Validate only the specific field
            await yup.reach(currentSchema(userType), fieldName).validate(value)

            // Clear error for this field
            setErrors(pev=>({...prev, [fieldName]:undefined}));

            // Revalidate entire form
            validateForm();
            return true
        }
        catch(error){
            // Set error for this field
            setErrors(prev => ({ ...prev, [fieldName]: error.message }));
            setIsValid(false);
            return false;
        }
    }

     // Function to validate entire form
    const validateForm = async()=>{

        try{
             const formData = {
                firstName: first_name,
                lastName: last_name,
                email: email,
                phoneNumber: phone_number,
                password: password,
                confirmPassword: confirm_password,
                termsAccepted: termsAccepted
            };

            if (userType === 'Client') {
                formData.businessName = businessNameField
                formData.businessType = businessTypeField
                formData.taxIdentification  = tax_dentification_Field                
            } 
            else if(userType === 'Driver'){
                formData.driversLicense = driverLicenseField
                formData.licenseExpiry = licenseExpiryField                
            }

            console.log("validating data for",userType, formData) 
            
            await currentSchema(userType).validate(formData, {abortEarly:false});
            setErrors({});
            setIsValid(true);
            return true;
        }
        catch (error) {
            console.log("Validation error", error)
            const newErrors = {};
            if (error.inner) {
                error.inner.forEach(err => {
                    newErrors[err.path] = err.message;
                    console.log(`Field : ${err.path}, Error: ${err.message}`)
                });
            }
            setErrors(newErrors);
            setIsValid(false);
            return false;
        }
    }

    // Handle field change with validation
    const handleFieldChange = (fieldName, value, setter) => {
        setter(value);
        // Trigger validation after a short delay
        setTimeout(() => {
            validateOnChange(fieldName, value);
        }, 300);
    };

    const registerUser = async(e)=> {
        if(e){
            e.preventDefault()
        }

        if(!regirsterbool) return;

        setIsSubmitting(true)

        // Validate form before submission
        const isValid = await validateForm();
        if (!isValid) {
            console.log("Validation",isValid)
            setIsSubmitting(false);
            showNotification('Please fix the errors in the form', 'error');
            return;
        }

        try{
            if(userType == 'Client'){
                const Client = {
                    Email:email,
                    Phone:phone_number,
                    FirstName:first_name,
                    LastName:last_name,
                    Password:password,
                    Customer:{
                        BusinessName:businessNameField,
                        BusinessType:businessTypeField,
                        TaxIdentification:tax_dentification_Field,
                        Rating:rating,
                    }
                }
               
                const response = await axios.post(`${api_url}/User/Register-User-Record`, Client)
                showNotification("Successfully registrated Client ","success")

                resetForm();
                setLoginBool(true);
                setRegisterBool(false);
            }
            else if(userType == 'Driver'){
                const Driver = {
                    Email:email,
                    Phone:phone_number,
                    FirstName:first_name,
                    LastName:last_name,
                    Password:password,
                    Driver:{
                        DriversLicense:driverLicenseField,
                        LicenseExpiry:licenseExpiryField,
                        IsVerified: true,
                        IsAvailable:false,
                        Rating:'3.0',
                        CompletionRate:completionRateField,
                        TotalEarnings: parseFloat(0)               
                    }
                }
                
                console.log("DATE_ DRIVER",Driver)
                const response = await axios.post(`${api_url}/User/Register-User-Record`,Driver)
                showNotification("Successfully registrated Driver ", 'success');

                resetForm();
                setLoginBool(true);
                setRegisterBool(false);
            }
        }
        catch(error){
            console.log("Registration error", error);
            console.log("Response data:", error.response?.data);
            console
             console.log("Registration failed: " + (error.response?.data?.message || error.message))
            showNotification('Registration failed. Please try again.', 'error');
        }
        finally {
            setIsSubmitting(false);
        }
    }

    // Reset form function
    const resetForm = () => {
        setEmail('');
        setFirstName('');
        setLastName('');
        setPassword('');
        setConfirmPassword('');
        setPhoneNumber('');
        setBusinessName('');
        setBusinessType('');
        setTaxIdentification('');
        setDriverLicense('');
        setLicenseExpiry('');
        setTermsAccepted(false);
        setErrors({});
    };
    
    const SwitchToLogin=(event)=>{
        event.preventDefault()
        setLoginBool(true)
        setRegisterBool(false)
        showNotification("Form switched to Login", 'success')
        resetForm();
    }
    const SwitchToRegistration=(event)=>{
        event.preventDefault()
        setRegisterBool(true)
        setLoginBool(false)  
        showNotification("Form switched to Registration", 'success')
        resetForm();      
    }

    const handleSignIn =async()=>{
     
        if(userType =='Client'){
            try{
                const loginResponse = await axios.post("https://localhost:7216/api/JWTControllerTakeThisToUser/login-jwt", {
                            email:email,
                            password : password
                        }
                )
                const token =  loginResponse.data.Token

                // Set the token in Authorization header for subsequent requests
                axios.defaults.headers.common['Authorization'] = `Bearer ${token}`

                // Use the profile endpoint to get complete user data
                const profileResponse = await axios.get(
                    "https://localhost:7216/api/JWTControllerTakeThisToUser/profile-jwt"
                );

                const userProfile = profileResponse.data;
                console.log("User profile:", userProfile);

                const responseUsers = await axios.get("https://localhost:7216/api/User/Get-All-Users")
                const responseClients = await axios.get("https://localhost:7216/api/Customer/Get-All-Customers")

                // const allUsers = responseUsers.data
                // const allClients = responseClients.data

                // const user = allUsers.find(d=> d.Email === email && d.Password === password)
                if(userProfile.Customer!=null){
                    // const client = allClients.find(d=>d.UserId === user.Id)
                    navigate(`/client/${userProfile.Email}/${userProfile.Customer.Id}`)
                    showNotification("You have successfully logged in", 'success')
                }
                else {
                    showNotification("Click the Driver Option and enter your correct login details", 'warning')
                }
            }
            catch(error){
                console.log("Exception Message", error)
                showNotification("You have an issue with your credientials", 'error')
            }
        }
        else if(userType =='Driver'){

            try{
                const loginResponse = await axios.post("https://localhost:7216/api/JWTControllerTakeThisToUser/login-jwt", {
                        email:email,
                        password : password
                    }
                )

                const token =  loginResponse.data.Token

                // Set the token in Authorization header for subsequent requests
                axios.defaults.headers.common['Authorization'] = `Bearer ${token}`

                // Use the profile endpoint to get complete user data
                const profileResponse = await axios.get(
                    "https://localhost:7216/api/JWTControllerTakeThisToUser/profile-jwt"
                );

                const userProfile = profileResponse.data;


                if(userProfile.Driver!=null){
                    // const client = allClients.find(d=>d.UserId === user.Id)
                    // navigate(`/driver/${userProfile.Email}/${userProfile.Driver.Id}`)
                    navigate(`/driver/${userProfile.Email}/${userProfile.Driver.UserId}`)
                    showNotification("You have successfully logged in", 'success')
                }
                else {
                    showNotification("Click the Client Option and enter your correct login details", 'warning')
                }
            }
            catch(error){
                console.log("Message error", error)
                showNotification("You have an issue with your credientials", 'error')
            }
        }
    }
    const handleClient = (event) => {
        event.preventDefault()
        setUserType('Client');

        //clear all driver specific fields
        setDriverLicense(null)
        setLicenseExpiry(null)

        //Keep client fields if needed, but clear them for fresh start
        setBusinessName(null)
        setBusinessType(null)
        setTaxIdentification(null)

        showNotification("You are about to continue as Client", 'success')
        resetForm();
    };

    const handleDriver=(event)=>{
        event.preventDefault()
        setUserType('Driver');

        //clear all client specific fields
        setBusinessName(null)
        setBusinessType(null)
        setTaxIdentification(null)

        //Keep driver fields if needed, but clear them for fresh start
        setDriverLicense(null)
        setLicenseExpiry(null)

        showNotification("You are about to continue as Driver", 'success')
        resetForm(); 
    }

    const handleNavigateBackToMainPage =()=>{
        navigate("/")
    }
    
    // Password strength checker
    const getPasswordStrength =()=>{
        if(!password) return {strength : 'Empty', percent:0};

        let score = 0;
        if (password.length >= 8) 
            score++;
        if (/[A-Z]/.test(password)) score++;
        if (/[a-z]/.test(password)) score++;
        if (/\d/.test(password)) score++;
        if (/[@$!%*?&]/.test(password)) score++;

        const percent = (score / 5) * 100;
        let strength = 'Weak';
        if (percent >= 80) strength = 'Strong';
        else if (percent >= 60) strength = 'Good';
        else if (percent >= 40) strength = 'Fair';

        return {
            strength,
            percent
        }
    }

    const passwordStrength = getPasswordStrength();

    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
    };

    useEffect(()=>{
        if (regirsterbool) {
            validateForm();
        }
    },[
        first_name, last_name, email, phone_number, password,
        confirm_password, businessNameField, businessTypeField, 
        tax_dentification_Field, driverLicenseField, licenseExpiryField,
        userType, regirsterbool
    ])

    useEffect(() => {
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);   
    
    return(
        <div className='AuthComponent'>
            <h3>Authentication Page</h3>          
            <p className='continue-as'>Continue as {userType}</p>
            <div className='auth-container'>  
                {/* onSubmit={registerUser} */}
                <form  action="" className="auth_form">
                    <img src={BackArrow} 
                        alt="" className='back-arrow-class'  
                        title="Click to go back to main page" 
                        onClick={()=>handleNavigateBackToMainPage()} 
                    />
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
                                    onChange={(e)=>setEmail(e.target.value)}
                                    className={errors.email ? 'error' : ''}
                                    />
                                    {errors.email && <span className="error-message">{errors.email}</span>}
                            </div>
                            <div className='form-group'>
                                <label htmlFor="password"/>
                                <input 
                                    type="password" 
                                    id="password" 
                                    placeholder='Enter your password' 
                                    value={password}
                                    onChange={(e)=>setPassword(e.target.value)}
                                    className={errors.password ? 'error' : ''}
                                />
                                {errors.password && <span className="error-message">{errors.password}</span>}
                            </div>

                            <div className='form-group-button'>
                                <button type='button' onClick={()=>handleSignIn()} className='submit-button'>auth.signin</button>
                            </div>
                            <div className="form-footer">
                                <button className="forgot-password" type="button" onClick={()=>setEmailRequest(true)}>Request for password Change?</button>
                                <button className="forgot-password" type="button"  onClick={()=>setPasswordChanger(true)}>Procced to change password</button>
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
                                    onChange={(e)=>setFirstName(e.target.value)}
                                    className={errors.firstName ? 'error' : ''}
                                    />
                                {errors.firstName && <span className="error-message">{errors.firstName}</span>}
                            </div>
                            <div className='form-group'>
                                <label htmlFor="name">Last Name</label>
                                <input 
                                    type="text" 
                                    required
                                    id="last_name" 
                                    placeholder='Doe'
                                    value={last_name}
                                    onChange={(e)=>setLastName(e.target.value)}
                                    className={errors.lastName ? 'error' : ''}
                                    />
                                {errors.lastName && <span className="error-message">{errors.lastName}</span>}
                            </div>
                            <div className='form-group'>
                                <label htmlFor="email">Email</label>
                                <input 
                                    type="email" 
                                    id="email" 
                                    required
                                    placeholder='john@example.com'
                                    value={email}
                                    onChange={(e)=>setEmail(e.target.value)}
                                    className={errors.email ? 'error' : ''}
                                    />
                                {errors.email && <span className="error-message">{errors.email}</span>}
                            </div>
                            <div className='form-group'>
                                <label htmlFor="number">Phone</label>
                                <input 
                                    type="tel" 
                                    required
                                    id="phone_number" 
                                    placeholder='375551234567'
                                    value={phone_number}
                                    onChange={(e)=>setPhoneNumber(e.target.value)}
                                    className={errors.phoneNumber ? 'error' : ''}
                                    />
                                    {errors.phoneNumber && <span className="error-message">{errors.phoneNumber}</span>}
                            </div>
                            <div className='form-group'>
                                <label htmlFor="password">Password</label>
                                <input 
                                    type="password" 
                                    required
                                    id="password" 
                                    placeholder='Enter your password' 
                                    value={password}
                                    onChange={(e)=>setPassword(e.target.value)}
                                    className={errors.password ? 'error' : ''}
                                    />
                                {errors.password && <span className="error-message">{errors.password}</span>}

                                {/* Password strength indicator */}
                                {password && (
                                    <div className="password-strength">
                                        <div 
                                            className={`strength-bar ${passwordStrength.strength.toLowerCase()}`}
                                            style={{ width: `${passwordStrength.percent}%` }}
                                        ></div>
                                        <small>Password strength: {passwordStrength.strength}</small>
                                    </div>
                                )}
                            </div>
                            <div className='form-group'>
                                <label htmlFor="password">Confirm Password</label>
                                <input 
                                    type="password" 
                                    id="confirm_password" 
                                    required
                                    placeholder='Enter your password' 
                                    value={confirm_password}
                                    onChange={(e)=>setConfirmPassword(e.target.value)}
                                    className={errors.confirmPassword ? 'error' : ''}
                                    />
                                {errors.confirmPassword && <span className="error-message">{errors.confirmPassword}</span>}
                                {confirm_password && password === confirm_password && !errors.confirmPassword && (
                                    <span className="success-message">✓ Passwords match</span>
                                )}
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
                                            value={businessNameField}
                                            onChange={(e)=>setBusinessName(e.target.value)}
                                            className={errors.businessName ? 'error' : ''}
                                        />
                                        {errors.businessName && <span className="error-message">{errors.businessName}</span>}
                                    </div>
                                    <div className='form-group'>
                                        <label htmlFor="password">Business Type</label>
                                        <input 
                                            type="text" 
                                            id="business_type" 
                                            required
                                            placeholder='Enter your Business Type' 
                                            value={businessTypeField}
                                            onChange={(e)=>setBusinessType(e.target.value)}
                                            className={errors.businessType ? 'error' : ''}
                                            />
                                        {errors.businessType && <span className="error-message">{errors.businessType}</span>}
                                    </div>
                                    <div className='form-group'>
                                        <label htmlFor="password">Tax Identififcation</label>
                                        <input 
                                            type="text" 
                                            id="tax_identififcation" 
                                            required
                                            placeholder='Enter your Tax Identififcation' 
                                            value={tax_dentification_Field}
                                            onChange={(e)=>setTaxIdentification(e.target.value)}
                                            className={errors.taxIdentification ? 'error' : ''}
                                            />
                                        {errors.taxIdentification && <span className="error-message">{errors.taxIdentification}</span>}
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
                                            value={driverLicenseField}
                                            onChange={(e)=>setDriverLicense(e.target.value)}
                                            className={errors.driversLicense ? 'error' : ''}
                                            />
                                        {errors.driversLicense && <span className="error-message">{errors.driversLicense}</span>}
                                    </div>  
                                    <div className='form-group'>
                                        <label htmlFor="password">License Expiry Date</label>
                                        <input 
                                            type="date" 
                                            id="license_expiry" 
                                            required
                                            placeholder='Enter your License Expiry Date' 
                                            value={licenseExpiryField}
                                            onChange={(e)=>setLicenseExpiry(e.target.value)}
                                            className={errors.licenseExpiry ? 'error' : ''}
                                            />
                                        {errors.licenseExpiry && <span className="error-message">{errors.licenseExpiry}</span>}
                                    </div>   
                                </div>           
                            )}
                            <div className='form-group checkbox-group'>
                                <label className="checkbox-label">
                                    <input 
                                        type='checkbox' 
                                        id="termsofagreement"
                                        checked={termsAccepted}
                                        onChange={(e) => setTermsAccepted(e.target.checked)}
                                        // className={errors.termsAccepted ? 'error' : ''}
                                    />
                                    <span>I agree to the Terms of Service and Privacy Policy</span>
                                </label>
                                {/* {errors.termsAccepted && <span className="error-message">{errors.termsAccepted}</span>} */}
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
                        
            {openEmailRequest &&
                <div className='email-requester-div'>
                    <RequestEmail 
                        openEmail={openEmailRequest}
                        setOpenEmail={setEmailRequest}/>
                </div>
            }          

            
            {openPasswordChanger &&
                <div className='password-changer-div'>
                    <PasswordChanger 
                        openPassword={openPasswordChanger}
                        setOpenPassword={setPasswordChanger}
                    />
                </div>
            }
            
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
}
export default Registration