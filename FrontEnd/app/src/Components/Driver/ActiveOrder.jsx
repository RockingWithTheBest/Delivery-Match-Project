import Knapsack from './Knapsack'
import React,{useState} from 'react'
import './DriverStyles.css'
import OrderTimeLineView from './OrderTimeLineView'

const ActiveOrders=()=>{
    const [sack, setSack]= useState(false)
    const openSack=()=>{
        setSack(!sack)
    }

    return(
        <div className='active-order-sack'>
            <button onClick={()=>openSack()} className='sack-toggle-btn'>
                    {sack ? 'Close Order Sack' : 'Get my active order'}
                    <span className={`arrow ${sack ? 'down' : 'up'}`}>
                    {sack ? '▼' : '▲'}
                    </span>
            </button>
            <div className={`knapsack-container ${sack ? 'open':'closed'}`}>
                <Knapsack/>
            </div>
            <div className="view-order-timeline">
                <OrderTimeLineView/>                
            </div>
        </div>
    )
}
export default ActiveOrders

