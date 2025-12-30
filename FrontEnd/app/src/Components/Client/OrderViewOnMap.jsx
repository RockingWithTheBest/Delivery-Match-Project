import React, { useState, useEffect, useRef, useCallback } from 'react';
import 'leaflet/dist/leaflet.css';
import 'leaflet-routing-machine/dist/leaflet-routing-machine.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';
import L from 'leaflet';
import axios from 'axios';
import 'leaflet-routing-machine';
import { useParams } from 'react-router-dom';
import './OrdersMap.css';
import './OrderViewOnMap.css'
// Fix for Leaflet icons
delete L.Icon.Default.prototype._getIconUrl;
L.Icon.Default.mergeOptions({
  iconRetinaUrl: 'https://unpkg.com/leaflet@1.7.1/dist/images/marker-icon-2x.png',
  iconUrl: 'https://unpkg.com/leaflet@1.7.1/dist/images/marker-icon.png',
  shadowUrl: 'https://unpkg.com/leaflet@1.7.1/dist/images/marker-shadow.png',
});

const OrderViewOnMap = () => {
  // State variables
  const [mapDisplay, setMap] = useState(null);
  const [currentView, setCurrentView] = useState('customer');
  const [pickupMarker, setPickupMarker] = useState(null);
  const [deliveryMarkers, setDeliveryMarkers] = useState([]);
  const [pinPlacementMode, setPinPlacementMode] = useState(null);
  const [routeControl, setRouteControl] = useState(null);
  const [orders, setOrders] = useState([]);
  const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
  const [isLoading, setIsLoading] = useState(false);
  
  const { ClientId } = useParams();

  // URL
  const url = "https://localhost:7216/api";

  // Refs
  const mapInitializedRef = useRef(false);
  const markersGroupRef = useRef(null); // To store all tracking markers

  // Parse coordinates function
  const parseCoordinates = (coordString) => {
    if (!coordString) return null;
    const parts = coordString.split(',');
    if (parts.length >= 2) {
      return {
        lat: parseFloat(parts[0]),
        lng: parseFloat(parts[1])
      };
    }
    return null;
  };

  // Function to display all tracking pins
  const displayTrackingPins = useCallback(() => {
    if (!mapDisplay || !orders || orders.length === 0) {
      showNotification('No tracking data available to display', 'warning');
      return;
    }

    // Clear existing markers group if exists
    if (markersGroupRef.current) {
      mapDisplay.removeLayer(markersGroupRef.current);
    }

    // Create a new markers group
    markersGroupRef.current = L.layerGroup().addTo(mapDisplay);
    
    // Track bounds to fit map to all markers
    const bounds = [];
    let pinCount = 0;
    
    // Display each tracking's pickup and delivery
    orders.forEach((tracking) => {
      // Parse pickup coordinates
      const pickupCoords = parseCoordinates(tracking.PickUpLocation);
      if (pickupCoords) {
        const pickupIcon = L.divIcon({
          className: 'pickup-marker tracking-pin',
          html: `<i class="fas fa-box"></i><span class="marker-label">P${tracking.OrderPlacementId}</span>`,
          iconSize: [40, 40],
          iconAnchor: [20, 20]
        });
        
        L.marker([pickupCoords.lat, pickupCoords.lng], { icon: pickupIcon })
          .addTo(markersGroupRef.current)
          .bindPopup(`
            <div class="marker-popup">
              <h6><i class="fas fa-box text-primary"></i> Pickup #${tracking.OrderPlacementId}</h6>
              <p><strong>Status:</strong> ${tracking.Status}</p>
              <p><strong>Notes:</strong> ${tracking.Notes}</p>
              <p><strong>Coordinates:</strong> ${tracking.PickUpLocation}</p>
              <small>Tracking ID: ${tracking.Id}</small>
            </div>
          `);
        
        bounds.push([pickupCoords.lat, pickupCoords.lng]);
        pinCount++;
      }

      // Parse delivery coordinates
      const deliveryCoords = parseCoordinates(tracking.DeliveryLocation);
      if (deliveryCoords) {
        const deliveryIcon = L.divIcon({
          className: 'delivery-marker tracking-pin',
          html: `<i class="fas fa-home"></i><span class="marker-label">D${tracking.OrderPlacementId}</span>`,
          iconSize: [40, 40],
          iconAnchor: [20, 20]
        });
        
        L.marker([deliveryCoords.lat, deliveryCoords.lng], { icon: deliveryIcon })
          .addTo(markersGroupRef.current)
          .bindPopup(`
            <div class="marker-popup">
              <h6><i class="fas fa-home text-success"></i> Delivery #${tracking.OrderPlacementId}</h6>
              <p><strong>Status:</strong> ${tracking.Status}</p>
              <p><strong>Notes:</strong> ${tracking.Notes}</p>
              <p><strong>Coordinates:</strong> ${tracking.DeliveryLocation}</p>
              <small>Tracking ID: ${tracking.Id}</small>
            </div>
          `);
        
        bounds.push([deliveryCoords.lat, deliveryCoords.lng]);
        pinCount++;
      }
    });

    // Fit map to show all markers if we have bounds
    if (bounds.length > 0) {
      mapDisplay.fitBounds(bounds);
      showNotification(`Displayed ${pinCount} markers for ${orders.length} orders`, 'success');
    }
  }, [mapDisplay, orders]);

  // Function to show routes between pickup and delivery for all orders
  const showRoutesForOrders = useCallback(() => {
    if (!mapDisplay || !orders || orders.length === 0) {
      showNotification('No tracking data available to create routes', 'warning');
      return;
    }
    
    // Clear existing route
    if (routeControl) {
      mapDisplay.removeControl(routeControl);
      setRouteControl(null);
    }
    
    const waypoints = [];
    let validOrders = 0;
    
    // For each order, create waypoints from pickup to delivery
    orders.forEach((tracking) => {
      const pickupCoords = parseCoordinates(tracking.PickUpLocation);
      const deliveryCoords = parseCoordinates(tracking.DeliveryLocation);
      
      if (pickupCoords && deliveryCoords) {
        // Add pickup point
        waypoints.push(L.latLng(pickupCoords.lat, pickupCoords.lng));
        // Add delivery point
        waypoints.push(L.latLng(deliveryCoords.lat, deliveryCoords.lng));
        validOrders++;
      }
    });
    
    if (waypoints.length < 2) {
      showNotification('Not enough valid coordinates to create route', 'warning');
      return;
    }
    
    try {
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
      showNotification(`Created routes for ${validOrders} orders with ${waypoints.length} waypoints`, 'success');
    } catch (error) {
      console.error('Error creating route:', error);
      showNotification('Error creating route', 'error');
    }
  }, [mapDisplay, orders, routeControl]);

  // Function to clear everything from map
  const clearAll = () => {
    // Clear markers group
    if (markersGroupRef.current) {
      mapDisplay.removeLayer(markersGroupRef.current);
      markersGroupRef.current = null;
    }
    
    // Clear pickup marker
    if (pickupMarker) {
      mapDisplay.removeLayer(pickupMarker);
      setPickupMarker(null);
    }
    
    // Clear delivery markers
    deliveryMarkers.forEach(marker => {
      if (marker) mapDisplay.removeLayer(marker);
    });
    setDeliveryMarkers([]);
    
    // Clear route
    if (routeControl) {
      mapDisplay.removeControl(routeControl);
      setRouteControl(null);
    }
    
    showNotification('Map cleared', 'info');
  };

  // Fetch orders data
  const getOrderPlacementsByCustomer = async () => {
    setIsLoading(true);
    try {
      const responseOrderPlacement = await axios.get(`${url}/OrderPlacement/Get-All-Order-Placement-Records-By-CustomerId`, {
        params: { id: parseInt(ClientId) }
      });
      
      const orderPlacementIds = responseOrderPlacement.data.map(d => d.Id);
      
      const responseOrderTrackings = await axios.get(`${url}/OrderTracking/Get-All-Order-Tracking`);
      const trackingsData = responseOrderTrackings.data;
      
      const filteredTrackings = trackingsData.filter(tracking =>
        orderPlacementIds.includes(tracking.OrderPlacementId)
      );
      
      setOrders(filteredTrackings);
      showNotification(`Loaded ${filteredTrackings.length} tracking records`, 'success');
    } catch (error) {
      console.log("Error fetching data:", error.message);
      showNotification('Error loading tracking data', 'error');
    } finally {
      setIsLoading(false);
    }
  };

  // Show notification
  const showNotification = (message, type = 'info') => {
    setNotification({ show: true, message, type });
    setTimeout(() => {
      setNotification(prev => ({ ...prev, show: false }));
    }, 5000);
  };

  // Switch between views
  const switchView = (view) => {
    setCurrentView(view);
    showNotification(`Switched to ${view} view`, 'info');
  };

  // Initialize map
  useEffect(() => {
    if (mapInitializedRef.current && mapDisplay) {
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
    mapInitializedRef.current = true;

    // Cleanup function
    return () => {
      if (mapInstance) {
        mapInstance.remove();
        mapInitializedRef.current = false;
      }
    };
  }, []);

  // Fetch data on component mount
  useEffect(() => {
    getOrderPlacementsByCustomer();
  }, [ClientId]);

  // Display pins when data is loaded and map is ready
  useEffect(() => {
    if (orders.length > 0 && mapDisplay && mapInitializedRef.current) {
      // Small delay to ensure map is fully initialized
      const timer = setTimeout(() => {
        displayTrackingPins();
      }, 500);
      
      return () => clearTimeout(timer);
    }
  }, [orders, mapDisplay, displayTrackingPins]);

  // Function to zoom to a specific order
  const zoomToOrder = (tracking) => {
    if (!mapDisplay) return;
    
    const pickupCoords = parseCoordinates(tracking.PickUpLocation);
    const deliveryCoords = parseCoordinates(tracking.DeliveryLocation);
    
    if (pickupCoords && deliveryCoords) {
      const bounds = L.latLngBounds([
        [pickupCoords.lat, pickupCoords.lng],
        [deliveryCoords.lat, deliveryCoords.lng]
      ]);
      mapDisplay.fitBounds(bounds, { padding: [50, 50] });
      showNotification(`Zoomed to Order #${tracking.OrderPlacementId}`, 'info');
    }
  };

  // Function to show only pickup locations
  const showPickupLocations = () => {
    if (!mapDisplay || !orders || orders.length === 0) return;
    
    if (markersGroupRef.current) {
      mapDisplay.removeLayer(markersGroupRef.current);
    }
    
    markersGroupRef.current = L.layerGroup().addTo(mapDisplay);
    const bounds = [];
    
    orders.forEach((tracking) => {
      const pickupCoords = parseCoordinates(tracking.PickUpLocation);
      if (pickupCoords) {
        const pickupIcon = L.divIcon({
          className: 'pickup-marker tracking-pin',
          html: `<i class="fas fa-box"></i><span class="marker-label">P${tracking.OrderPlacementId}</span>`,
          iconSize: [40, 40],
          iconAnchor: [20, 20]
        });
        
        L.marker([pickupCoords.lat, pickupCoords.lng], { icon: pickupIcon })
          .addTo(markersGroupRef.current)
          .bindPopup(`
            <div class="marker-popup">
              <h6><i class="fas fa-box text-primary"></i> Pickup #${tracking.OrderPlacementId}</h6>
              <p><strong>Status:</strong> ${tracking.Status}</p>
              <p><strong>Coordinates:</strong> ${tracking.PickUpLocation}</p>
            </div>
          `);
        
        bounds.push([pickupCoords.lat, pickupCoords.lng]);
      }
    });
    
    if (bounds.length > 0) {
      mapDisplay.fitBounds(bounds);
      showNotification(`Displayed ${bounds.length} pickup locations`, 'success');
    }
  };

  // Function to show only delivery locations
  const showDeliveryLocations = () => {
    if (!mapDisplay || !orders || orders.length === 0) return;
    
    if (markersGroupRef.current) {
      mapDisplay.removeLayer(markersGroupRef.current);
    }
    
    markersGroupRef.current = L.layerGroup().addTo(mapDisplay);
    const bounds = [];
    
    orders.forEach((tracking) => {
      const deliveryCoords = parseCoordinates(tracking.DeliveryLocation);
      if (deliveryCoords) {
        const deliveryIcon = L.divIcon({
          className: 'delivery-marker tracking-pin',
          html: `<i class="fas fa-home"></i><span class="marker-label">D${tracking.OrderPlacementId}</span>`,
          iconSize: [40, 40],
          iconAnchor: [20, 20]
        });
        
        L.marker([deliveryCoords.lat, deliveryCoords.lng], { icon: deliveryIcon })
          .addTo(markersGroupRef.current)
          .bindPopup(`
            <div class="marker-popup">
              <h6><i class="fas fa-home text-success"></i> Delivery #${tracking.OrderPlacementId}</h6>
              <p><strong>Status:</strong> ${tracking.Status}</p>
              <p><strong>Coordinates:</strong> ${tracking.DeliveryLocation}</p>
            </div>
          `);
        
        bounds.push([deliveryCoords.lat, deliveryCoords.lng]);
      }
    });
    
    if (bounds.length > 0) {
      mapDisplay.fitBounds(bounds);
      showNotification(`Displayed ${bounds.length} delivery locations`, 'success');
    }
  };

  return (
    <div className='map-modal-view'>
      <div className="map-item-component">
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
                <div className="tab-content" id="customerTabsContent">
                  <div className="tab-pane fade show active" id="new-order" role="tabpanel">
                    <div className="card">
                      <div className="card-header">
                        <h5 className="mb-0">
                          <i className="fas fa-map-marked-alt me-2"></i>
                          Display Orders on Map
                        </h5>
                      </div>
                      <div className="card-body">
                        {isLoading ? (
                          <div className="text-center py-3">
                            <div className="spinner-border text-primary" role="status">
                              <span className="visually-hidden">Loading...</span>
                            </div>
                            <p className="mt-2">Loading tracking data...</p>
                          </div>
                        ) : (
                          <>
                            <h6 className="text-muted mb-3">
                              <i className="fas fa-info-circle me-2"></i>
                              Found {orders.length} tracking records
                            </h6>
                            
                            <div className="d-grid gap-2 mb-4">
                              <button 
                                type='button' 
                                onClick={displayTrackingPins} 
                                className="btn btn-primary"
                                disabled={orders.length === 0}
                              >
                                <i className="fas fa-map-marker-alt me-2"></i>
                                Show All Markers
                              </button>
                              
                              <button 
                                type='button' 
                                onClick={showRoutesForOrders} 
                                className="btn btn-success"
                                disabled={orders.length === 0}
                              >
                                <i className="fas fa-route me-2"></i>
                                Show All Routes
                              </button>
                              
                              <div className="btn-group" role="group">
                                <button 
                                  type='button' 
                                  onClick={showPickupLocations} 
                                  className="btn btn-outline-primary"
                                  disabled={orders.length === 0}
                                >
                                  <i className="fas fa-box me-2"></i>
                                  Pickups
                                </button>
                                <button 
                                  type='button' 
                                  onClick={showDeliveryLocations} 
                                  className="btn btn-outline-success"
                                  disabled={orders.length === 0}
                                >
                                  <i className="fas fa-home me-2"></i>
                                  Deliveries
                                </button>
                              </div>
                              
                              <button 
                                type='button' 
                                onClick={clearAll} 
                                className="btn btn-outline-danger"
                              >
                                <i className="fas fa-trash me-2"></i>
                                Clear Map
                              </button>
                            </div>
                            
                            {/* Orders List */}
                            <div className="mt-4">
                              <h6 className="mb-3 border-bottom pb-2">
                                <i className="fas fa-list me-2"></i>
                                Orders List
                              </h6>
                              <div className="tracking-list" style={{ maxHeight: '300px', overflowY: 'auto' }}>
                                {orders.length === 0 ? (
                                  <div className="text-center py-3 text-muted">
                                    <i className="fas fa-inbox fa-2x mb-2"></i>
                                    <p>No tracking records found</p>
                                  </div>
                                ) : (
                                  orders.map((tracking) => {
                                    const pickupCoords = parseCoordinates(tracking.PickUpLocation);
                                    const deliveryCoords = parseCoordinates(tracking.DeliveryLocation);
                                    const hasValidCoords = pickupCoords && deliveryCoords;
                                    
                                    return (
                                      <div key={tracking.Id} className="card mb-2">
                                        <div className="card-body p-3">
                                          <div className="d-flex justify-content-between align-items-center">
                                            <div>
                                              <h6 className="mb-1">
                                                Order #{tracking.OrderPlacementId}
                                                {!hasValidCoords && (
                                                  <span className="badge bg-warning ms-2">Missing Coords</span>
                                                )}
                                              </h6>
                                              <small className="text-muted d-block">
                                                Status: <span className={`badge bg-${tracking.Status === 'Confirmed' ? 'primary' : 'warning'}`}>
                                                  {tracking.Status}
                                                </span>
                                              </small>
                                              <small className="text-muted">
                                                {tracking.Notes}
                                              </small>
                                            </div>
                                            <div>
                                              <button 
                                                className="btn btn-sm btn-outline-primary me-1"
                                                onClick={() => zoomToOrder(tracking)}
                                                disabled={!hasValidCoords}
                                                title={hasValidCoords ? "Zoom to this order" : "Invalid coordinates"}
                                              >
                                                <i className="fas fa-search"></i>
                                              </button>
                                            </div>
                                          </div>
                                          {hasValidCoords && (
                                            <div className="mt-2">
                                              <small className="d-block">
                                                <i className="fas fa-box text-primary me-1"></i>
                                                Pickup: {tracking.PickUpLocation}
                                              </small>
                                              <small className="d-block">
                                                <i className="fas fa-home text-success me-1"></i>
                                                Delivery: {tracking.DeliveryLocation}
                                              </small>
                                            </div>
                                          )}
                                        </div>
                                      </div>
                                    );
                                  })
                                )}
                              </div>
                            </div>
                          </>
                        )}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            
            {/* Map Container */}
            <div className="map-container">
              <div id="map" style={{ height: '100%', width: '100%' }}></div>            
              
              {/* Notification */}
              <div className={`notification ${notification.show ? 'show' : ''}`} id="notification">
                <div className="d-flex justify-content-between align-items-start mb-2">
                  <h6 className="mb-0" style={{ 
                    color: notification.type === 'error' ? '#dc3545' : 
                           notification.type === 'success' ? '#28a745' : 
                           notification.type === 'warning' ? '#ffc107' : '#4a6fdc'
                  }}>
                    <i className={`fas ${
                      notification.type === 'error' ? 'fa-exclamation-circle' :
                      notification.type === 'success' ? 'fa-check-circle' :
                      notification.type === 'warning' ? 'fa-exclamation-triangle' : 'fa-info-circle'
                    } me-2`}></i>
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

export default OrderViewOnMap;