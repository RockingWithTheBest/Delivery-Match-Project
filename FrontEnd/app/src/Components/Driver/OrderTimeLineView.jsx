import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import axios from "axios";
import ViewParticularOrder from "./ViewParticularOrder";
import './DriverStyles.css'

const OrderTimeLineView=()=>{
    const {DriverId} =useParams()
    const [driverOrders, setDriverOrders] = useState([])
    const [customerDetails, setCustomerDetails]= useState([])
    const [userDetails, setUserDetails]= useState([])
   
    const [orderPlacementId,setOrderPlacementId]=useState(null)
    const urlDriverById = "https://localhost:7216/api/Driver/Get-All-Orders-Placed-By-Driver-ID"
    const urlGetAllCustomers = "https://localhost:7216/api/Customer/Get-All-Customers"
    const urlGetAllUsers = "https://localhost:7216/api/User/Get-All-Users"
    
    
    const specificDriverOrders =async()=>{
        try{
            const response = await axios.get(urlDriverById,
                {
                    params:{
                        id:parseInt(DriverId)
                    }
                })
            setDriverOrders(response.data)
        }
        catch(e){
            console.log("ERROR",e.Message)
        }
        
    }

    const getCustomers = async ()=>{
        try{
            const response = await axios.get(urlGetAllCustomers)
            setCustomerDetails(response.data)
        }
        catch(e){
            console.log("ERROR", e.Message)
        }
    }

     const getUsers = async ()=>{
        try{
            const response = await axios.get(urlGetAllUsers)
            setUserDetails(response.data)
        }
        catch(e){
            console.log("ERROR", e.Message)
        }
    }

    const handleOrderPlacementId=(orderId)=>{
        if(orderId!=null){
            setOrderPlacementId(orderId)
            console.log("Order clicked:", orderId);
        }
    }
    useEffect(()=>{
        specificDriverOrders()
        getCustomers();
        getUsers();
    },[DriverId, driverOrders])


    return(
        <div className="ordertimeline-main">
            <div className="all-order-list">
                <p className="myorders">My Orders</p>
                {driverOrders.map((order,index)=>{
                    const customer = (customerDetails.find(customer=>customer.Id==order.CustomerId))
                    const user = userDetails.find(u => u.Id == customer.UserId)
              
                    return(
                        <div 
                            className="order-container" 
                            key={order.Id} 
                            onClick={()=>handleOrderPlacementId(order.Id)}>

                            <div className="order-header">
                                <h3>ORD-{order.Id}</h3>
                            </div>
                            <div>
                                <ul  className="order-content">
                                    <p className="customer-name">
                                        {user ? `${user.First_Name} ${user.Last_Name}` : "Customer not found"}
                                    </p>
                                </ul>
                            </div>                            
                        </div>
                    );
                    })}
            </div>
            <ViewParticularOrder 
                orderPlacementId ={orderPlacementId}
            />
        </div>
        
    );
}
export default OrderTimeLineView