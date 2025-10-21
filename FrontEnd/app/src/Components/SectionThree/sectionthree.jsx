import React from 'react'
import './sectionthree.css'


const SectionThree =()=> {

    const forcustomers = [
        {number:"1", title : "Create Request", simpleDescription:"Enter pickup & delivery details"},
        {number:"2", title : "Get Matched", simpleDescription:"AI finds the best driver for you"},
        {number:"3", title : "Track & Receive", simpleDescription:"Real-time updates until delivery"},
    ]

    const fordrivers =[
        {number:"1", title : "Sign Up & Verify", simpleDescription:"Upload documents & vehicle info"},
        {number:"2", title : "Get Orders", simpleDescription:"Accept nearby delivery requests"},
        {number:"3", title : "Earn Money", simpleDescription:"Complete deliveries & get paid"},
    ]
    return(
       <div className='SectionThreeBody'>
            <h2>How It Works</h2>
            <p>Simple steps to get your delivery moving</p>
            <div className='CustomerAndDrivers'>
                <div className='forcustomers'>
                    <h3>For Customers</h3>
                    {forcustomers.map((customer,index)=>(
                        <div key={index} className="choicesNew">
                            <span>{customer.number}</span>
                            <div>
                                <strong>{customer.title}</strong>
                                <p>{customer.simpleDescription}</p>
                            </div>
                        </div>                        
                    ))}
                </div>                  

                <div className='fordrivers'>
                    <h3>For Drivers</h3>
                     {fordrivers.map((driver,index)=>(
                        <div key={index} className="choicesOld">
                            <span>{driver.number}</span>
                            <div>
                                <strong>{driver.title}</strong>
                                <p>{driver.simpleDescription}</p>
                            </div>
                        </div>                        
                    ))}
                </div>
            </div>
       </div>
    );
}
export default SectionThree