import './ClientStyles.css'
import WorldIcon from "../Icons/world-alt-svgrepo-com.svg"
import TruckIcon from "../Icons/truck-svgrepo-com.svg"
import { useNavigate } from 'react-router-dom'
import {useState} from 'react'
import Profile from './Profile'
import NewOrder from './NewOrder'
import Notifications from './Notification'
import TrackOrders from './TrackOrder'
import FindDriver from './FindDrivers'
import BulkOrders from './BulkOrders'


const ClientMainComponent=()=>{
    const navigate = useNavigate()
    const [activateActiveOrders, setActiveOrders] = useState(false);
    const [trackOrder, setTrackOrder] = useState(false);
     const [findDriver, setFindDriver] = useState(false);
    const [notifications, setNotifications] = useState(false);
    const [profile, setProfile] = useState(false);
    const [neworder, setNewOrder] = useState(false);
    const [bulkorders, setBulkOrders] = useState(false);


    const LogOut=()=>{
        navigate('/mainpage')
    }

    const handleProfile=()=>{
        setProfile(true)
        setTrackOrder(false)
        setFindDriver(false)
        setNotifications(false)
        setNewOrder(false)
        setBulkOrders(false)  
    }
    const handleNewOrder=()=>{
        setNewOrder(true)
        setProfile(false)
        setTrackOrder(false)
        setFindDriver(false)
        setNotifications(false) 
        setBulkOrders(false)       
    }
    const handleTrackOrders=()=>{
        setTrackOrder(true)
        setNewOrder(false)
        setProfile(false)        
        setFindDriver(false)
        setNotifications(false)  
        setBulkOrders(false)  
    }
    const handleFindDrivers=()=>{
        setFindDriver(true)
        setTrackOrder(false)
        setNewOrder(false)
        setProfile(false)    
        setNotifications(false) 
        setBulkOrders(false)   
    }
    const handleNotification=()=>{
        setNotifications(true) 
        setFindDriver(false)
        setTrackOrder(false)
        setNewOrder(false)
        setProfile(false)
        setBulkOrders(false)            
    }
    const handleBulkOrders=()=>{
        setBulkOrders(true)
        setNotifications(false) 
        setFindDriver(false)
        setTrackOrder(false)
        setNewOrder(false)
        setProfile(false)            
    }
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
                <nav onClick={()=>handleProfile()}>Profile</nav>
                <nav onClick={()=>handleNewOrder()}>New Booking</nav>
                   <nav onClick={()=>handleBulkOrders()}>Bulk Upload</nav>
                <nav onClick={()=>handleTrackOrders()}>Track Orders</nav>
                <nav onClick={()=>handleFindDrivers()}>Find Drivers</nav>
                {/* <nav onClick={()=>handleNotification()}>Notification</nav> */}
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
                <FindDriver/>
            )}
             {bulkorders&&(
                <BulkOrders/>
            )}
        </div>
    )
}
export default ClientMainComponent