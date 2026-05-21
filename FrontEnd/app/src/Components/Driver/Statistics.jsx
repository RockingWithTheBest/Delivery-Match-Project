import axios from "axios"
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import './Statistics.css'

const Statistics =()=>{
    const {DriverId} = useParams()
    const api = "https://localhost:7216/api"
    const [earnings, setEarnings] =  useState({
        confirmedOrders:[],
        cancelledOrders:[],
        pendingOrders:[],
        intransitOrders:[],
        deliveredOrders:[]
    })
    const [loading, setLoading] = useState(true)

    const gettingEarningsByDriver = async()=>{
        try{  
            setLoading(true)      
            const response = await axios.get(`${api}/Earning/getting-earning-divisions-by-driverId-orderplacements`,{
                params:{
                    DriverId: parseInt(DriverId)
                }
            })
            setEarnings(response.data)
            console.log("Earnings", response.data)
        }
        catch(error){
            console.log("Error", error)
        }
        finally{
            setLoading(false)
        }
    }

    useEffect(()=>{
        gettingEarningsByDriver()
    },[DriverId])

    const calculateTotal = (orders) => {
        let sum = 0
        console.log("orders",orders.length)
        for(let i = 0; i < orders.length; i++){
            sum+=orders[i].Amount
        }

        return sum
    }

    const confirmedTotal = calculateTotal(earnings.confirmedOrders)
    const cancelledTotal = calculateTotal(earnings.cancelledOrders)
    const pendingTotal = calculateTotal(earnings.pendingOrders)
    const intransitTotal = calculateTotal(earnings.intransitOrders)
    const deliveredTotal = calculateTotal(earnings.deliveredOrders)

    const grandTotal = confirmedTotal + cancelledTotal + pendingTotal + intransitTotal + deliveredTotal

    if(loading){
        return(
            <div className="statistics-loading-earning">
                <div className="spinner-earning">
                    <p>Loading earnings data...</p>
                </div>
            </div>
        )
    }

    return(
        <div>
            {earnings ?(
                <div className="statistics-container-earning">
                    <div className="statistics-header-earning">
                        <h1>Earnings Overview</h1>
                        <div className="grand-total-card-earning">
                            <span className="grand-total-label-earning">Total Earnings</span>
                            <span className="grand-total-amount-earning">{grandTotal.toFixed(2)}</span>
                        </div>
                    </div>

                    <div className="statistics-grid-earning">
                        {earnings.confirmedOrders && (
                            <div className="sta-card confirmed-earning">
                                <div className="card-header-earning">
                                    <div className="card-icon-earning">✓</div>
                                    <h2>Confirmed Orders</h2>
                                </div>

                                <div className="card-total-earning">
                                    <span className="total-label-earning">Total Amount</span>
                                    <span className="total-amount-earning">{confirmedTotal.toFixed(2)}</span>
                                </div>

                                <div className="orders-list-earning">
                                    {earnings.confirmedOrders.map((order,index)=>(
                                        <div  key={order.StatusEarningId || index}  className="order-item-earning">
                                            <span className="order-status-earning">{order.Status}</span>
                                            <span className="order-amount-earning">{order.Amount.toFixed(2)}</span>
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}

                    {earnings.deliveredOrders && (
                            <div className="sta-card delivered-earning">
                                <div className="card-header-earning">
                                    <div className="card-icon-earning">📦</div>
                                    <h2>Delivered Orders</h2>
                                </div>

                                <div className="card-total-earning">
                                    <span className="total-label-earning">Total Amount</span>
                                    <span className="total-amount-earning">{deliveredTotal.toFixed(2)}</span>
                                </div>

                                <div className="orders-list-earning">
                                    {earnings.deliveredOrders.map((order,index)=>(
                                        <div  key={order.StatusEarningId || index}  className="order-item-earning">
                                            <span className="order-status-earning">{order.Status}</span>
                                            <span className="order-amount-earning">{order.Amount.toFixed(2)}</span>
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}

                        {earnings.intransitOrders && (
                            <div className="sta-card intransit-earning">
                                <div className="card-header-earning">
                                    <div className="card-icon-earning">🚚</div>
                                    <h2>In Transit Orders</h2>
                                </div>

                                <div className="card-total-earning">
                                    <span className="total-label-earning">Total Amount</span>
                                    <span className="total-amount-earning">{intransitTotal.toFixed(2)}</span>
                                </div>

                                <div className="orders-list-earning">
                                    {earnings.intransitOrders.map((order,index)=>(
                                        <div  key={order.StatusEarningId || index}  className="order-item-earning">
                                            <span className="order-status-earning">{order.Status}</span>
                                            <span className="order-amount-earning">{order.Amount.toFixed(2)}</span>
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}

                        {earnings.pendingOrders && (
                            <div className="sta-card confirmed-earning">
                                <div className="card-header-earning">
                                    <div className="card-icon-earning">⏳</div>
                                    <h2>Pending Orders</h2>
                                </div>

                                <div className="card-total-earning">
                                    <span className="total-label-earning">Total Amount</span>
                                    <span className="total-amount-earning">{pendingTotal.toFixed(2)}</span>
                                </div>

                                <div className="orders-list-earning">
                                    {earnings.pendingOrders.map((order,index)=>(
                                        <div  key={order.StatusEarningId || index}  className="order-item-earning">
                                            <span className="order-status-earning">{order.Status}</span>
                                            <span className="order-amount-earning">{order.Amount.toFixed(2)}</span>
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}

                        {earnings.cancelledOrders && (
                            <div className="sta-card confirmed-earning">
                                <div className="card-header-earning">
                                    <div className="card-icon-earning">❌</div>
                                    <h2>Cancelled Orders</h2>
                                </div>

                                <div className="card-total-earning">
                                    <span className="total-label-earning">Total Amount</span>
                                    <span className="total-amount-earning">{cancelledTotal.toFixed(2)}</span>
                                </div>

                                <div className="orders-list-earning">
                                    {earnings.cancelledOrders.map((order,index)=>(
                                        <div  key={order.StatusEarningId || index}  className="order-item-earning">
                                            <span className="order-status-earning">{order.Status}</span>
                                            <span className="order-amount-earning">{order.Amount.toFixed(2)}</span>
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}
                    </div>
                </div>
            ):(
                <div>
                    <p>No Earnings avaiables</p>
                </div>
            )}
        </div>
    )
}
export default Statistics