import { useEffect,useState } from "react"
import TruckIcon from "../Icons/2truck-svgrepo-com.svg"
import PickUpIcon from "../Icons/pickup-location-pin-svgrepo-com.svg"
import DeliveryIcon from "../Icons/delivery-location-marker-svgrepo-com.svg"
import axios from "axios"
import './OrderViews.css'


const OrderViews=({orderPlacementId})=>{
    const [order, setOrder] = useState(null)
    const urlGetOrdePlacement = "https://localhost:7216/api/OrderPlacement/Get-Order-Single-Record-Placements-By-Id"
    const urlGetCustomer = "https://localhost:7216/api/Customer/Get-GetCustomerDetails-By-Id"
    const urlGetUser = "https://localhost:7216/api/User/Get-Users-By-Id"

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
                
                const userInformation = {
                    Order:response.data,
                    Customer:customer.data,
                    User:user.data
                }
                setOrder(userInformation)   
                console.log("USER", userInformation)        
            }           
        }
        catch(e){
            console.log("ERROR MESSAGE", e.Message)
        }

    }

     const getProgressInfo = (status) => {
        const progressMap = {
            'Pending': { percentage: 25, steps: ['Pending', 'InTransit', 'Delivered'], currentStep: 0 },
            'In Transit': { percentage: 66, steps: ['Pending', 'InTransit', 'Delivered'], currentStep: 1 },
            'Delivered': { percentage: 100, steps: ['Pending', 'InTransit', 'Delivered'], currentStep: 2 },
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
                completed: order?.Order?.Status === "In Transit" || order?.Order?.Status === "Delivered",
                date: order?.Order?.Scheduled_At,
                description: "Driver picked up the package"
            },
            { 
                label: "In Transit", 
                completed: order?.Order?.Status === "In Transit" || order?.Order?.Status === "Delivered",
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


    useEffect(()=>{
        getOrderPlacements()         
    },[orderPlacementId])
    return(
        <div className="each-order-line-track-order">    
            {order ? (
                <div className="order-details-container">
                    <div className="order-header">
                        <div>
                            <img src={TruckIcon} className="truck2-icon" alt="" />
                            <p>Order ORD-{orderPlacementId}</p>
                        </div>                      

                        <span className={`status-badge status-${order.Order.Status.toLowerCase()}`}>
                                {order.Order.Status}
                        </span>
                    </div>

                    <div className="customer-info">
                        <div className="customer-header">
                            <div className="customer-avatar">
                                {order.User.First_Name?.charAt(0).toUpperCase()}
                                {order.User.Last_Name?.charAt(0).toUpperCase()}
                            </div>
                            <div className="customer-details">
                                <p className="customer-name">
                                    {order.User.First_Name} {order.User.Last_Name}
                                </p>
                                <p className="business-name">
                                    <strong>Business:</strong> {order.Customer.Business_Name}
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
                        <div className="progress-percentage">
                            {getProgressInfo(order.Order.Status).percentage}%
                        </div>
                    </div>

                    {order.Order.Status === 'Cancelled' && (
                            <div className="cancelled-message">
                                <div className="step-indicator cancelled">✕</div>
                                <span className="step-label cancelled">Order Cancelled</span>
                            </div>
                    )}
                    <div className="border-line"></div>
                    <div className="order-meta">
                        <div>
                            <img src={PickUpIcon} alt="" /><strong>Pickup Address:</strong><p>{order.Order.Pick_Up_Address}</p>
                        </div>
                        <div>
                            <img src={DeliveryIcon} alt="" /><strong>Delivery Address:</strong> <p>{order.Order.Delivery_Up_Address}</p>
                        </div>                        
                    </div>
                    
                    <div className="border-line"></div> 
                    <div className="item-details">
                        <div>
                            <p>Weight</p>
                            <strong>{order.Order.Weight} kg</strong>
                        </div>
                        <div>
                            <p>Volume</p>
                            <strong>{order.Order.Weight} m³</strong>
                        </div>
                        <div>
                            <p>Cost</p>
                            <strong className="cost">${order.Order.Price}</strong>
                        </div>
                        <div>
                            <p>Status</p>
                            <strong>{order.Order.Status}</strong>
                        </div>
                    </div> 
                    <div className="border-line"></div>
              
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
                </div>                          
                          
                ):(
                    <p>Loading order data...</p>
                )}
        </div>
    )

}
export default OrderViews;