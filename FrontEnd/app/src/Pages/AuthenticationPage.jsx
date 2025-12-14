import React from 'react'
import NavigationBar from '../Components/NavigationPanel/bar.jsx'
import RegistrationPage from '../Components/Authentication/Auth.jsx'
const AuthPage=()=>{
    return(
        <div>
            <NavigationBar/>
            <RegistrationPage/>
        </div>             
    )
}

export default AuthPage;