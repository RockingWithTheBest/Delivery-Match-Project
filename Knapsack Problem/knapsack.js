class OrderPlacement{
    constructor(id, pickUpAddress, deliveryAddress,weight, price){
        this.id = id
        this.pickUpAddress = pickUpAddress
        this.deliveryAddress = deliveryAddress
        this.weight = weight
        this.price = price
    }
}

class Vehicle{
    constructor(id, maxWeight){
        this.id = id
        this.maxWeight = maxWeight
    }
}

function knapsack(weights, values, capacity){
    const n = weights.length;
    const dp = Array.from({length:n+1}, ()=>Array(capacity+1).fill(0))

     for( let i = 1 ; i <= n ; i++){
        for(let w = 0 ; w <= capacity ; w++){
            if(weights[i - 1] <= w){
                dp[i][w]= Math.max(
                    values[i - 1]+dp[i - 1][w - weights[i - 1]] , dp[i - 1][w]                    
                )
            }
            else{
                  dp[i][w]=dp[i - 1][w]
            }
        }
    }
    
    // Determine which orders were included
    let remainingCapacity = capacity;
    const selectedOrders = [];

    for(let i = n; i>0 ; i--){
        if(dp[i][remainingCapacity]!=dp[i-1][remainingCapacity]){
            selectedOrders.push(i - 1);
            remainingCapacity = remainingCapacity - weights[i-1]
        }
    }

    return{
        maxValue: dp[n][capacity],
        selectedOrders: selectedOrders.reverse()
    }
}

// Sample data with more orders
const orders = [
    new OrderPlacement(1, "Address A", "Address B", 5, 10),
    new OrderPlacement(2, "Address C", "Address D", 10, 20),
    new OrderPlacement(3, "Address E", "Address F", 15, 30),
    new OrderPlacement(4, "Address G", "Address H", 8, 15),
    new OrderPlacement(5, "Address I", "Address J", 12, 25),
    new OrderPlacement(6, "Address K", "Address L", 3, 5),
    new OrderPlacement(7, "Address M", "Address N", 7, 18),
    new OrderPlacement(8, "Address O", "Address P", 4, 12),
    new OrderPlacement(9, "Address Q", "Address R", 1, 2)
];

const vehicle = new Vehicle(1, 50); // Increased max weight

const weights = orders.map(order=>order.weight)
const values = orders.map(order=>order.price)

const result = knapsack(weights, values,vehicle.maxWeight)
console.log(`Maximum value that can be carried: ${result.maxValue}`);
console.log('Orders to be placed in the vehicle:');

result.selectedOrders.forEach(index=>{
    const order = orders[index]
    console.log(`Order ID: ${order.id}, Weight: ${order.weight}, Price: ${order.price}`);
})