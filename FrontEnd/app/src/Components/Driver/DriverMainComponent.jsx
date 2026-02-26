import './DriverStyles.css'
import WorldIcon from "../Icons/world-alt-svgrepo-com.svg"
import TruckIcon from "../Icons/truck-svgrepo-com.svg"
import { useNavigate } from 'react-router-dom'
import {useState} from 'react'
import Dashboard from './Dashboard'
import ActiveOrder from './ActiveOrder'
import Notifications from './Notification'
import Profile from './Profile'
import Routes from './Routes'

const DriverMainComponent=()=>{
    const navigate = useNavigate()
    const [activateDashboard, setDashboard] = useState(true);
    const [activateActiveOrders, setActiveOrders] = useState(false);
    const [activateRoutes, setRoutes] = useState(false);
    const [activateNotifications, setNotifications] = useState(false);
    const [activateProfile, setProfile] = useState(false);


    const LogOut=()=>{
        navigate('/mainpage')
    }

    const handleDashboardActivation=()=>{
        setDashboard(true)
        setActiveOrders(false)
        setRoutes(false)
        setNotifications(false)
        setProfile(false)
    }
    const handleActivateOrderActivation=()=>{
        setDashboard(false)
        setActiveOrders(true)
        setRoutes(false)
        setNotifications(false)
        setProfile(false)
    }
    const handleRoutesActivation=()=>{
        setDashboard(false)
        setActiveOrders(false)
        setRoutes(true)
        setNotifications(false)
        setProfile(false)
    }
    const handleNotificationActivation=()=>{
        setDashboard(false)
        setActiveOrders(false)
        setRoutes(false)
        setNotifications(true)
        setProfile(false)
    }
    const handleProfileActivation=()=>{
        setDashboard(false)
        setActiveOrders(false)
        setRoutes(false)
        setNotifications(false)
        setProfile(true)
    }
    return(
        <div className='driver-component'>
            <div className="header-nav-driver">
                <div className='title-descript'>
                    <img  className='mytruck-icon'  src={TruckIcon} />
                    <h2>ClydeDelivery</h2>
                    <p className='driver-tag'>Driver</p>
                </div>
                
                <div className='language-dropdown'>
                    <div>
                        {/* <img className='myword-icon' src={WorldIcon}/> */}
                        <select id="language">
                            <option selected>us English</option>
                            <option>ru Russian</option>
                        </select> 
                    </div>                    
                    <button onClick={()=>LogOut()} className="logout-driver">Logout</button>
                </div>
                
            </div>
            <div className='driver-main-component'>
                <div className='sub-nav'>
                    <nav onClick={()=>handleDashboardActivation()}>Dashboard</nav>
                    <nav onClick={()=>handleActivateOrderActivation()}>Active Orders</nav>
                    <nav onClick={()=>handleRoutesActivation()}>Routes</nav>
                    <nav onClick={()=>handleNotificationActivation()}>Notifications</nav>
                    <nav onClick={()=>handleProfileActivation()}>Profile</nav>
                </div>
            
                {activateDashboard && (
                    <Dashboard/>
                )}
                {activateActiveOrders && (
                    <ActiveOrder/>
                )}
                {activateRoutes && (
                    <Routes/>
                )}
                {activateNotifications && (
                    <Notifications/>
                )}
                {activateProfile && (
                    <Profile/>
                )}
            </div>
          
            {/* <div className="dashboard"></div> 
            <div className="active-order"></div>  
            <div className="earnings"></div> 
            <div className="notifications"></div> 
            <div className="profile"></div>                   */}
        </div>
    )
}
export default DriverMainComponent