import React from 'react'
import Truck from './Icons/delivery-truck-svgrepo-com.svg'
import WorldIcon from "../Icons/world-alt-svgrepo-com.svg"
import { useNavigate } from 'react-router-dom'
import './bar.css'

const Bar=()=>{
    const navigate = useNavigate()

    const navigateToAuthenticationPage=()=>{
        navigate("/authpage")
    }
    return(
        <div className='header-container'>
            <div className='logo-container'>
                <img src={Truck} alt="" className="delivery-shipping-truck" />
                <p className="text-xl text-gray-900">ClydeDelivery</p>
            </div>
            
           <div className="get-startedbtn">
                <div className='language-dropdown-bar'>
                <div className='world-lang'>
                    <img className='myword-icon' src={WorldIcon}/>
                    <select id="language">
                        <option value="us" selected>us English</option>
                        <option value="ru" >ru Russian</option>
                    </select> 
                </div>                    
                </div>
                <div >
                    <button onClick={()=>navigateToAuthenticationPage()}>Get Started</button>
                </div>
           </div>
           
        </div>
    );
}

export default Bar

