import React, { useState, useEffect } from "react";
import './NewOrder.css'
import { useParams } from "react-router-dom";
// import ItemDetailsModal from './ItemDetailsModal'
import OrdersMap from "./OrdersMap";
import { format } from "date-fns";
import axios from "axios";

const NewOrder=()=>{
    const {ClientId} = useParams()
    const [pickupAddress, setPickUpAddress]=useState(null)
    const [deliveryAddress, setDeliverAddress]=useState(null)
    const [pickupContact, setPickUpContact]=useState(null)
    const [deliveryContact, setDeliveryContact]=useState(null)
    const [volume, setVolume]=useState(null)
    const [desciption, setDescription]=useState(null)
    const [status, setStatus]=useState("")
    const [createdAt, setCreatedAt]=useState(null)
    const [scheduledForDeliveryOn, setScheduledForDeliveryOn]=useState(null)
    const [price, setPrice]=useState(null)
    const [showItemModal, setShowItemModal] = useState(false);
    const [showOptimizationMap, setOptimizationMap] = useState(false);
    const [Order_PlacementId, setOrder_PlacementId] = useState(null)
    const [itemName, setItemName] = useState("");
    const [itemLength, setItemLength] = useState("");
    const [itemWidth, setItemWidth] = useState("");
    const [itemHeight, setItemHeight] = useState("");
    const [itemWeight, setItemWeight] = useState("");
    const [itemQuantity, setItemQuantity] = useState("");
    const [specialInstructions, setSpecialInstructions] = useState("");
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
    const url = "https://localhost:7216/api"

    const enterDetails = () => {
        setShowItemModal(true)
    };
    
     const handleCheckboxChange = (instruction) => {
        setSpecialInstructions(prev => ({
            ...prev,
            [instruction]: !prev[instruction]
        }));
    };

    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
      };

    const handleSubmit = async()=>{
        const currentDateTime = new Date();
        const formattedDateTime = format(currentDateTime, 'yyyy-MM-dd HH:mm:ss')

        try{
            const orderPlacements={
                PickUpAddress:pickupAddress,
                DeliveryUpAddress:deliveryAddress,
                PickUpContact:pickupContact,
                DeliveryContact:deliveryContact,
                Description:desciption,
                Status:status,
                Price:price,
                CreatedAt:`${formattedDateTime}.0000000`,
                ScheduledAt:scheduledForDeliveryOn,
                CustomerId:ClientId,
                OrderItems:{
                    ItemName:itemName,
                    Quantity:parseInt(itemQuantity),
                    SpecialInstructions:specialInstructions,
                    WeightPerItem:itemWeight,
                    orderDimension:{
                        Length:parseFloat(itemLength),
                        Height:parseFloat(itemHeight),
                        Width:parseFloat(itemWidth)
                    }
                }
            }
            const response = await axios.post(`${url}/OrderPlacement/Add-OrderPlacement`,orderPlacements)
            console.log("VALUES",response)
            setOrder_PlacementId(parseInt(response.data))
            showNotification("Successfully added order!", 'success')
            if(response){
                setCreatedAt("")
                setDeliverAddress("")
                setDeliveryContact("")
                setDescription("")
                setPickUpAddress("")
                setPickUpContact("")
                setPrice("")
                setScheduledForDeliveryOn("")
                setStatus("")
                setVolume("")
                setItemHeight("")
                setItemLength("")
                setItemName("")
                setItemQuantity("")
                setItemWeight("")
                setSpecialInstructions("")
                setStatus("")
                setItemWidth("")
            }          

       }
        catch(e){
            showNotification('Enter correct details please.', 'error');           
            console.log("Error", e.message)
        }
    }

    const callOptionizationPathMap=()=>{
        if(Order_PlacementId === null){
            showNotification('You can only place order after you add new order.', 'error'); 
        }
        else{
            setOptimizationMap(true);
        }    
    }

    useEffect(() => {
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);   


    return(
        <div className="new-order">
            
            <div className="new-order-header">
                <div>
                    <h2>New Delivery Booking</h2>
                    <p>Fill in the details of your delivery request</p>
                </div>
                <button onClick={()=>handleSubmit()} className="submit-new-order">
                    Add New Order
                </button>
                
            </div>
            
            <form onSubmit={handleSubmit}className="order-details-grid">
                    <div className="input-group">
                        <label htmlFor="">Pickup Address</label>
                        <input 
                            id="pickup-address"
                            type="text"
                            value={pickupAddress}
                            placeholder="Enter pick up address"
                            onChange={(e)=>setPickUpAddress(e.target.value)}
                            required
                        />
                    </div>
                    <div className="input-group">
                        <label htmlFor="">Delivery Address</label>
                        <input 
                            id="delivery-address"
                            type="text" 
                            value={deliveryAddress}
                            placeholder="Enter delivery address"
                            onChange={(e)=>setDeliverAddress(e.target.value)}
                            required
                        />
                    </div>
                    <div className="input-group">
                        <label htmlFor="">Pickup Contact</label>
                        <input
                            id="pickup-contact" 
                            type="number" 
                            value={pickupContact}
                            placeholder="Enter pick up contact"
                            onChange={(e)=>setPickUpContact(e.target.value)}
                            required
                        />
                    </div>
                    <div className="input-group">
                        <label htmlFor="">Delivery Contact</label>
                        <input 
                            type="number" 
                            id="delivery-contact"
                            value={deliveryContact}
                            placeholder="Enter delivery contact"
                            onChange={(e)=>setDeliveryContact(e.target.value)}
                            required
                        />
                    </div>

                    <div className="input-group">
                        <label htmlFor="">Description</label>
                        <input 
                            type="text"
                            id="description" 
                            placeholder="Enter iem description"
                            value={desciption}
                            onChange={(e)=>setDescription(e.target.value)}
                            required
                        />
                    </div>
                    <div className="input-group">
                        <label htmlFor="">Price ($)</label>
                        <input 
                            type="text"
                            id="price" 
                            value={price}
                            placeholder="Enter price to pay driver"
                            onChange={(e)=>setPrice(e.target.value)}
                            required
                        />
                    </div>
                    {/* <div className="input-group">
                        <label htmlFor="">Order Place At</label>
                        <input 
                            type="datetime-local" 
                            id="order-placed"
                            value={createdAt}
                            placeholder="Enter time order will be place"
                            onChange={(e)=>setCreatedAt(e.target.value)}
                            required
                        />
                    </div> */}
                    <div className="input-group">
                        <label htmlFor="">Scheduled To Be Delivered On</label>
                        <input 
                            type="datetime-local"
                            id="scheduled-delivery"
                            value={scheduledForDeliveryOn} 
                            placeholder="Enter time you think order might be delivered"
                            onChange={(e)=>setScheduledForDeliveryOn(e.target.value)}
                            required
                        />
                    </div>

                    <div className="input-group">
                            <label>Item Name</label>
                            <input
                                type="text"
                                placeholder="Enter item name"
                                value={itemName}
                                onChange={(e) => setItemName(e.target.value)}
                            />
                    </div>
                    <div className="input-group">
                        <label>Length (cm)</label>
                        <input
                            type="number"
                            placeholder="Enter length"
                            value={itemLength}
                            onChange={(e) => setItemLength(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Width (cm)</label>
                        <input
                            type="number"
                            placeholder="Enter width"
                            value={itemWidth}
                            onChange={(e) => setItemWidth(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Height (cm)</label>
                        <input
                            type="number"
                            placeholder="Enter height"
                            value={itemHeight}
                            onChange={(e) => setItemHeight(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Quantity</label>
                        <input
                            type="number"
                            placeholder="Enter quantity"
                            value={itemQuantity}
                            onChange={(e) => setItemQuantity(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Weight</label>
                        <input
                            type="number"
                            placeholder="Enter weight"
                            value={itemWeight}
                            onChange={(e) => setItemWeight(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label htmlFor="">Choose Special Instructions</label>
                        <select 
                            name="" 
                            id=""
                            onChange={(e)=>setSpecialInstructions(e.target.value)}
                        >
                            <option value="">Special Instructions</option>
                            <option value="Fragile Items">Fragile Items</option>
                            <option value="Refrigirated transport">Refrigirated transport</option>
                            <option value="Oversized item">Oversized item</option>
                        </select>
                    </div>
                    <div className="input-group">
                    <label htmlFor="">Choose Status</label>
                    <select 
                        type="text"
                        id="status" 
                        placeholder="Enter status"
                        value={status}
                        onChange={(e)=>setStatus(e.target.value)}
                        required
                    >
                        <option value="">Select Status</option>
                        <option value="Pending">Pending</option>
                        <option value="Confirmed">Confirmed</option>
                        <option value="In Progress">In Progress</option>
                        <option value="Completed">Completed</option>
                        <option value="Cancelled">Cancelled</option>
                    </select>
                </div>

            </form>

            <div  className="action-buttons">
                <button 
                    type='button' 
                    onClick={()=>callOptionizationPathMap()} 
                    // disabled={!Order_PlacementId}
                    className="find-driver">
                    Place order Pickup & Delivery locations
                </button>                
            </div>
                <OrdersMap 
                    isOpenMap={showOptimizationMap}
                    onCloseMap={()=>setOptimizationMap(false)}
                    Order_PlacementId={Order_PlacementId}
                />  

                {/* Notification */}
                <div className={`notificationNew ${notification.show ? 'show' : ''}`} id="notification">
                      <div className="d-flex justify-content-between align-items-start mb-2">
                        <h6 className="mb-0" style={{ color: 
                          notification.type === 'error' ? '#dc3545' : 
                          notification.type === 'success' ? '#28a745' : 
                          notification.type === 'warning' ? '#ffc107' : '#4a6fdc'
                        }}>
                          {notification.type === 'error' ? 'Error' : 
                          notification.type === 'success' ? 'Success' : 
                          notification.type === 'warning' ? 'Warning' : 'Information'}
                        </h6>
                        <button className="btn-close btn-sm" onClick={() => setNotification({ ...notification, show: false })}></button>
                      </div>
                      <div className="notification-body">
                        {notification.message}
                      </div>
                </div>         
        </div>
        
    )
}

export default NewOrder