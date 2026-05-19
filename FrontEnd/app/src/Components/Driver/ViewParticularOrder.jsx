import { useEffect,useState } from "react"
import TruckIcon from "../Icons/2truck-svgrepo-com.svg"
import PickUpIcon from "../Icons/pickup-location-pin-svgrepo-com.svg"
import DeliveryIcon from "../Icons/delivery-location-marker-svgrepo-com.svg"
import axios from "axios"
import OrderNotYetSelectedIcon from "./Icons/no-order-selected-yet.png"
import { format } from 'date-fns';
import './ViewParticularOrder.css'


const ViewParticularOrder=({orderPlacementId})=>{
    
    const [order, setOrder] = useState(null)
    const [isActiveConfirmed, setIsActiveConfirmed] = useState(false); // Default: inactive
    const [isActivePending, setIsActivePending] = useState(false);
    const [isActiveInTransit, setIsActiveInTransit] = useState(false);
    const [isActiveDelivered, setIsActiveDelivered] = useState(false);
    const [isActiveCancelled, setIsActiveCancelled] = useState(false);
        const [statuses, setStatuses] = useState({
        confirmed: false,
        pending: false,
        inTransit: false,
        delivered: false,
        cancelled: false
    });

        const getStatusIcon = (status) => {
        const icons = {
            'pending': '⏳',
            'confirmed': '✅',
            'intransit': '🚚',
            'delivered': '📦',
            'cancelled': '❌'
        };
        return icons[status?.toLowerCase()] || '📋';
    };

    const handleToggle = (status) => {
        setStatuses(prev => ({
            ...prev,
            [status]: !prev[status]
        }));
    };

    const urlGetOrdePlacement = "https://localhost:7216/api/OrderPlacement/Get-Order-Single-Record-Placements-By-Id"
    const urlGetCustomer = "https://localhost:7216/api/Customer/Get-GetCustomerDetails-By-Id"
    const urlGetUser = "https://localhost:7216/api/User/Get-Users-By-Id"
    const url = "https://localhost:7216/api"


    const handleConfirmedToggle=()=>{
            setIsActiveConfirmed(true)
            setIsActivePending(false)
            setIsActiveInTransit(false)
            setIsActiveDelivered(false)
            setIsActiveCancelled(false)
                        // Here you can also make an API call to update the driver status in your backend
            //console.log(`Driver status changed to: ${!isActiveConfirmed ? 'Active' : 'Inactive'}`);
            updatingStatus('Confirmed')
    }
    
    const handlePendingToggle=()=>{
             setIsActiveConfirmed(false)
            setIsActivePending(true)
            setIsActiveInTransit(false)
            setIsActiveDelivered(false)
            setIsActiveCancelled(false)
                        // Here you can also make an API call to update the driver status in your backend
            //console.log(`Driver status changed to: ${!isActiveConfirmed ? 'Active' : 'Inactive'}`);
            updatingStatus('Pending')
    }
 
    const handleInTransitToggle=()=>{
            setIsActiveConfirmed(false)
            setIsActivePending(false)
            setIsActiveInTransit(true)
            setIsActiveDelivered(false)
            setIsActiveCancelled(false)
                        // Here you can also make an API call to update the driver status in your backend
            //console.log(`Driver status changed to: ${!isActiveConfirmed ? 'Active' : 'Inactive'}`);
            updatingStatus('In-Transit')
    }
    
    const handleDeliveredToggle=()=>{
            setIsActiveConfirmed(false)
            setIsActivePending(false)
            setIsActiveInTransit(false)
            setIsActiveDelivered(true)
            setIsActiveCancelled(false)
                        // Here you can also make an API call to update the driver status in your backend
            //console.log(`Driver status changed to: ${!isActiveConfirmed ? 'Active' : 'Inactive'}`);
            updatingStatus('Delivered')
    }
    
    const handleCancelledToggle=()=>{
            setIsActiveConfirmed(false)
            setIsActivePending(false)
            setIsActiveInTransit(false)
            setIsActiveDelivered(false)
            setIsActiveCancelled(true)

            // Here you can also make an API call to update the driver status in your backend
            //console.log(`Driver status changed to: ${!isActiveConfirmed ? 'Active' : 'Inactive'}`);
            updatingStatus('Cancelled')
    }

    const updatingStatus=async(avail_parameter)=>{
        try{
            const getResponse = await axios.get(`${url}/OrderPlacement/Get-Order-Single-Record-Placements-By-Id`,{
                params:{
                    id:parseInt(orderPlacementId)
                }
            })
            
            if(avail_parameter === 'Delivered'){
                const currentDateTime = new Date();
                const formattedDateTime = format(currentDateTime, 'yyyy-MM-dd HH:mm:ss')
                
                const orderPlacement = {
                    CompletedOn:`${formattedDateTime}.0000000`,
                    CreatedAt:getResponse.data.CreatedAt,
                    CustomerId:getResponse.data.CustomerId,
                    DeliveryContact:getResponse.data.DeliveryContact,
                    DeliveryUpAddress:getResponse.data.DeliveryUpAddress,
                    Description:getResponse.data.Description,
                    DriverId:getResponse.data.DriverId,
                    PickUpAddress:getResponse.data.PickUpAddress,
                    PickUpContact:getResponse.data.PickUpContact,
                    Price:getResponse.data.Price,
                    ScheduledAt:getResponse.data.ScheduledAt,
                    Status:avail_parameter
                }
                
                const response = await axios.put(`${url}/OrderPlacement/Editing-Order-PlacementAddresses`,orderPlacement,{
                    params:{
                        Id:parseInt(orderPlacementId)
                    }
                })
            }
            else{
                const currentDateTime = new Date();
                const formattedDateTime = format(currentDateTime, 'yyyy-MM-dd HH:mm:ss')
                const orderPlacement = {
                    CompletedOn:getResponse.data.CompletedOn,
                    CreatedAt:getResponse.data.CreatedAt,
                    CustomerId:getResponse.data.CustomerId,
                    DeliveryContact:getResponse.data.DeliveryContact,
                    DeliveryUpAddress:getResponse.data.DeliveryUpAddress,
                    Description:getResponse.data.Description,
                    DriverId:getResponse.data.DriverId,
                    PickUpAddress:getResponse.data.PickUpAddress,
                    PickUpContact:getResponse.data.PickUpContact,
                    Price:getResponse.data.Price,
                    ScheduledAt:`${formattedDateTime}.0000000`,
                    Status:avail_parameter
                }

                const response = await axios.put(`${url}/OrderPlacement/Editing-Order-PlacementAddresses`,orderPlacement,{
                    params:{
                        Id:parseInt(orderPlacementId)
                    }
                })
            }
 
        }
        catch (error) {
            console.error('Upload failed:', error);
        }
    }

    const getOrderPlacements=async()=>{
        try{          
            if(orderPlacementId!=null){
 
                const response = await axios.get(urlGetOrdePlacement, {
                    params:{
                        id:parseInt(orderPlacementId)
                    }
                })

                const customer = await axios.get(urlGetCustomer,{
                    params:{
                        id:parseInt(response.data.CustomerId)
                    }
                })

                const user = await axios.get(urlGetUser,{
                    params:{
                        id:parseInt(customer.data.UserId)
                    }
                })
                
                const items =  await axios.get(`${url}/OrderItems/Get-All-OrderItems`)
                const orderItems = items.data.filter(o=>o.OrderPlacementId == orderPlacementId)

                const userInformation = {
                    Order:response.data,
                    Customer:customer.data,
                    User:user.data,
                    item: orderItems[0]
                }
                setOrder(userInformation)         
            }           
        }
        catch(e){
            console.log("ERROR MESSAGE", e.message)
        }
    }

     const getProgressInfo = (status) => {
        const progressMap = {
            'Confirmed': { percentage: 10, steps: ['Confirmed','Pending', 'In-Transit', 'Delivered'], currentStep: 0 },
            'Pending': { percentage: 25, steps: ['Confirmed','Pending', 'In-Transit', 'Delivered'], currentStep: 1 },
            'In-Transit': { percentage: 66, steps: ['Confirmed','Pending', 'In-Transit', 'Delivered'], currentStep: 2 },
            'Delivered': { percentage: 100, steps: ['Confirmed','Pending', 'In-Transit', 'Delivered'], currentStep: 3 },
            'Cancelled': { percentage: 0, steps: ['Cancelled'], currentStep: 0 }
        };
        return progressMap[status] || { percentage: 0, steps: [], currentStep: 0 };
    }

    const getTimelineStatus = (order) => {
        const timelineSteps = [
            { 
                label: "Order Placed", 
                completed: true, // Always completed once order exists
                date: order?.Order?.Created_At,
                description: "Order was placed by customer"
            },
            { 
                label: "Assigned Driver", 
                completed: order?.Order?.DriverId != null,
                date: order?.Order?.Scheduled_At,
                description: "Driver assigned to delivery"
            },
            { 
                label: "Order Picked Up", 
                completed: order?.Order?.Status === "Pending" || order?.Order?.Status === "In-Transit" || order?.Order?.Status === "Delivered",
                date: order?.Order?.Scheduled_At,
                description: "Driver picked up the package"
            },
            { 
                label: "In-Transit", 
                completed: order?.Order?.Status === "In-Transit" || order?.Order?.Status === "Delivered",
                date: order?.Order?.Scheduled_At,
                description: "Package is on the way"
            },
            { 
                label: "Delivered", 
                completed: order?.Order?.Status === "Delivered",
                date: order?.Order?.Completed_On,
                description: "Package delivered successfully"
            }
        ];

        return timelineSteps;
    }

    const updateEachOrderStatus=async()=>{
        try{
            const response = await axios.get(`${url}/OrderPlacement/Get-Order-Single-Record-Placements-By-Id`,{
                params:{
                    id:parseInt(orderPlacementId)
                }
            })

            if((response.data.Status).toLowerCase() === 'confirmed'){
                handleConfirmedToggle()
            }

            if((response.data.Status).toLowerCase() === 'pending'){
                handlePendingToggle()
            }
             if((response.data.Status).toLowerCase() === 'in-transit'){
                handleInTransitToggle()
            }

            if((response.data.Status).toLowerCase() === 'cancelled'){
                handleCancelledToggle()
            }
            
            if((response.data.Status).toLowerCase() === 'delivered'){
                handleDeliveredToggle()
            }
        }
        catch(error){
            console.log("ERROR", error.message)
        }
    }

    const toggleItems = [
        { key: 'confirmed', label: 'Confirmed', icon: '' },
        { key: 'pending', label: 'Pending', icon: '⏳' },
        { key: 'in-Transit', label: 'In-Transit', icon: '🚚' },
        { key: 'delivered', label: 'Delivered', icon: '📦' },
        { key: 'cancelled', label: 'Cancelled', icon: '❌' }
    ];

    useEffect(()=>{
        getOrderPlacements() 
        // Set up interval to refresh every 2 seconds
        const intervalId = setInterval(() => {
            getOrderPlacements() 
            updateEachOrderStatus()
        }, 1000); // 2000ms = 2 seconds

        
        // Clean up interval on component unmount
        return () => clearInterval(intervalId);       
    },[orderPlacementId])

    return(
        <div className="each-order-line">    
            {order ? (
                <div className="order-details-container">
                    <div className="order-header">
                            <div>
                                <img src={TruckIcon} className="truck2-icon" alt="" />
                                <p>Order ORD - {orderPlacementId}</p>
                            </div>                      

                            <span className={`status-badge status-${order.Order.Status.toLowerCase()}`}>
                                    {order.Order.Status}
                            </span>
                    </div>


                    <div className="customer-info">
                        <div className="customer-header">
                            <div className="customer-avatar">
                                {order.User.FirstName?.charAt(0).toUpperCase()}
                                {order.User.LastName?.charAt(0).toUpperCase()}
                            </div>
                            <div className="customer-details">
                                <p className="customer-name">
                                    {order.User.FirstName} {order.User.LastName}
                                </p>
                                <p className="business-name">
                                    <strong>Business:</strong> {order.Customer.BusinessName}
                                </p>
                                {order.Customer.Rating && (
                                    <div className="customer-rating">
                                        <span className="rating-stars">{"★".repeat(Math.floor(parseFloat(order.Customer.Rating)))}</span>
                                        <span className="rating-value">{order.Customer.Rating}/5</span>
                                    </div>
                                )}
                            </div>
                        </div>
                    </div>

                    <div className="progress-section">
                        <div className="progress-header">
                            <h4>Delivery Progress</h4>
                            <span className={`status-badge status-${order.Order.Status.toLowerCase()}`}>
                                {order.Order.Status}
                            </span>
                        </div>
                    </div>

                    <div className="progress-bar-container">
                        <div 
                            className={`progress-bar ${order.Order.Status.toLowerCase()}`}
                            style={{ width: `${getProgressInfo(order.Order.Status).percentage}%` }}
                        >
                            <div className="progress-fill"></div>
                        </div>

                    </div>

                    {order.Order.Status === 'Cancelled' && (
                            <div className="cancelled-message">
                                <div className="step-indicator cancelled">✕</div>
                                <span className="step-label cancelled">Order Cancelled</span>
                            </div>
                    )}
                    <div className="border-line"></div>
                    <div className="order-meta-data">
                        <div>
                            <img src={PickUpIcon} alt="" /><span>Pickup Address:</span><p className="pick-up-address">{order.Order.PickUpAddress}</p>
                        </div>
                        <div>
                            <img src={DeliveryIcon} alt="" /><span>Delivery Address:</span> <p className="delivery-up-address">{order.Order.DeliveryUpAddress}</p>
                        </div>                        
                    </div>
                    
                    <div className="border-line"></div> 
                    <div className="item-details">
                        <div>
                            <p>Weight</p>
                            <span>{order.item.WeightPerItem} kg</span>
                        </div>
                        <div>
                            <p>Volume</p>
                            <span>{parseFloat(((order.item.OrderDimension.Height * order.item.OrderDimension.Length * order.item.OrderDimension.Width)/1000000).toFixed(4)) } m³</span>
                        </div>
                        <div>
                            <p>Cost</p>
                            <span className="cost">${order.Order.Price}</span>
                        </div>
                        <div>
                            <p>Status</p>
                            <span>{order.Order.Status}</span>
                        </div>
                    </div> 
                    <div className="border-line"></div>
              
                    <div className="showing-timeline">
                        <div className="actual-timeline">
                            <h3>Order Timeline</h3>
                            <div className="timeline-container">
                                {getTimelineStatus(order).map((step, index) => (
                                    <div key={step.label} className="timeline-step">
                                        <div className="timeline-content">
                                            <div className={`timeline-indicator ${step.completed ? 'completed' : 'pending'}`}>
                                                {step.completed ? (
                                                    <div className="checkmark">✓</div>
                                                ) : (
                                                    <div className="step-number">{index + 1}</div>
                                                )}
                                            </div>
                                            <div className="timeline-info">
                                                <p className="timeline-label">{step.label}</p>
                                                {step.date && (
                                                    <p className="timeline-date">
                                                        {new Date(step.date).toLocaleDateString()}
                                                    </p>
                                                )}
                                                <p className="timeline-description">{step.description}</p>
                                            </div>
                                        </div>
                                        {index < getTimelineStatus(order).length - 1 && (
                                            <div className={`timeline-connector ${step.completed ? 'completed' : ''}`}></div>
                                        )}
                                    </div>
                                ))}
                            </div>                   
                        </div>  
                        <div className="driver-timeline-controller">
                            <h2>
                                <span className="title-icon">⚡</span>
                                Driver timeline controller
                            </h2>
                            <div className="toggle-container">
                            
                                <div>
                                <span>Confirmed </span>
                                <label className="toggle-label">
                                        <input 
                                            type="checkbox" 
                                            checked={isActiveConfirmed}
                                            onChange={()=>handleConfirmedToggle()}
                                            className="toggle-input"
                                            aria-label={`Toggle ✅ status`}
                                        />
                                        <span className="toggle-slider">
                                            <span className="toggle-knob"></span>
                                        </span>
                                    </label>
                                </div>
                                
                                <div>
                                <span>Pending</span>
                                <label className="toggle-label">
                                        <input 
                                            type="checkbox" 
                                            checked={isActivePending}
                                            onChange={()=>handlePendingToggle()}
                                            className="toggle-input"
                                            aria-label={`Toggle ⏳ status`}
                                        />
                                        <span className="toggle-slider">
                                            <span className="toggle-knob"></span>
                                        </span>
                                    </label>
                                </div>

                                <div>
                                <span>In Transit</span>
                                <label className="toggle-label">
                                        <input 
                                            type="checkbox" 
                                            checked={isActiveInTransit}
                                            onChange={()=>handleInTransitToggle()}
                                            className="toggle-input"
                                            aria-label={`Toggle 🚚 status`}
                                        />
                                        <span className="toggle-slider">
                                            <span className="toggle-knob"></span>
                                        </span>
                                    </label>
                                </div>

                                <div>
                                <span>Delivered</span>
                                <label className="toggle-label">
                                        <input 
                                            type="checkbox" 
                                            checked={isActiveDelivered}
                                            onChange={()=>handleDeliveredToggle()}
                                            className="toggle-input"
                                            aria-label={`Toggle 📦 status`}
                                        />
                                        <span className="toggle-slider">
                                            <span className="toggle-knob"></span>
                                        </span>
                                    </label>
                                </div>

                                <div>
                                <span>Cancelled</span>
                                <label className="toggle-label">
                                        <input 
                                            type="checkbox" 
                                            checked={isActiveCancelled}
                                            onChange={()=>handleCancelledToggle()}
                                            className="toggle-input"
                                            aria-label={`Toggle ❌ status`}
                                        />
                                        <span className="toggle-slider">
                                            <span className="toggle-knob"></span>
                                        </span>
                                    </label>
                                </div>
                            </div>
                        </div>
                    <div className="active-statuses">
                        {Object.entries(statuses)
                            .filter(([_, value]) => value)
                            .map(([key]) => (
                                <span key={key} className={`status-badge ${key}`}>
                                    {toggleItems.find(item => item.key === key)?.icon} {key}
                                </span>
                            ))}
                    </div>
                    </div>              
                </div>                          
                          
                ):(
                    <div className="no-order-selected">
                        <h3>No Order Selected</h3>
                        <p>Please select an order from the list</p>
                        <img src={OrderNotYetSelectedIcon} alt="" />
                    </div>                   
                )}
        </div>
    )
}
export default ViewParticularOrder;