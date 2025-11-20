import React from 'react'
import { useNavigate } from 'react-router-dom';
import './sectionfour.css'


const SectionFour=()=>{
    const navigate = useNavigate()
    const navigateToAuthPage =()=>{
        navigate('/authpage')
    }
    return(
       <div className='sectionFourBody'>
            <h2>Ready to Get Started?</h2>
            <p>Join thousands of customers and drivers who trust DeliveryMatch for their delivery needs.</p>
            <button onClick={()=>navigateToAuthPage()}>Start Your First Delivery</button>
       </div>
    );
}
export default SectionFour

