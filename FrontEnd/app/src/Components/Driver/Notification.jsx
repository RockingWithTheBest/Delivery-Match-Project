import axios from "axios"
import React, { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
const Notifications=()=>{
    const {DriverId} = useParams()

    //Use state
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
    const [customersData, setCustomerData] = useState([])
    const [notifications, setNotifications] = useState([])
    const url = "https://localhost:7216/api"


    const getNotificationsPlacedByUser=async ()=>{
        try{
            const responseOrderPlaced = await axios.get(`${url}/Driver/Get-All-Orders-Claimed-By-Driver-ID`,{
                params:{
                    id:parseInt(DriverId)
                }
            })
            const customerIds = responseOrderPlaced.data.map(i=>i.CustomerId);
            
            const responseCustomers = await axios.post(`${url}/Notification/Get-Customers-With-CustomerIds`,customerIds)
            setCustomerData(responseCustomers.data)

            const allNotifications = []
            for(const customer of responseCustomers.data){
                const response = await axios.get(`${url}/Notification/Get-Notification-Placed-ByCustomer`,{
                    params:{
                        CustomerId:parseInt(customer.Id)
                    }
                })
                allNotifications.push(...response.data)
            }
            setNotifications(allNotifications)
            showNotification("Notifications successfully loaded", 'success')
        }
        catch(error){
            console.log("ERROR",error)
            showNotification("Error loading Notifications", 'error')
        }
    }

    const upldatedNotificationsPlacedByUser=async ()=>{
        try{

        }
        catch(error){
            
        }
    }

    const deleteNotificationsPlacedByUser=async (NotificationId)=>{
        try{

        }
        catch(error){
            
        }
    }

    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
    };

    useEffect(() => {   
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);

    useEffect(()=>{
        getNotificationsPlacedByUser()
    },[DriverId])
    return(
        <div>
            <h2>Notifications</h2>
            {/* {Customers} */}
            {customersData.map((row,index)=>{
                return(
                    <div key={index} className="">
                        //CONTINUE HERE
                    </div>
                    )    
                })       
            }

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
export default Notifications