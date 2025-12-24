import React,{useEffect,useState} from 'react'
import 'reactjs-popup/dist/index.css';
import axios from 'axios'
import './knapsack.css'
import './DriverStyles.css'
import { useParams } from 'react-router-dom';

const KnapsackAlgorithm=()=>{
    const [vehicleRecords,setVehicleRecords] = useState([])
    const [orderPlacements, setOrderPlacementRecords]=useState([])
    const [selectedVehicle, setSelectedVehicle] = useState(null)
    const [selectedOrders, setSelectedOrders] = useState([]);
    const [solution, setSolution] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');
    const {DriverId}=useParams()
    const url = "https://localhost:7216/api";

    const getAllDriverRecords=async()=>{
        try{
            const api_response = await axios.get("https://localhost:7216/api/Vehicle/Get-All-Vehcile")
            setVehicleRecords(api_response.data)
        }
        catch(err){
            console.log("Error Message",err)
        }        
    }

    const getAllOrderPlacementRecords=async()=>{
        try{
            const api_response = await axios.get("https://localhost:7216/api/OrderPlacement/Get-All-OrderPlacements")
            const availableOrders  = api_response.data.filter(order=>order.DriverId===null)
            setOrderPlacementRecords(availableOrders)
        }
        catch(err){
            console.log("Error Message",err)
        }
        
    }
        
    useEffect(() => {
            if (vehicleRecords.length > 0 && !selectedVehicle) {
                setSelectedVehicle(vehicleRecords[0]);
            }
    }, [vehicleRecords]);
        // 2D Knapsack algorithm that considers both weight and volume
        const solve2DKnapsack=(weights, volumes, values, maxWeight, vehicleCapacity)=>{
                
            //Scale to integers(assume 2 decimal precision)
            const PRECISION = 100;
    
            // ---- Stage 1: Knapsack by VOLUME only ----
            const intCapacity = Math.round(vehicleCapacity*PRECISION)
            const intVolumes = volumes.map(v =>Math.round(v*PRECISION))
           
            let me = 0
            intVolumes.forEach(v=>{
                me = me + v
            })
            console.log("TOTAL ORDERS VOLUME",me)
            console.log("volumes",intVolumes)
            console.log("vehicleCapacity",intCapacity)
           
            const n = volumes.length;

            // Edge case: if capacity is 0
            if(intCapacity <=0){
                return { 
                    maxValue: 0, 
                    selectedIndices: [], 
                    totalWeight: 0 
                };
            }
            
            // Create DP table with n+1 rows and capacity+1 columns
            const dp1 = Array.from({length:n+1}, 
                ()=>Array(intCapacity+1).fill(0))
            
            for( let i = 1 ; i <= n ; i++){
                for(let v = 0 ; v <= intCapacity ; v++){

                    if(intVolumes[i - 1] <= v){// If current item's weight is less than or equal to current capacity

                        // Choose maximum between including and excluding the item
                        dp1[i][v]= Math.max(
                            values[i - 1]+dp1[i - 1][v - intVolumes[i - 1]] , 
                            dp1[i - 1][v]                    
                        )
                    }
                    else{
                        dp1[i][v]=dp1[i - 1][v]// If item can't be included, carry forward the previous value
                    }
                }
            }

                      
            // Backtrack to find which items were selected
            let remainingCapacity = intCapacity;
            const selectedIndicesVols = [];
            let totalScaledWeight = 0;
            let totalValue = 0;

            for(let i = n; i > 0 && remainingCapacity > 0; i--){
                if(dp1[i][remainingCapacity]!==dp1[i-1][remainingCapacity]){
                    selectedIndicesVols.push(i - 1);
                    // totalScaledWeight += intVolumes[i - 1];
                    // totalValue += values[i - 1];
                    remainingCapacity -= intVolumes[i - 1];
                }
            }
            
            // ---- Stage 2: Knapsack by WEIGHT on CANDIDATES only ----
            const intWeights = weights.map(w =>Math.round(w*PRECISION))
            const intMaxWeight = Math.round(maxWeight*PRECISION)
            const candWeights = selectedIndicesVols.map(i=>Math.round(intWeights[i]))

            console.log("candWeights0",candWeights)
            console.log("intMaxWeight",intMaxWeight)
            const m = selectedIndicesVols.length
            if(m===0){
                return { maxValue: 0, selectedIndices: [], totalWeight: 0, totalVolume: 0 };
            }

            const dp2 = Array.from({ length: m + 1 }, () => Array(intMaxWeight + 1).fill(0));
            for(let i = 1; i<=m; i++){
                for(let z = 0; z<=intMaxWeight; z++){
                    if(candWeights[i - 1]<=z){
                        dp2[i][z] = Math.max(
                        values[i - 1] + dp2[i - 1][z - candWeights[i - 1]],
                        dp2[i - 1][z]
                    );
                    } else {
                        dp2[i][z] = dp2[i - 1][z];
                    }
                }
            }
            
            let remainingWeightCapacity = intMaxWeight;
            const finalIndices = [];
            for(let i = m ; i > 0 && remainingWeightCapacity > 0 ; i--){
                if(dp2[i][remainingWeightCapacity] !=dp2[i-1][remainingWeightCapacity]){
                    finalIndices.push(selectedIndicesVols[i - 1]); // map back to original index
                    remainingWeightCapacity -= candWeights[i - 1];
                }
            } 
            
            finalIndices.reverse();

            const totalWeight = finalIndices.reduce((sum, i) => sum + weights[i], 0);
            const totalVolume = finalIndices.reduce((sum, i) => sum + volumes[i], 0);
            const maxValue = dp2[m][intMaxWeight];

            return {
                maxValue,
                selectedIndices: finalIndices.reverse(),
                totalWeight,
                totalVolume
            };
        }
    
        const calculateOptimalOrders =()=>{
            if(!selectedVehicle){
                setError('Please select a vehicle first');
                return;
            }
    
            if (orderPlacements.length === 0) {
                setError('No orders available');
                return;
            }
    
            try{
                setLoading(true)
                setError('')

                // Calculate weight for each order
                const orderWeights = orderPlacements.map(order =>{
                    return order.OrderItems.WeightPerItem*order.OrderItems.Quantity || 0
                })

                //Calculate volume for each order
                const orderVolumes =  orderPlacements.map(order =>{
                    return ((order.OrderItems.OrderDimension.Height*order.OrderItems.OrderDimension.Length*order.OrderItems.OrderDimension.Width)/10000)     || 0
                })
                
                // const values = orderPlacements.map(order=>Math.round(parseFloat(order.Price)))
                const values = orderPlacements.map(order=>Math.round((order.Price)))

                // Calculate vehicle capacity
                const vehicleMaxWeight = (selectedVehicle.MaxWeight)
                const vehicleVolume = ((selectedVehicle.Length * selectedVehicle.Width * selectedVehicle.Height)/10000)// convert to meters                 
            
                if (orderWeights.some(isNaN) || orderVolumes.some(isNaN) || values.some(isNaN) || isNaN(vehicleVolume) || isNaN(vehicleMaxWeight)) {
                    console.log("Invalid data detected. Please check weights, volumes, prices, and capacity")
                    throw new Error('Invalid data detected. Please check weights, volumes, prices, and capacity.');
                }
                
                const result = solve2DKnapsack(orderWeights, orderVolumes, values, vehicleMaxWeight, vehicleVolume);
                
                const selectedOrderItems = result.selectedIndices.map(index => orderPlacements[index]);
                //console.log("selectedOrderItems", selectedOrderItems)
               
                setSelectedOrders(selectedOrderItems);
                console.log("Selected Orders:", selectedOrderItems)
                  
                setSolution({
                    maxValue: result.maxValue,
                    totalWeight: result.totalWeight,
                    totalVolume: result.totalVolume,
                    weightCapacity: vehicleMaxWeight,
                    volumeCapacity: vehicleVolume,
                    selectedOrders: selectedOrderItems
                })
            }
             catch (err) {
                console.error('Error calculating optimal orders:', err);
                setError(err.message);
            } finally {
                setLoading(false);
            }
        }
       
        const ClaimMyOrders =async()=>{
            if(selectedOrders!=null){
                const PlacementIds = selectedOrders.map(order=>order.Id)
                try{
                    const id = selectedOrders[0].Id;
        
                    for(const item of selectedOrders){
                        console.log("Hey", item)
                        const updateItem={
                            CompletedOn:item.CompletedOn,
                            CreatedAt:item.CreatedAt,
                            CustomerId:item.CustomerId,
                            DeliveryContact:item.DeliveryContact,
                            DeliveryUpAddress:item.DeliveryUpAddress,
                            Description:item.Description,
                            PickUpAddress:item.PickUpAddress,
                            PickUpContact:item.PickUpContact,
                            Price:item.Price,
                            ScheduledAt:item.ScheduledAt,
                            Status:item.Status,
                            DriverId:parseInt(DriverId)
                        }
                        await axios.put(`${url}/OrderPlacement/Editing-Order-PlacementAddresses`,updateItem,{
                            params:{
                                Id:parseInt(item.Id)
                            }
                        });
                    }
                    
                    alert("Успешно заявленные заказы")
                }
                catch(e){
                    console.log("ERROR", e.message)
                }
            }          
        }
        useEffect(()=>{
            getAllDriverRecords()
            getAllOrderPlacementRecords()       
        }, [DriverId])


        
       return(

        <div className="knapsack-container">
            <header className="knapsack-header">
                <h1>Vehicle Capacity Optimization</h1>
                <p>Select a vehicle and find the optimal set of orders to maximize value</p>
            </header>

            {error && (
                <div className="error">
                    {error}
                </div>
            )}

            <section className="controls-section">
                <div className="vehicle-selection">
                    <label htmlFor="vehicle-select">Select Vehicle:</label>
                    <select 
                        id="vehicle-select"
                        value={selectedVehicle?.Id || ''}
                        onChange={(e) => {
                            const vehicle = vehicleRecords.find(v => v.Id === Number(e.target.value));
                            console.log("vehicleRecords",vehicleRecords.find(v => v.Id === Number(e.target.value)) )
                            setSelectedVehicle(vehicle);
                        }}
                        disabled={loading}
                    >
                        {vehicleRecords.map(vehicle => (
                            <option key={vehicle.Id} value={vehicle.Id}>
                                {vehicle.Brand} {vehicle.Model} - Capacity: {vehicle.MaxWeight}kg, Volume: {(vehicle.Length * vehicle.Width * vehicle.Height / 10000).toFixed(2)}m³
                            </option>
                        ))}
                    </select>
                    
                    {selectedVehicle && (
                        <div className="vehicle-info">
                            <h4>Selected Vehicle Details</h4>
                            <div className="vehicle-details">
                                <div className="vehicle-detail">
                                    <strong>Brand:</strong> {selectedVehicle.Brand}
                                </div>
                                <div className="vehicle-detail">
                                    <strong>Model:</strong> {selectedVehicle.Model}
                                </div>
                                <div className="vehicle-detail">
                                    <strong>Max Weight:</strong> {selectedVehicle.Max_Weight}kg
                                </div>
                                <div className="vehicle-detail">
                                    <strong>Dimensions:</strong> {selectedVehicle.Length}×{selectedVehicle.Width}×{selectedVehicle.Height}cm
                                </div>
                                <div className="vehicle-detail">
                                    <strong>Volume:</strong> {(selectedVehicle.Length * selectedVehicle.Width * selectedVehicle.Height / 1000000).toFixed(2)}m³
                                </div>
                            </div>
                            </div>
                    )}
                </div>

                <button 
                    className="calculate-button"
                    onClick={calculateOptimalOrders}
                    disabled={loading || !selectedVehicle || orderPlacements.length === 0}
                >
                    {loading ? 'Calculating...' : 'Calculate Optimal Orders'}
                </button>
                <button className="claim" onClick={()=>ClaimMyOrders()} >Claim Orders</button>
            </section>


             <section className="orders-section">
                <div className="section-header">
                    <h2>Available Orders ({orderPlacements.length})</h2>
                </div>
                
                {orderPlacements.length === 0 ? (
                    <div className="no-orders">
                        No orders available
                    </div>
                ) : (
                    <div className="orders-grid">
                        {orderPlacements.map((order, index) => {
                            // Calculate order weight and volume
                            let orderWeight = order.OrderItems.WeightPerItem * order.OrderItems.Quantity || 0
                            let orderVolume = ((order.OrderItems.OrderDimension.Height * order.OrderItems.OrderDimension.Length  *order.OrderItems.OrderDimension.Width) / 10000) || 0
                 
                            return (
                                <div 
                                    key={order.Id} 
                                    className={`order-card ${
                                        selectedOrders.some(so => so.Id === order.Id) ? 'selected' : ''
                                    }`}
                                >
                                    <div className="order-header">
                                        <span className="order-id">Order #{order.Id}</span>
                                    </div>
                                    <div className="order-details">
                                        <div className="order-detail">
                                            <label>Weight</label>
                                            <span>{orderWeight.toFixed(2)} kg</span>
                                        </div>
                                        <div className="order-detail">
                                            <label>Volume</label>
                                            <span>{orderVolume.toFixed(2)} m³</span>
                                        </div>
                                        <div className="order-detail">
                                            <label>Price</label>
                                            <span>${order.Price}</span>
                                        </div>
                                    </div>
                                </div>
                            );
                        })}
                    </div>
                )}
            </section>

            {solution && (
                <section className="solution-section">
                    <div className="section-header">
                        <h2>Optimal Solution</h2>
                        <span>Selected Orders: {solution.selectedOrders.length}</span>
                    </div>

                    <div className="solution-stats">
                        <div className="stat-card">
                            <h3>Total Weight</h3>
                            <p className="value">${solution.totalWeight.toFixed(2)} kg</p>
                            <p className="sub-value">of {solution.weightCapacity} kg</p>
                        </div>

                        <div className="stat-card">
                            <h3>Total Weight</h3>
                            <p className="value">{solution.totalWeight} kg</p>
                        </div>

                         <div className="stat-card">
                            <h3>Total Volume</h3>
                            <p className="value">{solution.totalVolume} m³</p>
                            <p className="sub-value">of {solution.volumeCapacity} m³</p>
                        </div>

                        <div className="stat-card">
                            <h3>Weight Used</h3>
                            <p className="value">
                                {((solution.totalWeight / solution.weightCapacity) * 100).toFixed(1)}%
                            </p>
                        </div>

                        <div className="stat-card">
                            <h3>Volume Used</h3>
                            <p className="value">
                                {((solution.totalVolume / solution.volumeCapacity) * 100).toFixed(1)}%
                            </p>
                        </div>
                        <div className="stat-card">
                            <h3>Orders Selected</h3>
                            <p className="value">
                                {solution.selectedOrders.length} / {orderPlacements.length}
                            </p>
                        </div>
                    </div>

                    {solution.selectedOrders.length > 0 ? (
                        <table className="selected-orders-table">
                            <thead>
                                <tr>
                                    <th>Order ID</th>
                                    <th>Weight (kg)</th>
                                    <th>Price ($)</th>
                                    <th>Value/Unit</th>
                                </tr>
                            </thead>
                            <tbody>
                                {solution.selectedOrders.map(order => {
                                    let orderWeight = order.OrderItems.WeightPerItem * order.OrderItems.Quantity || 0
                                    let orderVolume = ((order.OrderItems.OrderDimension.Height * order.OrderItems.OrderDimension.Length  *order.OrderItems.OrderDimension.Width) / 10000) || 0
                                    
                                    return (
                                        <tr key={order.Id}>
                                            <td>{order.Id}</td>
                                            <td>{orderWeight.toFixed(2)}</td>
                                            <td>{orderVolume.toFixed(2)}</td>
                                            <td>${order.Price}</td>
                                            <td>${(order.Price / (orderWeight + orderVolume)).toFixed(2)}</td>
                                        </tr>
                                    );
                                })}
                                <tr style={{backgroundColor: '#f8f9fa', fontWeight: 'bold'}}>
                                    <td>Total</td>
                                    <td>{solution.totalWeight} kg</td>
                                    <td>{solution.totalVolume} m³</td>
                                    <td>${solution.maxValue}</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>
                    ) : (
                        <div className="no-orders">
                            No orders can be selected with the current capacity
                        </div>
                    )}
                </section>
            )}
            {loading && (
                <div className="loading">
                    Loading data...
                </div>
            )}
        </div>
    );
}
export default KnapsackAlgorithm

