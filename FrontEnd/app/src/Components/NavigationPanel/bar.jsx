import React from 'react'
import { Truck, Package, Users, Globe, Shield, Clock, Star, CheckCircle, MapPin } from 'lucide-react';
import './bar.css'

const Bar=()=>{
    return(
        <div className='header-container'>
            <div className='logo-container'>
                {/* <div className='logo'>
                    <Truck className='logo-icon'/>
                </div> */}
                 <h1 className="text-xl text-gray-900">DeliveryMatch</h1>
            </div>
            <div className="get-startedbtn">
                <button>Get Started</button>
            </div>
        </div>
    );
}

export default Bar