import React from 'react'
import Car from './assets/car.png'
import './sectionone.css'


const SectionOne=()=>{

    const stats = [
    { number: "10K+", label: "Active Drivers" },
    { number: "50K+", label:"Deliveries Completed" },
    { number: "500+", label: "Cities Covered" },
    { number: "4.9★", label:"Average Rating" }
  ];
  
    return(
        <div>
            <section className='sectionOneBody'>
                <div className='whychoose'>
                    <span>Why Choose DeliveryMatch?</span>
                </div>
                <div className='smartdelivery'>
                    <h1>Smart Delivery Platform</h1>
                </div>
                <div>
                    <p className='connectionverified'>Connect with verified drivers for efficient goods delivery. 
                    From single packages to bulk shipments, our AI-powered platform 
                    optimizes routes and reduces costs.</p>
                    <div>
                        <button className='shipnow'>Ship Now</button>
                        <button className='driveearn'>Drive & Earn</button>
                    </div>                    
                </div>
                <div className="ratings">
                    {stats.map((stat,index)=>(
                        <div key={index} className="stat-item">
                            <span className="stat-number">{stat.number}</span>
                            <span className="stat-label">{stat.label}</span>
                        </div>
                    ))}
                </div>
                <div>
                    <img src={Car} alt="" />
                    
                    
                </div>
                <div  className="devlivered-check">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-check-big h-5 w-5 text-green-500">
                    <path d="M21.801 10A10 10 0 1 1 17 3.335"></path><path d="m9 11 3 3L22 4"></path></svg>
                    <span>Delivered</span>
                </div>
                <div className='live-tracking'>
                    <div class="green-circle"></div>
                    <span>Live Tracking</span>
                </div>
            </section>
        </div>
    );
}
export default SectionOne