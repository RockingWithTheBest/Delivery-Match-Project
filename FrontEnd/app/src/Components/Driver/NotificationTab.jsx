import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import './NotificationTab.css'
import { secondsToMinutes } from "date-fns";

const NotificationTab=()=>{
    const apiUrl ="https://localhost:7216/api"
    const {DriverId} = useParams()

    const [messageText, setMessageText] = useState('');
    const [sending, setSending] = useState(false);
    const [activeTab, setActiveTab] = useState('all');
    const [boolSendMessage, setBoolSendMessage]=useState(true)
    const [boolRestNotificationFunc, setBoolRestNotificationFunc] = useState(true)
    const [singleView, setSingleOrderView] = useState(false)
    const [selectedOrdersNotifications, setSelectedOrdersNotifications] = useState([])
    const [orderId, setOrderId] = useState(null)
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [unreadCount, setUnreadCount] = useState(0);
    const [orders, setOrders] = useState([]);
    const [loading, setLoading] = useState(true)
    const [notifications, setNotifications] = useState([])
    const [error, setError] = useState()

    const fetchNotification=async()=>{
        try{
            setLoading(true)
            const response = await axios.get(`${apiUrl}/Notification/Get-Notification-Placed-ByDriver`,{
                    params:{
                        DriverId:parseInt(DriverId)
                    }
                }
            );
            setNotifications(response.data)
            setUnreadCount(response.data.filter(n => !n.IsRead).length);
            setError(null)
        }
        catch(error){
            setError('Failed to load notifications');
            console.error('Error fetching notifications:', error);
        } finally {
            setLoading(false);
        }
    }

    //Get-Notifications-Of-Particular-OrderPlaced?OrderPlacementI
    const NotificationsOfParticularOrderPlaced =async(order)=>{
        const response = await axios.get(`${apiUrl}/Notification/Get-Notifications-Of-Particular-OrderPlaced`,{
            params:{
                OrderPlacementId:parseInt(order.Id)
            }
        })
        //console.log("NotificationsPlaced",response.data.NotificationsPlaced)
        setSelectedOrdersNotifications(response.data.NotificationsPlaced)
    }

    const fetchOrders = async()=>{
        try{
            const response = await axios.get(`${apiUrl}/OrderPlacement/Get-All-Order-Placement-Records-By-DriverId`,{
                params:{
                    id:parseInt(DriverId)
                }
            });

            setOrders(response.data);
        }
        catch(error){
            console.error('Error fetching orders:', err);
        }
    }
    const sendClientMessage=async(orderId)=>{
        if (!messageText.trim()) {
            alert('Please enter a message');
            return;
        }
        try{
            setSending(true);
            const message = {
                Id: DriverId,
                orderId: orderId,
                message: messageText
            }
            const response = await axios.post(`${apiUrl}/Notification/Send-Client-Message`,message)
            
            setMessageText('');
            setSelectedOrder(null);

            // Show success message
            alert('Message sent successfully!');
        }
        catch(error){
            console.log("ERROR",error )
            console.error('Error sending message:', err);
            alert('Failed to send message. Please try again.');
        }
        finally {
            setSending(false);
        }
    }

    const handleViewNotificationsForAparticularOrder =()=>{
        setBoolSendMessage(false)
        setBoolRestNotificationFunc(false)
        setSingleOrderView(true)
    }

    const handleOrderNotificationTabs = ()=>{
        setBoolSendMessage(true)
        setBoolRestNotificationFunc(true)
        setSingleOrderView(false)
    }

        // Get notification icon based on type
    const getNotificationIcon = (type) => {
        switch (type?.toLowerCase()) {
            case 'order update':
                return '📦';
            case 'customer message':
                return '💬';
            case 'driver message':
                return '💬';   
            case 'recently created':
                return '🆕';
            case 'deleted':
                return '🗑️';
            default:
                return '🔔';
        }
    };

        // Get notification color based on type
    const getNotificationColor = (type) => {
        switch (type?.toLowerCase()) {
            case 'order update':
                return '#4a6fdc';
            case 'customer message':
                return '#28a745';
            case 'recently created':
                return '#ffc107';
            default:
                return '#6c757d';
        }
    };

    const handleDeleteNotification=async(Id)=>{
        const response = await axios.delete(`${apiUrl}/Notification/Delete-An-Notification-Record`,{
            params:{
                Id:parseInt(Id)
            }
        })
    }

        // Filter notifications based on active tab
    const filteredNotifications = notifications.filter(notification => {
        if (activeTab === 'all') return true;
        if (activeTab === 'unread') return !notification.IsRead;
        if (activeTab === 'messages') 
            return notification.Type === 'Customer Message';
        if (activeTab === 'updates') 
            return notification.Type !== 'Customer Message';
        // if (activeTab === 'view') 
        //     return notification.Type !== 'Customer Message';
        return true;
    });

        // Mark all as read
    const markAllAsRead = async () => {
        try {
            await axios.put(`${apiUrl}/Notification/Mark-All-Notifications-Read`,null,{
                    params:{
                        customerId: parseInt(ClientId)
                    }
                }
            );
            fetchNotification();
        } catch (err) {
            console.error('Error marking all as read:', err);
        }
    };

    // Mark notification as read
    const markAsRead = async (Id) => {
        try {
            await axios.put(`${apiUrl}/Notification/Mark-Notification-Read`,null,{
                    params:{
                        notificationId: parseInt(Id)
                    }
                }
            );

            fetchNotification();
        } catch (err) {
            console.error('Error marking notification as read:', err);
        }
    };

   
    useEffect(()=>{
        fetchNotification()
        fetchOrders();

        // Set up polling for new notifications every 2 seconds
        // const interval = setInterval(()=>{
        //     fetchNotification()
        // },20000)

        // return ()=> clearInterval(interval)
    },[DriverId])

    if (loading) {
        return (
            <div className="notifications-loading">
                <div className="spinner"></div>
                <p>Loading notifications...</p>
            </div>
        );
    }
    return(
        <div className="notifications-container">
            {/* Header */}
            <div className="notifications-header">
                <div className="header-left">
                    <h2>Notifications</h2>
                    {unreadCount > 0 && (
                        <span className="unread-badge">{unreadCount} unread</span>
                    )}
                </div>
                {unreadCount >0 && (
                    <button 
                        className="mark-all-read-btn"
                        onClick={markAllAsRead}>
                            Mark all as read
                        </button>
                )}
            </div>

            {/* Tabs */}
            <div className="notifications-tabs">
                <button 
                    className={`tab ${activeTab === 'all' ? 'active' : ''}`}
                    onClick={() => {setActiveTab('all'), setBoolRestNotificationFunc(true), setBoolSendMessage(true), handleOrderNotificationTabs()}}
                    >
                    All
                </button>
                <button
                    className={`tab ${activeTab === 'unread' ? 'active' : ''}`}
                    onClick={() => {setActiveTab('unread'), setBoolRestNotificationFunc(true), setBoolSendMessage(true), handleOrderNotificationTabs()}}
                >
                    Unread
                    {unreadCount > 0 && <span className="tab-badge">{unreadCount}</span>}
                </button>
                
                <button 
                    className={`tab ${activeTab === 'messages' ? 'active' : ''}`}
                    onClick={() => {setActiveTab('messages'), setBoolRestNotificationFunc(true), setBoolSendMessage(true), handleOrderNotificationTabs()}}
                >
                    Messages
                </button>
                
                <button 
                    className={`tab ${activeTab === 'updates' ? 'active' : ''}`}
                    onClick={() => {setActiveTab('updates'), setBoolRestNotificationFunc(true), setBoolSendMessage(true), handleOrderNotificationTabs()}}
                >
                    Order Updates
                </button>

                <button 
                    className={`tab ${activeTab === 'view' ? 'active' : ''}`}
                    onClick={()=>{handleViewNotificationsForAparticularOrder(), setActiveTab('view')}}
                >
                    Single Notification View
                </button>
            </div>

            {/* Send Message Section */}
            {boolSendMessage && 
                <div className="send-message-section">
                    <h3>Send Message to Client</h3>
                    <select 
                        name="" 
                        id=""
                        className="order-select"
                        value={selectedOrder?.Id || ''}
                        onChange={(e)=>{
                            const order = orders.find(o=>o.Id = parseInt(e.target.value))
                            setSelectedOrder(order)
                        }}
                        >
                           <option value="">Select an order</option>
                           {orders.map(order =>(
                                <option key={order.Id} value={order.Id}>
                                    Order #{order.Id} - {order.Status}
                                </option>
                           ))}                        
                    </select>

                    {selectedOrder && (
                        <div className="message-input-area">
                            <textarea 
                                name="" 
                                id=""
                                className="message-input"
                                placeholder="Type your message to the client"
                                value={messageText}
                                onChange={(e)=>setMessageText(e.target.value)}
                                rows="3"
                            />
                            <button 
                                className="send-btn"
                                onClick={()=>sendClientMessage(selectedOrder.Id)}
                                disabled={sending || !messageText.trim()}
                            >
                                {sending ? 'Sending...' : 'Send Message'}
                            </button>
                        </div>
                    )}
                </div>
            }

            {/* Notifications List */}
            {error && (
                <div className="error-message">
                    <p>{error}</p>
                    <button onClick={fetchNotification}>Retry</button>
                </div>
            )}

            {boolRestNotificationFunc && 
                <div>
                    {filteredNotifications.length === 0? (
                        <div className="no-notifications">
                            <div className="empty-state">
                                <span className="empty-icon">🔔</span>
                                <p>No notifications yet</p>
                                <small>When you receive notifications, they'll appear here</small>
                            </div>
                        </div>
                    ):(
                        <div className="notifications-list">
                            {filteredNotifications.map(notification =>(
                                <div
                                    key={notification.Id}
                                    className={`notification-item ${!notification.IsRead ? 'unread' : ''}`}
                                    onClick={() => markAsRead(notification.Id)}
                                >
                                    <div
                                        className="notification-icon"
                                        style={{ backgroundColor: getNotificationColor(notification.Type) }}
                                    >
                                        {getNotificationIcon(notification.Type)}
                                    </div>

                                    <div className="notification-content-first">
                                        <div className="notification-header">
                                            <span className="notification-type">{notification.Type}</span>
                                            <span className="notification-time">
                                                {new Date(notification.CreatedAt).toLocaleString()}
                                            </span>
                                        </div>

                                        <p className="notification-message">{notification.Message}</p>
                                        {notification.driverCommentry && (
                                            <p className="notification-commentry">
                                                <strong>Client:</strong> {notification.DriverCommentry}
                                            </p>
                                        )}

                                        {notification.OrderPlacement && (
                                            <div className="notification-order-info">
                                                <span className="order-badge">
                                                    Order #{notification.OrderPlacement.Id}
                                                </span>
                                                <span className="order-status">
                                                    Status: {notification.OrderPlacement.Status}
                                                </span>
                                            </div>
                                        )}
                                        {!notification.IsRead &&(
                                            <div className="unread-dot"></div>
                                        )}
                                    </div>
                                </div>
                            ))}
                        </div>
                    )}
                </div>
            }

            {singleView && 
                <div>
                    <h6>Choose which order's notifications you want to view</h6>
                    <select 
                        name="" 
                        id="" 
                        className="order-select" 
                        onChange={(e)=>{
                            const order = orders.find(o=>o.Id ===parseInt(e.target.value))

                            NotificationsOfParticularOrderPlaced(order)
                            setOrderId(order)
                        }}>
                            <option>Select an order</option>
                            {orders.map(order=>(
                                <option key={order.Id} value={order.Id}>
                                    Order #{order.Id} Status - {order.Status}
                                </option>
                            ))}
                        </select>

                        {selectedOrdersNotifications.map(notify=>(
                            <div className="notifications-list">
                                <div
                                    key={notify.Id}
                                    className={`notification-item ${!notify.IsRead ? 'unread':''}`}
                                >
                                    <div className="arrange-notification">
                                        <div 
                                            className="notification-icon"
                                            style={{backgroundColor:getNotificationColor(notify.Type)}}
                                        >
                                            {getNotificationIcon(notify.Type)}
                                        </div>
                                        <div className="notification-content">
                                            <span className="notification-header">{notify.Type}</span>
                                            <span className="notification-time">
                                                {new Date(notify.CreatedAt).toLocaleString()}
                                            </span>
                                        </div>
                                        <p className="notification-message">{notify.Message}</p>
                                        {notify.DriverCommentry && (
                                            <p className="notification-commentry">
                                                {notify.DriverCommentry}
                                            </p>
                                        )}
                                    </div>
                                    <div className="delete-icon" onClick={()=>handleDeleteNotification(notify.Id)}>
                                        🗑️
                                    </div>
                                </div>
                            </div>
                        ))}
                </div>
            }
        </div>
    );
}

export default NotificationTab