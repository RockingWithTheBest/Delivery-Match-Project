  import React, { useState, useEffect, useRef, useCallback } from 'react';
  import 'leaflet/dist/leaflet.css';
  import 'leaflet-routing-machine/dist/leaflet-routing-machine.css';
  import 'bootstrap/dist/css/bootstrap.min.css';
  import '@fortawesome/fontawesome-free/css/all.min.css';
  import L from 'leaflet';
  import axios from 'axios';
  import 'leaflet-routing-machine';
  import { format } from 'date-fns';
  import './OrdersMap.css';

  // Fix for Leaflet icons
  delete L.Icon.Default.prototype._getIconUrl;
  L.Icon.Default.mergeOptions({
    iconRetinaUrl: 'https://unpkg.com/leaflet@1.7.1/dist/images/marker-icon-2x.png',
    iconUrl: 'https://unpkg.com/leaflet@1.7.1/dist/images/marker-icon.png',
    shadowUrl: 'https://unpkg.com/leaflet@1.7.1/dist/images/marker-shadow.png',
  });

  const OrdersMap = ({ isOpenMap, onCloseMap,Order_PlacementId }) => {
      if (!isOpenMap) return null;  
    // State variables
      const [mapDisplay, setMap] = useState(null);
      const [currentView, setCurrentView] = useState('customer');
      const [pickUpLocationName, setPickUpLocationName] = useState('')
      const [pickupMarker, setPickupMarker] = useState(null);
      const [deliveryMarkers, setDeliveryMarkers] = useState([]);
      const [deliveryPoints, setDeliveryPoints] = useState([0])
      const [pinPlacementMode, setPinPlacementMode] = useState(null);
      const [routeControl, setRouteControl] = useState(null);
      const [homeOption, setHomeOption] = useState(false);
      const [pickDelivery, setPickupDeliveryOption] = useState(true);
      const [orders, setOrders] = useState([]);
      const [routes, setRoutes] = useState([]);
      const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
      
      //api state variables
      const [pickupLocation, setPickUpLocation] = useState();
      const [deliveryLocation, setDeliveryLocation] = useState();
      const [status, setStatus] = useState();
      const [notes, setNotes] =useState();
      const [timeStamps, setTimeStamps] = useState();
      const [disableTextBoxes, setDisableTextBoxes] = useState(true)

      //url
      const url = "https://localhost:7216/api"
    
      
      // Refs
      const mapInitializedRef = useRef(false); // NEW: Track if map is initialized

      // Mock data
      const mockOrders = [
        { id: 1, customer: 'Acme Corp', status: 'pending', driver: null, date: '2023-06-15' },
        { id: 2, customer: 'Beta Inc', status: 'in-progress', driver: 'John Doe', date: '2023-06-15' },
        { id: 3, customer: 'Gamma LLC', status: 'completed', driver: 'Jane Smith', date: '2023-06-14' }
      ];

      const mockRoutes = [
        { 
          id: 1, 
          driverName: 'John Doe',
          stops: [
            { name: 'Warehouse', type: 'pickup', lat: 40.7128, lng: -74.0060, completed: true },
            { name: 'Customer A', type: 'delivery', lat: 40.7228, lng: -74.0160, completed: false },
            { name: 'Customer B', type: 'delivery', lat: 40.7328, lng: -74.0260, completed: false },
            { name: 'Customer C', type: 'delivery', lat: 40.7428, lng: -74.0360, completed: false }
          ], 
          status: 'active' 
        },
        { 
          id: 2, 
          driverName: 'Jane Smith',
          stops: [
            { name: 'Distribution Center', type: 'pickup', lat: 40.7028, lng: -73.9960, completed: false },
            { name: 'Customer D', type: 'delivery', lat: 40.7128, lng: -74.0060, completed: false },
            { name: 'Customer E', type: 'delivery', lat: 40.7228, lng: -74.0160, completed: false }
          ], 
          status: 'pending' 
        }
      ];

      const mockPickUpRoutes = [
          {
            id: 1,
            name: 'Kremlin, Moscow',
            lat:55.75100000000001,
            long:37.61760000000001
          },
          {
            id: 2,
            name: 'Samson Fountain, Saint Petersburg',
            lat:59.88520000000001,
            long:29.90910000000001
          },
          {
            id: 3,
            name: 'Temple of all Religions, Kazan',
            lat:55.80060000000001,
            long:48.97470000000001
          },
          {
            id: 4,
            name: 'Ice Palace, Moscow',
            lat:55.76670000000001,
            long:37.43520000000001
          }      
      ]

      // Initialize map - FIXED
      useEffect(() => {
          // Check if map is already initialized
          if (mapInitializedRef.current && mapDisplay){
              return;
          } 

          // Clean up existing map
          if (mapDisplay) {
            mapDisplay.remove();
          }

          const mapInstance = L.map('map').setView([40.7128, -74.0060], 13);

          L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          }).addTo(mapInstance);

          setMap(mapInstance);
          //setOrders(mockOrders);
          //setRoutes(mockRoutes);

          // Mark map as initialized
          mapInitializedRef.current = true;

          // Cleanup function
          return () => {
            if (mapInstance) {
              mapInstance.remove();
              mapInitializedRef.current = false; // Reset on cleanup
            }
          };
      }, []); // Empty dependency array ensures this runs only once

      // Update map click handler when pinPlacementMode changes
      useEffect(() => {
        if (!mapDisplay) return;

        // Remove existing click handler
        mapDisplay.off('click');

        // Add new click handler
        mapDisplay.on('click', (e) => {
          if (pinPlacementMode) {
            handleMapClick(e.latlng);
          }
        });

        // Update cursor
        if (pinPlacementMode) {
          mapDisplay.getContainer().style.cursor = 'crosshair';
        } else {
          mapDisplay.getContainer().style.cursor = '';
        }
      }, [pinPlacementMode, mapDisplay]);

      // Show notification
      const showNotification = (message, type = 'info') => {
        setNotification({ show: true, message, type });
        setTimeout(() => {
          setNotification(prev=>({ ...prev, show: false }));
        }, 5000);
      };

      // Switch between views
      const switchView = (view) => {
        setCurrentView(view);
        if (pinPlacementMode) {
          cancelPinPlacement();
        }
        
        showNotification(`Switched to ${view} view`, 'info');
      };

    // Pin placement functions
      const startPinPlacement = (type) => {
          setPinPlacementMode(type);  
          showNotification(`Pin placement mode activated - ${type === 'pickup' ? 'pickup' : 'delivery'} location`, 'info');
      };

      const showRoute =()=>{
          updateRoute();
      }

      const cancelPinPlacement = useCallback(() => {
        setPinPlacementMode(null);
        if (mapDisplay) {
          mapDisplay.getContainer().style.cursor = '';
        }
      },[mapDisplay]);

      const handleMapClick = (latlng) => {
        if (!pinPlacementMode || !mapDisplay) return;

        if (pinPlacementMode === 'pickup') {
          placePickupPin(latlng);
        } else if (pinPlacementMode.startsWith('delivery-')) {
          const index = parseInt(pinPlacementMode.split('-')[1]);
          placeDeliveryPin(index, latlng);
        }
        
        cancelPinPlacement();
      };

      const placePickupPin = (latlng) => {
        if (!mapDisplay) return;

        console.log("Placing delivery pin with latlng:", latlng);
        
        // Remove existing pickup marker
        if (pickupMarker) {
          mapDisplay.removeLayer(pickupMarker);
        }

        const icon = L.divIcon({
          className: 'pickup-marker',
          html: '<i class="fas fa-box"></i>',
          iconSize: [40, 40],
          iconAnchor: [20, 20]
        });

        const markerInstance = L.marker(latlng, { 
          icon: icon,
          draggable: true
        }).addTo(mapDisplay);

        console.log("Created pickup marker instance:", markerInstance);
        console.log("Pickup marker getLatLng() returns:", markerInstance.getLatLng && markerInstance.getLatLng());

        markerInstance.on('dragend', () => {
          updateRoute();
        });

        setPickupMarker(markerInstance);
        
        // Update pickup location input
        const pickupInput = document.getElementById('pickup-location');
        if (pickupInput) {
          pickupInput.value = `${latlng.lat.toFixed(6)}, ${latlng.lng.toFixed(6)}`;
          pickupInput.parentElement.classList.add('has-location');
        }

        // Force route update after a small delay to ensure state is updated
        setTimeout(() => {
          updateRoute();
        }, 100);
    
        showNotification('Pickup pin placed successfully', 'success');
      };

      const placeDeliveryPin = (index, latlng) => {
        if (!mapDisplay) return;

        console.log("Placing delivery pin at index:", index, "with latlng:", latlng);

        // Remove existing marker if it exists
        const existingMarker = deliveryMarkers[index];
        if (existingMarker) {
          mapDisplay.removeLayer(existingMarker);
        }

        const icon = L.divIcon({
          className: 'delivery-marker',
          html: '<i class="fas fa-home"></i>',
          iconSize: [40, 40],
          iconAnchor: [20, 20]
        });

        const markerInstance = L.marker(latlng, { 
          icon: icon,
          draggable: true
        }).addTo(mapDisplay);

        markerInstance.on('dragend', () => {
          updateRoute();
        });

        const newDeliveryMarkers = [...deliveryMarkers];

        while(newDeliveryMarkers.length <= index){
          newDeliveryMarkers.push(null)
        }

        newDeliveryMarkers[index] = markerInstance;

        setDeliveryMarkers(newDeliveryMarkers);

        // Update delivery location input
        const inputId = `delivery-location-${index}`;
        const deliveryInput = document.getElementById(inputId);
        if (deliveryInput) {
          deliveryInput.value = `${latlng.lat.toFixed(6)}, ${latlng.lng.toFixed(6)}`;
          deliveryInput.parentElement.classList.add('has-location');
        }

        // Update route AFTER state is updated
        setTimeout(() => {
          updateRoute();
        }, 100);
        
        showNotification(`Delivery point ${index + 1} placed successfully`, 'success');
        
      };
      
      // Delivery point management
      const addDeliveryPoint = () => {
        const newIndex = deliveryMarkers.length
        setDeliveryPoints(prev =>[...prev, newIndex])
        setDeliveryMarkers(prev =>[...prev, null])
       
          updateRoute();
      
        showNotification(`Delivery point ${newIndex + 1} added`, 'info');
      };

      const removeDeliveryPoint = (index) => {

        console.log("Removing delivery point at index:", index);

        // Remove marker from map if exists
        if (deliveryMarkers[index] && mapDisplay) {
          mapDisplay.removeLayer(deliveryMarkers[index]);
        }

        
        // Create new arrays without the removed item
        const newMarkers = [...deliveryMarkers];
        newMarkers.splice(index, 1);
        
        const newPoints = [...deliveryPoints];
        newPoints.splice(index, 1);
        
        setDeliveryMarkers(newMarkers);
        setDeliveryPoints(newPoints);

        // Re-index remaining delivery points
        setTimeout(() => {
          updateRoute();
        }, 100);
        
        showNotification(`Delivery point ${index + 1} removed`, 'info');
      };

      // Route functions
      const updateRoute = () => {
        if (!mapDisplay) return;

        const pickupLatLng = pickupMarker && pickupMarker.getLatLng && pickupMarker.getLatLng();

        const deliveryLatLngs = deliveryMarkers
          .filter(marker => marker && marker.getLatLng)
          .map(marker => marker.getLatLng())
          .filter(latlng => latlng);

        
        const hasValidDelivery = deliveryMarkers.length > 0;
        console.log("hasValidDelivery - here",deliveryMarkers[0].getLatLng().lat)

        setDeliveryLocation(`${deliveryMarkers[0].getLatLng().lat},${deliveryMarkers[0].getLatLng().lng}`)

        // Don't create route if we don't have both pickup and at least one delivery
        if(!hasValidDelivery || !pickupLatLng){
            console.log("Route validation failed - hasValidDelivery:", hasValidDelivery, 
                    "pickupLatLng:", pickupLatLng, 
                    "deliveryLatLngs count:", deliveryLatLngs.length);
            return
        }

        console.log("pickupMarker exists:", !!pickupMarker);
        console.log("pickupMarker.getLatLng exists:", pickupMarker && !!pickupMarker.getLatLng);
        console.log("pickupMarker.getLatLng() value:", pickupMarker && pickupMarker.getLatLng && pickupMarker.getLatLng());
        console.log("deliveryMarkers:", deliveryMarkers);

        // Clear existing route
        if (routeControl) {
          mapDisplay.removeControl(routeControl);
          setRouteControl(null);
        }

        const waypoints = [];

        // Add pickup point
        waypoints.push(L.latLng(pickupLatLng))
        
        // Add delivery points
        deliveryLatLngs.forEach(latlng => {
            waypoints.push(L.latLng(latlng));
        });

        console.log("Creating route with waypoints:", waypoints);

        if (waypoints.length < 2) return;

        try{
            const routingControl = L.Routing.control({
                waypoints: waypoints,
                routeWhileDragging: false,
                addWaypoints: false,
                createMarker: () => null,
                lineOptions: {
                  styles: [{ color: '#4a6fdc', weight: 4, opacity: 0.7 }]
                }
            }).addTo(mapDisplay);

            // Hide the routing control UI
            const container = document.querySelector('.leaflet-routing-container');
            if (container) {
              container.style.display = 'none';
            }

            setRouteControl(routingControl);
          }
          catch(error){
              console.error('Error creating route:', error);
              showNotification('Error creating route. Please check your pin locations.', 'error');
          }
      };

      const clearRoute = () => {
        if (routeControl) {
          mapDisplay.removeControl(routeControl);
          setRouteControl(null);
        }
      };

      // Clear functions
      const clearPickupPin = () => {
        if (pickupMarker && mapDisplay) {
          mapDisplay.removeLayer(pickupMarker);
          setPickupMarker(null);
        }
        
        const pickupInput = document.getElementById('pickup-location');
        if (pickupInput) {
          pickupInput.value = '';
          pickupInput.parentElement.classList.remove('has-location');
        }
        
        clearRoute();
        showNotification('Pickup pin cleared', 'info');
      };

      const clearDeliveryPin = (index) => {
        const markerInstance = deliveryMarkers[index];
        if (markerInstance && mapDisplay) {
          mapDisplay.removeLayer(markerInstance);
          const newDeliveryMarkers = [...deliveryMarkers];
          newDeliveryMarkers[index] = null;
          setDeliveryMarkers(newDeliveryMarkers);
        }
        
        const inputId = `delivery-location-${index}`;
        const deliveryInput = document.getElementById(inputId);
        if (deliveryInput) {
          deliveryInput.value = '';
          deliveryInput.parentElement.classList.remove('has-location');
        }
        
        updateRoute();
        showNotification(`Delivery point ${index + 1} cleared`, 'info');
      };

      const clearAll = () => {
        // Clear pickup marker
        if (pickupMarker) {
          mapDisplay.removeLayer(pickupMarker);
          setPickupMarker(null);
        }

        // Clear delivery markers
        deliveryMarkers.forEach(marker => {
          if (marker) mapDisplay.removeLayer(marker);
        });

        setDeliveryMarkers([null]);
        setDeliveryPoints([0]) // Start with just one delivery point

        // Clear route
        clearRoute();

        // Clear form inputs
        const pickupInput = document.getElementById('pickup-location');
        if (pickupInput) {
          pickupInput.value = '';
          pickupInput.parentElement.classList.remove('has-location');
        }
        
        showNotification('All pins and route cleared', 'info');
      };

      // Order functions
      const createOrder = (e) => {
        e.preventDefault();
        
        const itemName = document.getElementById('item-name').value;
        const itemWeight = document.getElementById('item-weight').value;
        const pickupLocation = document.getElementById('pickup-location').value;
        const hasDeliveryPoint = deliveryMarkers.some(marker => marker !== null);

        if (!itemName || !itemWeight || !pickupLocation || !hasDeliveryPoint) {
          showNotification('Please fill all fields and place at least one delivery pin on map', 'error');
          return;
        }

        const newOrder = {
          id: orders.length + 1,
          customer: 'Current User',
          status: 'pending',
          driver: null,
          date: new Date().toISOString().split('T')[0],
          itemName,
          itemWeight,
          pickupLocation
        };

        setOrders([...orders, newOrder]);
        
        // Reset form
        e.target.reset();
        clearAll();
        
        showNotification('Order created successfully!', 'success');
      };

      //api call's
      const postCoordinates=async()=>{
          try{
              if(!Order_PlacementId){
                setDisableTextBoxes(true)
                throw new Error("Order_PlacementId is required")
              }
              setDisableTextBoxes(true)
              const currentDateTime = format(new Date(),'yyyy-MM-dd HH:mm:ss.0000000')
              console.log("deliveryLocation", deliveryLocation)
              const orderTrackingInstance = {
                OrderPlacementId:parseInt(Order_PlacementId),
                PickUpLocation:pickupLocation,
                DeliveryLocation:deliveryLocation,
                Status: 'Order confirmed',
                Notes : 'Order just recently confirmed',
                TimeStamps:currentDateTime
              }
              console.log("orderTrackingInstance", orderTrackingInstance)

              const newIntance = await axios.post(`${url}/OrderTracking/Add-Order-Tracking`,orderTrackingInstance)

              const orderPlacementResponse = await axios.get(`${url}/OrderPlacement/Get-Order-Single-Record-Placements-By-Id`,{
                  params:{
                      id:parseInt(Order_PlacementId)
                  }
              })
              const orderPlacementOld = orderPlacementResponse.data; 
              console.log("orderPlacementOld",orderPlacementOld)
              orderPlacementOld.PickUpAddress = pickUpLocationName;
              
              const orderPlacementUpdated = await axios.put(`${url}/OrderPlacement/SettingDeliveryAddressName`,orderPlacementOld,{
                  params:{
                      OrderPlacementId:parseInt(Order_PlacementId)
                  }
              })
              console.log("orderPlacement",orderPlacementUpdated.data)
              showNotification("Succuessfully saved the recently added details")

          }
          catch(error){
            // Handle all errors here
            console.log("ERROR MESSAGE:", error);
            
            if (error.message === "Order_PlacementId is required") {
                showNotification("You can't do anything because you haven't entered the ORDER details",'error');
                console.log("ERROR MESSAGE", error.message)
            } else {
                showNotification("An error occurred while saving tracking details");
            }            
          }
      }

      // Make functions available globally for inline onclick handlers
      useEffect(() => {
        window.removeDeliveryPoint = (index) => {
          const marker = deliveryMarkers[index];
          if (marker && mapDisplay) {
            mapDisplay.removeLayer(marker);
            const newDeliveryMarkers = [...deliveryMarkers];
            newDeliveryMarkers[index] = null;
            setDeliveryMarkers(newDeliveryMarkers);
          }
          
          const deliveryPointDiv = document.getElementById(`delivery-point-${index}`);
          if (deliveryPointDiv) {
            deliveryPointDiv.remove();
          }
          
          updateRoute();
          showNotification(`Delivery point ${index + 1} removed`, 'info');
        };

        window.cancelPinPlacement = cancelPinPlacement;
        window.hideNotification = () => setNotification({ ...notification, show: false });
      }, [deliveryMarkers, mapDisplay, notification]);

      // Add a useEffect to update the click handler when pinPlacementMode changes
      useEffect(() => {
        if (!mapDisplay) return;
        
        // Update cursor based on pin placement mode
        if (pinPlacementMode) {
          mapDisplay.getContainer().style.cursor = 'crosshair';
        } else {
          mapDisplay.getContainer().style.cursor = '';
        }
      }, [pinPlacementMode, mapDisplay]);
    
    return (
      <div className='map-modal-overlay'>
        <div className="map-item-modal">
            {/* Navigation */}
            <div>
                <nav className="navbar-map navbar-expand-lg navbar-dark">
                  <div className="container-fluid">
                    <div className='map-nav-title'>
                        <a className="navbar-map-brand" href="#">
                          <i className="fas fa-route me-2"></i>RouteOptimize Pro
                        </a>
                        <a 
                          className="close-map" 
                          href="#" 
                          title='Click to close map'
                          onClick={(e)=>{
                            e.preventDefault();
                            onCloseMap();
                          }}>
                            <i className="fas fa-times" style={{'color':'red'}} ></i>
                        </a>
                    </div>
                  
                    
                    <div className="navbar-map-nav ms-auto">
                      <a 
                        className={`nav-link ${currentView === 'customer' ? 'active text-white' : 'text-white'}`} 
                        href="#" 
                        onClick={(e) => { e.preventDefault(); switchView('customer'); }}
                        data-view="customer"
                      >
                        <i className="fas fa-user me-1"></i>Customer
                      </a>
                      <a 
                        className={`nav-link ${currentView === 'driver' ? 'active text-white' : 'text-white'}`} 
                        href="#" 
                        onClick={(e) => { e.preventDefault(); switchView('driver'); }}
                        data-view="driver"
                      >
                        <i className="fas fa-truck me-1"></i>Driver
                      </a>
                    </div>
                  </div>
                </nav>
            </div>

            {/* Main Container */}
            <div>
                <div className="main-container">
                  {/* Sidebar Toggle Button */}
                  <button className="sidebar-toggle" onClick={() => document.querySelector('.sidebar').classList.toggle('show')}>
                    <i className="fas fa-bars"></i>
                  </button>
                  
                  {/* Sidebar */}
                  <div className="sidebar">
                    {/* Customer View */}
                    <div id="customer-view" className={`view-content p-3 ${currentView === 'customer' ? '' : 'd-none'}`}>
                      <ul className="nav nav-tabs" id="customerTabs" role="tablist">
                        <li className="nav-item" role="presentation">
                          <button className="nav-link active" id="new-order-tab" data-bs-toggle="tab" data-bs-target="#new-order" type="button" role="tab">New Order</button>
                        </li>
                        <li className="nav-item" role="presentation">
                          <button className="nav-link" id="my-orders-tab" data-bs-toggle="tab" data-bs-target="#my-orders" type="button" role="tab">My Orders</button>
                        </li>
                      </ul>
                      
                      <div className="tab-content" id="customerTabsContent">
                        {/* New Order Tab */}
                        <div className="tab-pane fade show active" id="new-order" role="tabpanel">
                          <div className="card">
                            <div className="card-header">
                              <h5 className="mb-0"><i className="fas fa-plus-circle me-2"></i>Create New Order</h5>
                            </div>
                            <div className="card-body">
                              <form id="new-order-form" onSubmit={createOrder}>
                                <div className="mb-3">
                                  <label htmlFor="order-type" className="form-label">Order Type</label>
                                  <select 
                                      className="form-select" 
                                      id="order-type"
                                      onChange={(e)=>{
                                          const optionChosen = e.target.value;
                                          if(optionChosen === "pickup-delivery"){
                                              setHomeOption(false);
                                              setPickupDeliveryOption(true);
                                              showNotification("You are using your own pickup location.")
                                          }
                                          else if(optionChosen === "home-pickup"){
                                              setHomeOption(true);
                                              setPickupDeliveryOption(false);
                                              showNotification("You are using your own home location.")
                                          }
                                      }}
                                  >
                                    <option value="pickup-delivery">Pickup Point</option>
                                    {/* <option value="home-pickup">Home Pickup</option> */}
                                  </select>
                                </div>

                                {pickDelivery && 
                                  <div className="mb-3">
                                    <label htmlFor="order-type" className="form-label">Delivery Match Pickup Location</label>
                                    <select 
                                        className="form-select" 
                                        id="order-type"
                                        onChange={(e)=>{
                                            const selectedId = parseInt(e.target.value);
                                            console.log("mockPickUpRoutes",mockPickUpRoutes)
                                            const selectedLocation = mockPickUpRoutes.find(location => location.id === selectedId)
                                
                                            if(selectedLocation){
                                                // Place pickup pin on the map
                                                const LatLng = L.latLng(selectedLocation.lat, selectedLocation.long);
                                                console.log("LLL",LatLng)
                                                setPickUpLocation(`${selectedLocation.lat},${selectedLocation.long}`)

                                                setPickUpLocationName(selectedLocation.name)
                                                placePickupPin(LatLng)
                                            }
                                        }}
                                    >                               
                                      <option value="">Select pickup location</option>
                                      {mockPickUpRoutes.map(location =>(                                      
                                          <option key={location.id} value={location.id}>
                                            {location.name}
                                          </option>
                                      ))}                          
                                    </select>
                                    <small className="text-muted">Click "Place Pin" then click on map to set pickup location</small>
                                  </div>
                                }
                                                    
                                {homeOption && 
                                  <div className="mb-3">
                                    <label htmlFor="pickup-location" className="form-label">Pickup Location</label>
                                    <div className="location-input-group">
                                      <input 
                                          type="text" 
                                          className="form-control" 
                                          id="pickup-location" 
                                          placeholder="Click on map to place pin" 
                                          // disabled = {disableTextBoxes}
                                          onChange={(e)=>setPickUpLocation(e.target.value)}
                                          readOnly />
                                      <button 
                                        type="button" 
                                        // disabled = {disableTextBoxes}
                                        className="btn btn-outline-secondary" 
                                        onClick={() => startPinPlacement('pickup')}
                                      >
                                        <i className="fas fa-map-pin"></i> Place Pin
                                      </button>
                                      <button 
                                        type="button" 
                                        className="clear-btn" 
                                        onClick={clearPickupPin}
                                      >
                                        <i className="fas fa-times"></i>
                                      </button>
                                    </div>
                                    <small className="text-muted">Click "Place Pin" then click on map to set pickup location</small>
                                  </div>
                                }
                                
                                {/* <div className="mb-3">
                                  <label htmlFor="item-name" className="form-label">Item Name</label>
                                  <input type="text" className="form-control" id="item-name" placeholder="What are you sending?" />
                                </div>
                                
                                <div className="mb-3">
                                  <label htmlFor="item-weight" className="form-label">Weight (kg)</label>
                                  <input type="number" className="form-control" id="item-weight" step="0.1" min="0.1" placeholder="0.0" />
                                </div> */}

                                <div className="mb-3">
                                  <div className="d-flex justify-content-between align-items-center mb-2">
                                    <label className="form-label mb-0">Delivery Locations</label>
                                    <button 
                                      type="button" 
                                      className="btn btn-sm btn-success" 
                                      onClick={addDeliveryPoint}
                                    >
                                      <i className="fas fa-plus"></i> Add Delivery Point
                                    </button>
                                  </div>
                                  
                                  <div id="delivery-points-container">
                                    
                                    {deliveryMarkers.map((marker,index)=>(
                                      <div key={index} className='delivery-point-container' id={`delivery-point-${index}`}>
                                          <div className="delivery-point-header">
                                              <span className='delivery-point-header'>
                                                Delivery Point {index + 1}
                                              </span>
                                              <button
                                                type='button'
                                                className='remove-delivery-point'
                                                onClick={()=>removeDeliveryPoint(index)}
                                              >
                                                <i className="fas fa-times"></i>
                                              </button>
                                          </div>
                                          <div className="location-input-group">
                                              <input 
                                                type="text"
                                                className='form-control'
                                                id={`delivery-location-${index}`}
                                                placeholder='Click on map to place pin'
                                                // onChange={(e)=>setDeliveryLocation(e.target.value)}
                                                disabled={disableTextBoxes}
                                                readOnly />

                                              <button
                                                type="button" 
                                                onClick={() => startPinPlacement(`delivery-${index}`)}
                                                data-index={index}
                                                // disabled={disableTextBoxes}
                                                className="btn btn-outline-secondary delivery-pin-btn">
                                                  <i className="fas fa-map-pin"></i> Place Pin
                                              </button>

                                              <button
                                                type="button" 
                                                className="clear-btn"
                                                onClick={() => clearDeliveryPin(index)}
                                                data-index={index}>
                                                  <i className="fas fa-times"></i>
                                              </button>
                                          </div>
                                          <small className="text-muted">
                                            Click "Place Pin" then click on map to set delivery location
                                          </small>
                                      </div>
                                    ))}
                                  </div>
                                </div>
                                
                                <button
                                  onClick={()=>postCoordinates()}   
                                  type="button" 
                                  className="btn btn-primary w-100"
                                  id="confirm-route-btn"
                                >
                                  <i className="fas fa-paper-plane me-2"></i>Confirm Routes
                                </button>
                                <button 
                                  type='button' 
                                  onClick={()=>showRoute()} 
                                  className="btn btn-primary w-100"
                                >
                                  Show Route
                                </button>
                              </form>
                            </div>
                          </div>
                        </div>
                        
                        {/* My Orders Tab */}
                        <div className="tab-pane fade" id="my-orders" role="tabpanel">
                          <div className="card">
                            <div className="card-header">
                              <h5 className="mb-0"><i className="fas fa-list me-2"></i>My Orders</h5>
                            </div>
                            <div className="card-body p-0">
                              <div id="orders-list">
                                {orders.length > 0 ? (
                                  orders.map(order => {
                                    const statusClass = order.status === 'pending' ? 'status-pending' : 
                                                      order.status === 'in-progress' ? 'status-in-progress' : 'status-completed';
                                    
                                    return (
                                      <div key={order.id} className="order-item">
                                        <div className="d-flex justify-content-between align-items-start mb-2">
                                          <h6 className="mb-0">Order #{order.id}</h6>
                                          <span className={`status-badge ${statusClass}`}>{order.status}</span>
                                        </div>
                                        <p className="mb-1"><strong>Customer:</strong> {order.customer}</p>
                                        <p className="mb-1"><strong>Date:</strong> {order.date}</p>
                                        {order.driver && <p className="mb-1"><strong>Driver:</strong> {order.driver}</p>}
                                      </div>
                                    );
                                  })
                                ) : (
                                  <div className="text-center p-3">
                                    <p className="text-muted">No orders found</p>
                                  </div>
                                )}
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  
                  {/* Map Container */}
                  <div className="map-container">
                    <div id="map" style={{ height: '100%', width: '100%' }}></div>
                    
                    {/* Pin Placement Mode Indicator */}
                    <div className={`pin-placement-mode ${pinPlacementMode ? 'active' : ''}`} id="pin-placement-mode">
                      <button className="cancel-btn" onClick={cancelPinPlacement}>
                        <i className="fas fa-times"></i>
                      </button>
                      <h6 id="pin-mode-text">
                        {pinPlacementMode === 'pickup' 
                          ? 'Click on map to place pickup pin' 
                          : pinPlacementMode?.startsWith('delivery-') 
                            ? 'Click on map to place delivery pin' 
                            : ''}
                      </h6>
                    </div>
            
                    
                    {/* Notification */}
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
                  </div>
                </div>
            </div>
        </div> 
        

        
        
      </div>
    );
  };

  export default OrdersMap;