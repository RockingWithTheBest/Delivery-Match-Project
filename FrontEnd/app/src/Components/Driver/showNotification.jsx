import { useState, useEffect } from "react";
import './showNotification.css'

const ShowNotification =()=>{
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
     
    const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
    };

    useEffect(() => {   
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);

    return(
            <div className={`notification ${notification.show ? 'show' : ''}`} id="notification">
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
    )
}
export default ShowNotification;


 