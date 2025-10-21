import React from 'react'
import './sectiontwo.css'


const SectionTwo=()=>{
  
    return(
        <div className='sectionTwoBody'>
            <h2 >Why Choose DeliveryMatch?</h2>
            <p>Built for efficiency, designed for scale. 
                Our platform revolutionizes how goods move from point A to point B.</p>

            <div className="cardSectionGrid">
            {/* Card 1 */}
            <div className="card">
                <div className="card-content">
                <div className="icon-container">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="icon text-blue-600">
                    <path d="M14 18V6a2 2 0 0 0-2-2H4a2 2 0 0 0-2 2v11a1 1 0 0 0 1 1h2"></path>
                    <path d="M15 18H9"></path>
                    <path d="M19 18h2a1 1 0 0 0 1-1v-3.65a1 1 0 0 0-.22-.624l-3.48-4.35A1 1 0 0 0 17.52 8H14"></path>
                    <circle cx="17" cy="18" r="2"></circle>
                    <circle cx="7" cy="18" r="2"></circle>
                    </svg>
                </div>
                <h3 className="title">Smart Matching</h3>
                <p className="description">AI-powered algorithm matches orders with the most suitable drivers based on capacity, location, and route optimization.</p>
                </div>
            </div>

            {/* Card 2 */}
            <div className="card">
                <div className="card-content">
                <div className="icon-container">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="icon text-green-600">
                    <path d="M11 21.73a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73z"></path>
                    <path d="M12 22V12"></path>
                    <polyline points="3.29 7 12 12 20.71 7"></polyline>
                    <path d="m7.5 4.27 9 5.15"></path>
                    </svg>
                </div>
                <h3 className="title">Bulk Orders</h3>
                <p className="description">Upload multiple deliveries via Excel and get optimized route planning that saves time and fuel costs.</p>
                </div>
            </div>

            {/* Card 3 */}
            <div className="card">
                <div className="card-content">
                <div className="icon-container">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="icon text-purple-600">
                    <path d="M20 10c0 4.993-5.539 10.193-7.399 11.799a1 1 0 0 1-1.202 0C9.539 20.193 4 14.993 4 10a8 8 0 0 1 16 0"></path>
                    <circle cx="12" cy="10" r="3"></circle>
                    </svg>
                </div>
                <h3 className="title">Real-time Tracking</h3>
                <p className="description">Track your deliveries in real-time with live GPS updates and instant notifications.</p>
                </div>
            </div>

            {/* Card 4 */}
            <div className="card">
                <div className="card-content">
                <div className="icon-container">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="icon text-orange-600">
                    <path d="M20 13c0 5-3.5 7.5-7.66 8.95a1 1 0 0 1-.67-.01C7.5 20.5 4 18 4 13V6a1 1 0 0 1 1-1c2 0 4.5-1.2 6.24-2.72a1.17 1.17 0 0 1 1.52 0C14.51 3.81 17 5 19 5a1 1 0 0 1 1 1z"></path>
                    </svg>
                </div>
                <h3 className="title">Secure & Reliable</h3>
                <p className="description">Verified drivers, secure payments, and comprehensive insurance coverage for peace of mind.</p>
                </div>
            </div>
            </div>
        </div>
    );
}
export default SectionTwo

