import { useEffect,useState } from "react"
import TruckIcon from "../Icons/2truck-svgrepo-com.svg"
import PickUpIcon from "../Icons/pickup-location-pin-svgrepo-com.svg"
import DeliveryIcon from "../Icons/delivery-location-marker-svgrepo-com.svg"
import axios from "axios"
import './OrderViews.css'
import { useParams } from "react-router-dom"


const OrderViews=({orderPlacementId})=>{
    const [order, setOrder] = useState(null)
    const url = "https://localhost:7216/api"
    const {ClientId} = useParams()
    const [loading, setLoading]=useState("")

    console.log("orderPlacementId",orderPlacementId)

    const getOrderPlacements=async()=>{
        if(!orderPlacementId) return;
        
        setLoading(true)
        try{          
            if(orderPlacementId!=null){
                const response = await axios.get(`${url}/OrderPlacement/Get-Order-Single-Record-Placements-By-Id`, {
                    params:{
                        id:parseInt(orderPlacementId)
                    }
                })

                    const customer = await axios.get(`${url}/Customer/Get-GetCustomerDetails-By-Id`,{
                        params:{
                            id:parseInt(response.data.CustomerId)
                        }
                    })

                    const user = await axios.get(`${url}/User/Get-Users-By-Id`,{
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
            }           
        }
        catch(e){
            console.log("ERROR MESSAGE", e)
        }
        finally{
            setLoading(false)
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

    const truncateText = (text, maxLength) => {
        if (!text) return text;
        return text.length > maxLength ? text.substring(0, maxLength) + '...' : text;
    };

    useEffect(()=>{
        getOrderPlacements()      
    },[orderPlacementId])

    return(
        <div className="each-order-line-track-order">    
            {orderPlacementId ? (
                order ? (
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
                            {/* <span className={`status-badge status-${order.Order.Status.toLowerCase()}`}>
                                {order.Order.Status}
                            </span> */}
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
                        <div className="PickUpAddress-div">
                            <img src={PickUpIcon} alt="" /><strong>Pickup Address:</strong><p className="PickUpAddress">{order.Order.PickUpAddress}</p>
                        </div>
                        <div>
                            <img src={DeliveryIcon} alt="" />
                            <strong>Delivery Address:</strong> 
                            <p className="DeliveryUpAddress">
                                {truncateText(order.Order.DeliveryUpAddress,100)}
                            </p>
                        </div>                        
                    </div>
                    
                    <div className="border-line"></div> 
                    <div className="item-details">
                        <div>
                            <p>Weight</p>
                            <strong>{order.Order.OrderItems.WeightPerItem.toFixed(2)} kg</strong>
                        </div>
                        <div>
                            <p>Volume</p>
                            <strong>{(order.Order.OrderItems.OrderDimension.Height*order.Order.OrderItems.OrderDimension.Width*order.Order.OrderItems.OrderDimension.Length).toFixed(2)} m³</strong>
                        </div>
                        <div>
                            <p>Cost</p>
                            <strong className="cost">₽{order.Order.Price.toFixed(2)}</strong>
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
                )
            ):(
                <div className="no-order-selected">
                    <img src="" alt="" />
                    <h3>No Order Selected</h3>
                    <p>Please select an order from the list</p>
                </div>
            )}
        </div>
    )

}
export default OrderViews;