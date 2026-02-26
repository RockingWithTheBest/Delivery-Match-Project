import './ClientStyles.css'
import WorldIcon from "../Icons/world-alt-svgrepo-com.svg"
import TruckIcon from "../Icons/truck-svgrepo-com.svg"
import { useNavigate } from 'react-router-dom'
import {useEffect, useState} from 'react'
import Profile from './Profile'
import NewOrder from './NewOrder'
import Notifications from './Notification'
import TrackOrders from './TrackOrder'
import OrderViewOnMap from './OrderViewOnMap'
import BulkOrders from './BulkOrders'


const ClientMainComponent=()=>{
    const navigate = useNavigate()
    const [activateActiveOrders, setActiveOrders] = useState(false);
    const [trackOrder, setTrackOrder] = useState(false);
    const [findDriver, setFindDriver] = useState(false);
    const [notifications, setNotifications] = useState(false);
    const [profile, setProfile] = useState(true);
    const [neworder, setNewOrder] = useState(false);
    const [bulkorders, setBulkOrders] = useState(false);
    const [activeNav, setActiveNav] = useState('Profile');


    const LogOut=()=>{
        navigate('/mainpage')
    }

    const handleProfile=()=>{
        setActiveNav('Profile');
        setProfile(true)
        setTrackOrder(false)
        setFindDriver(false)
        setNotifications(false)
        setNewOrder(false)
        setBulkOrders(false)  
    }
    const handleNewOrder=()=>{
        setActiveNav('New Booking');
        setNewOrder(true)
        setProfile(false)
        setTrackOrder(false)
        setFindDriver(false)
        setNotifications(false) 
        setBulkOrders(false)       
    }
    const handleTrackOrders=()=>{
        setActiveNav('Track Orders');
        setTrackOrder(true)
        setNewOrder(false)
        setProfile(false)        
        setFindDriver(false)
        setNotifications(false)  
        setBulkOrders(false)  
    }
    const handleOrderMapView=()=>{
        setActiveNav('Order Map View');
        setFindDriver(true)
        setTrackOrder(false)
        setNewOrder(false)
        setProfile(false)    
        setNotifications(false) 
        setBulkOrders(false)   
    }
    const handleNotification=()=>{
        setActiveNav('Notification');
        setNotifications(true) 
        setFindDriver(false)
        setTrackOrder(false)
        setNewOrder(false)
        setProfile(false)
        setBulkOrders(false)            
    }
    const handleBulkOrders=()=>{
        setActiveNav('Bulk Upload');
        setBulkOrders(true)
        setNotifications(false) 
        setFindDriver(false)
        setTrackOrder(false)
        setNewOrder(false)
        setProfile(false)            
    }
    useEffect(()=>{
        console.log("BOY")
    })
    return(
        <div className='client-component'>
            <div className="header-nav">
                <div className='title-descript'>
                    <img  className='mytruck-icon'  src={TruckIcon} />
                    <h2>DeliveryMatch</h2>
                    <p className='driver-tag'>Client</p>
                </div>
                
                <div className='language-dropdown'>
                    <div className='world-lang'>
                        <img className='myword-icon' src={WorldIcon}/>
                        <select id="language">
                            <option selected>us English</option>
                            <option>ru Russian</option>
                        </select> 
                    </div>                    
                    <button onClick={()=>LogOut()} className="logout-driver">Logout</button>
                </div>
                
            </div>
            <div className='sub-nav'>
                <nav 
                    className={activeNav === 'Profile' ? 'active' : ''} 
                    onClick={()=>handleProfile()}
                >
                    {activeNav === 'Profile' && <span className="nav-indicator"></span>}
                    Profile
                </nav>

                <nav 
                    className={activeNav === 'New Booking' ? 'active' : ''} 
                    onClick={()=>handleNewOrder()}
                >
                    {activeNav === 'New Booking' && <span className="nav-indicator"></span>}
                    New Booking
                </nav>

                <nav 
                    className={activeNav === 'Bulk Upload' ? 'active' : ''} 
                    onClick={()=>handleBulkOrders()}
                >
                    {activeNav === 'Bulk Upload' && <span className="nav-indicator"></span>}
                    Bulk Upload
                </nav>

                <nav 
                    className={activeNav === 'Track Orders' ? 'active' : ''}
                    onClick={()=>handleTrackOrders()}
                >
                    {activeNav === 'Track Orders' && <span className="nav-indicator"></span>}
                    Track Orders
                </nav>

                <nav 
                    className={activeNav === 'Order Map View' ? 'active' : ''}
                    onClick={()=>handleOrderMapView()}
                >
                    {activeNav === 'Order Map View' && <span className="nav-indicator"></span>}
                    Order Map View
                </nav>
            </div>
            
            {neworder && (
                <NewOrder/>
            )}
            {notifications && (
                <Notifications/>
            )}
            {profile && (
                <Profile/>
            )}
            {trackOrder&&(
                <TrackOrders/>
            )}
            {findDriver&&(
                <OrderViewOnMap/>
            )}
             {bulkorders&&(
                <BulkOrders/>
            )}
        </div>
    )
}
export default ClientMainComponent