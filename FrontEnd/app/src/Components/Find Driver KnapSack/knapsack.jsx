import React,{useEffect,useState} from 'react'
import 'reactjs-popup/dist/index.css';
import axios from 'axios'
import './knapsack.css'


const KnapsackProblem = () => {
    const [vehicleRecords,setVehicleRecords] = useState([])
    const [orderPlacements, setOrderPlacementRecords]=useState([])
    const [selectedVehicle, setSelectedVehicle] = useState(null)
    const [selectedOrders, setSelectedOrders] = useState([]);
    const [solution, setSolution] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

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
            setOrderPlacementRecords(api_response.data)
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

    const solveKnapsack=(densities, values, vehicleCapacity)=>{
       
        const n = densities.length;

        // Create DP table with n+1 rows and capacity+1 columns
        const dp = Array.from({length:n+1}, ()=>Array(vehicleCapacity+1).fill(0))
        
        for( let i = 1 ; i <= n ; i++){
            for(let w = 0 ; w <= vehicleCapacity ; w++){

                if(densities[i - 1] <= w){// If current item's weight is less than or equal to current capacity

                    // Choose maximum between including and excluding the item
                    dp[i][w]= Math.max(
                        values[i - 1]+dp[i - 1][w - densities[i - 1]] , 
                        dp[i - 1][w]                    
                    )
                }
                else{
                    dp[i][w]=dp[i - 1][w]// If item can't be included, carry forward the previous value
                }
            }
        }
        
        // Backtrack to find which items were selected
        let remainingCapacity = vehicleCapacity;
        const selectedIndices = [];
        let totalWeight = 0;
        let totalValue = 0;

        for(let i = n; i > 0 && remainingCapacity > 0; i--){
            if(dp[i][remainingCapacity]!==dp[i-1][remainingCapacity]){
                selectedIndices.push(i - 1);
                totalWeight += densities[i - 1];
                totalValue += values[i - 1];
                remainingCapacity -= densities[i - 1];
            }
        }

        return{
            maxValue: dp[n][vehicleCapacity],
            selectedIndices: selectedIndices.reverse(),
            totalWeight: totalWeight
        }
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

            const orderDensity = orderPlacements.map(order=>Math.round(parseFloat(order.Weight/order.Volume)))
            const values = orderPlacements.map(order=>Math.round(parseFloat(order.Price)))
            const vehicleCapacity = Math.round(parseFloat(selectedVehicle.Max_Weight/selectedVehicle.Max_Volume))
            console.log(vehicleCapacity)

            if (orderDensity.some(isNaN) || values.some(isNaN) || isNaN(vehicleCapacity)) {
                throw new Error('Invalid data detected. Please check density, prices, and capacity.');
            }

            const result = solveKnapsack(orderDensity, values, vehicleCapacity);
            const selectedOrderItems = result.selectedIndices.map(index => orderPlacements[index]);
            setSelectedOrders(selectedOrderItems);

            setSolution({
                maxValue: result.maxValue,
                totalDensity: result.totalDensity,
                capacity: vehicleCapacity,
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
   

    useEffect(()=>{
        getAllDriverRecords()
        getAllOrderPlacementRecords()       
    }, [])


    
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
                                {vehicle.Name || `Vehicle ${vehicle.Id}`} - Capacity: {vehicle.Max_Weight}kg
                            </option>
                        ))}
                    </select>
                    
                    {selectedVehicle && (
                        <div className="vehicle-info">
                            <h4>Selected Vehicle Details</h4>
                            <div className="vehicle-details">
                                <div className="vehicle-detail">
                                    <strong>Max Weight:</strong> {selectedVehicle.Max_Weight}kg
                                </div>
                                <div className="vehicle-detail">
                                    <strong>Vehicle ID:</strong> {selectedVehicle.Id}
                                </div>
                                {selectedVehicle.Model && (
                                    <div className="vehicle-detail">
                                        <strong>Model:</strong> {selectedVehicle.Model}
                                    </div>
                                )}
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
            </section>

            <section className="orders-section">
                <div className="section-header">
                    <h2>Available Orders ({orderPlacements.length})</h2>
                    <span>Total Orders: {orderPlacements.length}</span>
                </div>
                
                {orderPlacements.length === 0 ? (
                    <div className="no-orders">
                        No orders available
                    </div>
                ) : (
                    <div className="orders-grid">
                        {orderPlacements.map((order, index) => (
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
                                        <span>{order.Weight} kg</span>
                                    </div>
                                    <div className="order-detail">
                                        <label>Price</label>
                                        <span>${order.Price}</span>
                                    </div>
                                </div>
                            </div>
                        ))}
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
                            <h3>Maximum Value</h3>
                            <p className="value">${solution.maxValue}</p>
                        </div>
                        <div className="stat-card">
                            <h3>Total Weight</h3>
                            <p className="value">{solution.totalWeight} kg</p>
                        </div>
                        <div className="stat-card">
                            <h3>Capacity Used</h3>
                            <p className="value">
                                {((solution.totalWeight / solution.capacity) * 100).toFixed(1)}%
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
                                    <th>Value per kg</th>
                                </tr>
                            </thead>
                            <tbody>
                                {solution.selectedOrders.map(order => (
                                    <tr key={order.Id}>
                                        <td>{order.Id}</td>
                                        <td>{order.Weight}</td>
                                        <td>${order.Price}</td>
                                        <td>${(order.Price / order.Weight).toFixed(2)}</td>
                                    </tr>
                                ))}
                                <tr style={{backgroundColor: '#f8f9fa', fontWeight: 'bold'}}>
                                    <td>Total</td>
                                    <td>{solution.totalWeight} kg</td>
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
};
export default  KnapsackProblem;

