import axios from "axios"
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import jsPDF from 'jspdf'
import { format } from 'date-fns';
import autoTable from 'jspdf-autotable';
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
            
            const driverRecord = await axios.get("https://localhost:7216/api/Driver/get-driver-byUserId",{
                params:{
                    UserId:parseInt(DriverId)
                }
            }) 

            const response = await axios.get(`${api}/Earning/getting-earning-divisions-by-driverId-orderplacements`,{
                params:{
                    DriverId: parseInt(driverRecord.data.Id)
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

    const exportToPDF = ()=>{
        try{
            const doc = new jsPDF('landscape')

            //Add header
            doc.setFontSize(20)
            doc.setTextColor(40, 40, 40)
            doc.text('Earnings report', 14, 22)

            //Adding logo
            doc.setFontSize(10)
            doc.text('ClydeDelivery', 14, 42)
            doc.text(`Generated: ${format(new Date(), 'MMM dd, yyyy HH:mm')}`, 14, 48);

            const tableData = []

            earnings.confirmedOrders.forEach(order=>{
                tableData.push({
                    Amount:order.Amount,
                    Status:order.Status,
                    StatusEarningId:order.StatusEarningId
                })
            })
            console.log("Es",tableData)

            earnings.cancelledOrders.forEach(order=>{
                tableData.push({
                    Amount:order.Amount,
                    Status:order.Status,
                    StatusEarningId:order.StatusEarningId
                })
            })

            earnings.pendingOrders.forEach(order=>{
                tableData.push({
                    Amount:order.Amount,
                    Status:order.Status,
                    StatusEarningId:order.StatusEarningId
                })
            })

            earnings.intransitOrders.forEach(order=>{
                tableData.push({
                    Amount:order.Amount,
                    Status:order.Status,
                    StatusEarningId:order.StatusEarningId
                })
            })

            earnings.deliveredOrders.forEach(order=>{
                tableData.push({
                    Amount:order.Amount,
                    Status:order.Status,
                    StatusEarningId:order.StatusEarningId
                })
            })

            const finalData = tableData.map(record=>[
                record.StatusEarningId,
                record.Status,
                record.Amount
            ])
            autoTable(doc,{
                startY:55,
                head:[['No.Earnings', 'Amount', 'Status']],
                body:finalData,
                theme:'grid',
                headStyles: {
                    fillColor: [41, 128, 185],
                    textColor: 255,
                    fontStyle: 'bold'
                },
                columnStyles: {
                    0: { cellWidth: 40 },
                    1: { cellWidth: 30 },
                    2: { cellWidth: 35 },
                },
                margin: { top: 10 },
                styles: {
                    fontSize: 9,
                    cellPadding: 3
                },
                idDrawPage: function (data) {
                    // Footer
                    const pageCount = doc.internal.getNumberOfPages();
                    doc.setFontSize(8);
                    doc.setTextColor(150, 150, 150);
                    doc.text(
                        `Page ${data.pageNumber} of ${pageCount}`,
                        data.settings.margin.left,
                        doc.internal.pageSize.height - 10
                    );
                    doc.text(
                        '© Clyde Delivery - Confidential',
                        doc.internal.pageSize.width - 60,
                        doc.internal.pageSize.height - 10
                    );
                }
            })

            // Add summary
            const finalY = doc.lastAutoTable.finalY || 55;
            doc.setFontSize(11);
            doc.setTextColor(40, 40, 40);
            doc.text(`Total Transactions: ${tableData.length}`, 14, finalY + 15);

            console.log("FINAL", tableData)
            // let totalAmount = 0;
            // for(let i = 0; i<= tableData.length; i++){
            //     totalAmount = totalAmount + tableData[i].Amount
            // }
            doc.text(`Total Amount: $${grandTotal}`, 14, finalY + 25);
            
            // Save PDF
            const fileName = `transactions_${format(new Date(), 'yyyy-MM-dd_HHmm')}.pdf`;
            doc.save(fileName);

        }
        catch(error){
            console.log(error)
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
                        <button onClick={()=>exportToPDF()}>Earnings Report</button>
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