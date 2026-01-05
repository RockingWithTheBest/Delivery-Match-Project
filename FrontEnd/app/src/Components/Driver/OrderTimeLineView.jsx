import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import axios from "axios";
import ViewParticularOrder from "./ViewParticularOrder";
import './DriverStyles.css'
import './OrderTimeLineView.css'

const OrderTimeLineView=()=>{
    const {DriverId} =useParams()
    const [driverOrders, setDriverOrders] = useState([])
    const [customerDetails, setCustomerDetails]= useState([])
    const [userDetails, setUserDetails]= useState([])
    const [orders, setOrders] = useState([])
   
    const [orderPlacementId,setOrderPlacementId]=useState(null)
    const urlDriverById = "https://localhost:7216/api/Driver/Get-All-Orders-Placed-By-Driver-ID"
    const urlGetAllCustomers = "https://localhost:7216/api/Customer/Get-All-Customers"
    const urlGetAllUsers = "https://localhost:7216/api/User/Get-All-Users"
    const urlOrders = "https://localhost:7216/api/Customer/Get-AllOrderPlacedByCustomer-By-Id"
    
    
    //fetcgh specific order data
    const specificOrder = async()=>{
        try{
            const response = await axios.get(urlOrders,{
                params:{
                    id:parseInt()
                }
            })
        }
        catch(error){
            console.log("Error", error.message)
        }
    }

    //fetch specific driver data
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

    //fetch customer data
    const getCustomers = async ()=>{
        try{
            const response = await axios.get(urlGetAllCustomers)
            setCustomerDetails(response.data)
        }
        catch(e){
            console.log("ERROR", e.Message)
        }
    }

    //fetch user data
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

        // Set up interval to refresh every 2 seconds
        const intervalId = setInterval(() => {
            specificDriverOrders()
            getCustomers();
            getUsers();
        }, 2000); // 2000ms = 2 seconds

        // Clean up interval on component unmount
        return () => clearInterval(intervalId);
    },[DriverId])


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
                                <span className="ordser-status">{order.Status}</span>
                            </div>
                            <div  className="order-content">
                              
                                    <p className="customer-namee">
                                        {user ? `${user.FirstName} ${user.LastName}` : "Customer not found"}
                                    </p>
                                    <p className="order-price">
                                        {user ? `$${order.Price}` : "Customer not found"}
                                    </p>
                          
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