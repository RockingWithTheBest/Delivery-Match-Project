import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import axios from "axios";
import OrderViews from "./OrderViews";
import './TrackOrder.css'
import NoOrders from "./Icons/no-orders.jpg"

const TrackOrder=()=>{
    const {ClientId} =useParams()
    const [clientOrders, setClientOrders] = useState([])

   
    const [orderPlacementId,setOrderPlacementId]=useState(null)
    const urlClientById = "https://localhost:7216/api/Customer/Get-AllOrderPlacedByCustomer-By-Id"
    
    const specificClientOrders =async()=>{
        try{
            const response = await axios.get(urlClientById,
                {
                    params:{
                        id:parseInt(ClientId)
                    }
                })
            setClientOrders(response.data)
            console.log("Order",response.data)
        }
        catch(e){
            console.log("ERROR",e.Message)
        }
        
    }

    const handleOrderPlacementId=(orderId)=>{
        if(orderId!=null){
            setOrderPlacementId(orderId)
            console.log("Order clicked:", orderId);
        }
    }
    useEffect(()=>{
        specificClientOrders()

    },[ClientId])


    return(
        <div >
            {clientOrders && clientOrders.length > 0 ? (  
                <div className="ordertimeline-main-track-client">                         
                    <div className="all-order-list-track-client">
                        <p className="myorders-track-client">My Orders</p>
                        {clientOrders.map((order,index)=>(
                            <div 
                                className="order-container-track-client" 
                                key={order.Id} 
                                onClick={()=>handleOrderPlacementId(order.Id)}>
                                <div className="order-header-track-client">
                                    <h3>ORDER - {order.Id}</h3>
                                </div>                                                
                            </div>
                        ))}
                    </div>
                    <OrderViews 
                        orderPlacementId ={parseInt(orderPlacementId)}
                    />
                </div> 
            ):(
                <div className="norders-available">
                    <h3>No Orders have been placed</h3>
                    <img src={NoOrders} alt="" />
                </div>
            )}
        </div>
        
    );
}
export default TrackOrder