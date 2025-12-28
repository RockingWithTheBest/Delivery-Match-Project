import React, { useState } from "react";
import './NewOrder.css'
import { useParams } from "react-router-dom";
import ItemDetailsModal from './ItemDetailsModal'
import OrdersMap from "./OrdersMap";
import axios from "axios";

const NewOrder=()=>{
    const {ClientId} = useParams()
    const [pickupAddress, setPickUpAddress]=useState(null)
    const [deliveryAddress, setDeliverAddress]=useState(null)
    const [pickupContact, setPickUpContact]=useState(null)
    const [deliveryContact, setDeliveryContact]=useState(null)
    const [weight, setWeight]=useState(null)
    const [volume, setVolume]=useState(null)
    const [desciption, setDescription]=useState(null)
    const [status, setStatus]=useState("")
    const [createdAt, setCreatedAt]=useState(null)
    const [scheduledForDeliveryOn, setScheduledForDeliveryOn]=useState(null)
    const [price, setPrice]=useState(null)
    const [showItemModal, setShowItemModal] = useState(false);
    const [showOptimizationMap, setOptimizationMap] = useState(false);
    const [Order_PlacementId, setOrder_PlacementId] = useState(null)
    const url = "https://localhost:7216/api"

    const enterDetails = () => {
        setShowItemModal(true)
    };
    
    const handleSubmit = async()=>{
        try{
            const orderPlacements={
                PickUpAddress:pickupAddress,
                DeliveryUpAddress:deliveryAddress,
                PickUpContact:pickupContact,
                DeliveryContact:deliveryContact,
                Description:desciption,
                Status:status,
                Price:price,
                CreatedAt:createdAt,
                ScheduledAt:scheduledForDeliveryOn,
                CustomerId:ClientId
            }
            const response = await axios.post(`${url}/OrderPlacement/Add-OrderPlacement`,orderPlacements)
            console.log("VALUES",response)
            setOrder_PlacementId(parseInt(response.data))
            alert("Successfully Added")
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
                setWeight("")
            }
            

       }
        catch(e){
            alert("Enter correct details please")
            console.log("Error", e.message)
        }
    }

    const callOptionizationPathMap=()=>{
        setOptimizationMap(true);
    }
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
                    <label htmlFor="">Status</label>
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
                <div className="input-group">
                    <label htmlFor="">Order Place At</label>
                    <input 
                        type="datetime-local" 
                        id="order-placed"
                        value={createdAt}
                        placeholder="Enter time order will be place"
                        onChange={(e)=>setCreatedAt(e.target.value)}
                        required
                    />
                </div>
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
            </form>
            <div  className="action-buttons">
                <button type='button' onClick ={()=>enterDetails()} className="enter-item-details">
                    Enter Item Details
                </button>
                <button type='button' onClick={()=>callOptionizationPathMap()} className="find-driver">
                    Place order Pickup & Delivery locations
                </button>                
            </div>
            {/* <div className="map-display"></div> */}
            <ItemDetailsModal
                isOpen={showItemModal}
                onClose={()=>setShowItemModal(false)}
                Order_PlacementId={Order_PlacementId}/>

                <OrdersMap 
                    isOpenMap={showOptimizationMap}
                    onCloseMap={()=>setOptimizationMap(false)}
                    Order_PlacementId={Order_PlacementId}
                />           
        </div>
        
    )
}

export default NewOrder