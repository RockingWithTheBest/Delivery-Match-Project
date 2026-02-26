import React,{useState,useEffect} from "react"
import { useParams } from "react-router-dom"
import axios from "axios"
import './Routes.css'

const Routes=()=>{
    const [route,setRouteInformation] = useState('')
    const [routeId, setRouteId] = useState('')
    const [driverDetails,setDriverDetails] = useState('')
    const [address, setAddress]=useState('')
    const [orderPlacements, setOrderPlacementIds] = useState([])
    const [loading, setLoading] = useState(false);
    const [routeStops, setRouteStops] = useState([]);
    const {DriverId} = useParams()
    const url ="https://localhost:7216/api"

    const postRoutes =async()=>{
        setLoading(true);
        try{
            // const orderIds;
            if(!orderPlacements || orderPlacements.length === 0){
                // alert("No orders found for this driver");
                //Add notifications here
                setLoading(false);
                return;
            }

            const requestBody = {
                DriverId: DriverId,
                OrderIds: orderPlacements
            }
            console.log("requestBody",requestBody)
          
            const response = await axios.post(`${url}/ACOptimization/optimize-route`,requestBody)
            setRouteId(response.data.routeId)
            // setRoute(response.data)

        }
        catch(error){
            console.log("Error Message",error)
        }
        finally {
            setLoading(false);
        }
    }

    const getRoutes = async()=>{

        try{
            const routedata = await axios.get(`${url}/Route/Get-Route-By-DriverId`,{
                params:{
                    id:parseInt(DriverId)
                }
            })
            
            const response = await axios.get(`${url}/Route/Get-Route-By-Id`,{
                params:{
                    id:(routedata.data.Id)
                }
            })
            setRouteInformation(response.data)
            const routeArray = response.data.RouteData.split(' → ');
            setRouteStops(routeArray)
        }
        catch(error){
            console.log("Error", error)
        }
    }
    const formatDuration = (durationString) => {
        if (!durationString) return "N/A";
        const date = new Date(durationString);
        return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    };

    const extractOrderNumber = (stop) => {
        const match = stop.match(/\(Order #(\d+)\)/);
        return match ? match[1] : null;
    };

    const extractAddress = (stop) => {
        return stop.replace(/\s*\(Order #\d+\)\s*$/, '').trim();
    };
    
    const getDriverDetails =async()=>{
        try{
            const responseDriver = await axios.get(`${url}/Driver/Get-Single-Driver-Details`,{
                params:{
                    Id:parseInt(DriverId)
                }
            })

            const addressResponse = await axios.get(`${url}/Address/Get-Address-ListBy-UserId`,{
                params:{
                    UserId:parseInt(responseDriver.data.UserId)
                }
            })

            setDriverDetails(responseDriver.data)
            setAddress(addressResponse.data.list[0])

        }
        catch(error){
            console.log("Error Message",error)
        }
    }

    const getOrderPlacmenetsByDriverId = async()=>{
        try{
            const response = await axios.get(`${url}/OrderPlacement/Get-All-Order-Placement-Records-By-DriverId`,{
                params:{
                    id:parseInt(DriverId)
                }
            })
            
            setOrderPlacementIds(response.data.map(i=>i.Id))          
        }
        catch(error){
            console.log("Error Message1",error)
        }
    }

    useEffect(()=>{
        getRoutes()
    },[DriverId])
    useEffect(()=>{
        // const intervalId = new setInterval(()=>{
        //     getDriverDetails()
        //     getOrderPlacmenetsByDriverId()
        // },1000)  
        
        // return ()=> clearInterval(intervalId)

        getDriverDetails()
        getOrderPlacmenetsByDriverId()

    },[DriverId])
    return(
        <div className="route-container">
            {/* {Header Seaction} */}
            <div className="route-header">
                <h1 className="route-title">🚚 Route Optimization</h1>
                <button 
                    className="generate-btn"
                    onClick={postRoutes}
                    disabled={loading}>
                    {loading ?
                        (                        
                            <>
                                <span className="spinner"></span>
                                Generating...
                            </>
                        ):(
                             <>
                                <span className="btn-icon">🗺️</span>
                                Generate New Optimized Route
                            </>
                        )
                    }
                </button>
            </div>

            <div className="driver-address">            
                {/* {Driver Information Cards} */}
                {driverDetails && (
                    <div className="driver-section">
                        <h2 className="section-title">
                            <span className="section-icon">👤</span>
                            Driver Information
                        </h2>

                        <div className="driver-cards">
                            <div className="driver-card">
                                <div className="card-icon">👤</div>
                                <div className="card-content">
                                    <span className="card-label">Driver Name</span>
                                    <span className="card-value">{driverDetails.User?.FirstName} {driverDetails.User?.LastName}</span>
                                </div>
                            </div>

                            <div className="driver-card">
                                <div className="card-icon">📧</div>
                                <div className="card-content">
                                    <span className="card-label">Email</span>
                                    <span className="card-value">{driverDetails.User?.Email}</span>
                                </div>
                            </div>
                            <div className="driver-card">
                                <div className="card-icon">📱</div>
                                <div className="card-content">
                                    <span className="card-label">Phone</span>
                                    <span className="card-value">{driverDetails.User?.Phone}</span>
                                </div>
                            </div>
                            <div className="driver-card">
                                <div className="card-icon">📋</div>
                                <div className="card-content">
                                    <span className="card-label">License</span>
                                    <span className="card-value">{driverDetails.DriversLicense}</span>
                                </div>
                            </div>
                            <div className="driver-card">
                                <div className="card-icon">✅</div>
                                <div className="card-content">
                                    <span className="card-label">Status</span>
                                    <span className={`status-badge ${driverDetails.IsAvailable ? 'available' : 'unavailable'}`}>
                                        {driverDetails.IsAvailable ? 'Available' : 'Unavailable'}
                                    </span>
                                </div>
                            </div>
                            <div className="driver-card">
                                <div className="card-icon">⭐</div>
                                <div className="card-content">
                                    <span className="card-label">Rating</span>
                                    <span className="card-value">{driverDetails.Rating || '0'} / 5</span>
                                </div>
                            </div>
                        </div>
                    </div>
                )}

                {/* {Address Information} */}
                {address &&(
                    <div className="address-section">
                        <h2 className="section-title">
                            <span className="section-icon">📍</span>
                            Base Address
                        </h2>

                        <div className="address-card">
                            <div className="address-icon">🏢</div>
                            <div className="address-details">
                                <div className="address-label">{address.Label}</div>
                                <div className="address-line">{address.AddressLine}</div>
                                <div className="address-line">{address.City}, {address.Location}</div>
                                <div className="address-coords">
                                    <span>Lat: {address.Latitude}</span>
                                    <span>Lng: {address.Longitude}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                )}
            </div>

            {/* {Route list} */}
            {/* <div className="route-list">
                {routeStops.map((stop, index)=>{
                    const orderMatch = stop.match(/\(Order #(\d+)\)/);
                    const orderNumber = orderMatch ? orderMatch[1] : '';
                    const location = stop.replace(/\(Order #\d+\)/, '').trim();

                    return(
                        <div key={index} className="route-stop">
                            <div className="stop-indicator">
                                <span className="stop-number">{index + 1}</span>
                                {index < routeArray.length - 1 && <div className="connector-line"></div>}
                            </div>

                            <div className="stop-content">
                                <div className="stop-header">
                                    <span className="order-badge">Order #{orderNumber}</span>
                                    <span className="stop-distance">
                                        {index < routeArray.length - 1 && '→ Next stop'}
                                    </span>
                                </div>

                                <div className="location-details">
                                    <p className="location-address">{location}</p>
                                    <p className="location-city">
                                        {location.split(',').slice(-3, -1).join(',').trim()}
                                    </p>
                                </div>
                            </div>
                        </div>
                    )
                })}
            </div>
            <div className="route-summary">
                <p>Total stops: <strong>{routeArray.length}</strong></p>
            </div> */}

            {/* Route Display Section */}
            {route && (
                <div className="route-display-section">
                    <h2 className="section-title">
                        <span className="section-icon">🛣️</span>
                        Optimized Route
                    </h2>

                    {/* Route Summary */}
                    <div className="route-summary">
                        <div className="summary-item">
                            {/* <span className="summary-icon">📏</span> */}
                            <span className="summary-label">Total Distance:</span>
                            <span className="summary-value">{route.TotalDistance} km</span>
                        </div>
                        <div className="summary-item">
                            <span className="summary-icon">⏱️</span>
                            <span className="summary-label">Est. Duration:</span>
                            <span className="summary-value">{formatDuration(route.EstimatedDuration)}</span>
                        </div>
                        <div className="summary-item">
                            <span className="summary-icon">📍</span>
                            <span className="summary-label">Total Stops:</span>
                            <span className="summary-value">{routeStops.length}</span>
                        </div>
                    </div>
                </div>
            )}

            {/* Route Timeline */}
            <div className="route-timeline">
                {routeStops.map((stop,index)=>{
                    const orderNumber = extractOrderNumber(stop);
                    const address = extractAddress(stop);
                     return (
                                <div key={index} className="timeline-item">
                                    <div className="timeline-marker">
                                        <div className="marker-dot"></div>
                                        {index < routeStops.length - 1 && <div className="marker-line"></div>}
                                    </div>
                                    <div className="timeline-content">
                                        <div className="">
                                            <span className="stop-badge">Stop {index + 1}</span>
                                            {orderNumber && <span className="">Order #{orderNumber}</span>}
                                        </div>
                                        <div className="stop-address">{address}</div>
                                        {index === 0 && <span className="stop-start">🚩 Start Point</span>}
                                        {index === routeStops.length - 1 && <span className="stop-end">🏁 End Point</span>}
                                    </div>
                                </div>
                            );
                })}
            </div>
        </div>
    )
}
export default Routes