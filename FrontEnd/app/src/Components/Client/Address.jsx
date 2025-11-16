import { useParams } from 'react-router-dom'
import LocationIcon from '../Icons/location-pin-alt-1-svgrepo-com.svg'
import './Address.css'
import { useEffect, useState } from 'react'
import axios from 'axios'
const Address =({customerDetails})=>{
    const {ClientId} = useParams()
    const [addresses, setAddresses]=useState([])
    const [label, setLabel]=useState('')
    const [city, setCity]=useState('')
    const [addressLine, setAddressLine]=useState('')
    const [message,setMessage] = useState('Not addresses to Display')
    const url = "https://localhost:7216/api/"

    const getAllAddressesByUserId = async()=>{

        const responseCustomer = await axios.get(`${url}Customer/Get-GetCustomerDetails-By-Id`,{
            params:{
                id:parseInt(ClientId)
            }
        })

        const responseUser = await axios.get(`${url}User/Get-Users-By-Id`,{
            params:{
                id:parseInt(responseCustomer.data.UserId)
            }
        })

        const responseAddress = await axios.get(`${url}Address/Get-Address-ListBy-UserId`,{
            params:{
                UserId:parseInt(responseUser.data.Id)
            }
        })

        console.log("Address", responseAddress.data.list)
        setAddresses(responseAddress.data.list)
    }
    
    // const notAddressesProvided =()=>{
    //     return(
    //         <div>
    //             <p>Not addresses to Display</p>
    //         </div>
    //     )
    // }
    useEffect(()=>{
        getAllAddressesByUserId()
    },[ClientId])
    return(
        <div className='addresses'>
            <div className='address-part-1'>
                <div>
                    <img src={LocationIcon} alt="" className="location-saved-address-icon" />
                    <p>Saved Addresses</p>
                </div>                
                <button className="saved-address">
                    Add Address
                </button>
            </div>            
                {addresses ? (
                    <div>{addresses.map(address=>(
                        <div className='addres-input-group' value={address.Id} key={address.Id}>
                            <input 
                                className='address-label'
                                type="text"
                                disabled={true}
                                value={address.Label}
                                onChange={()=>setLabel(e.target.value)} 
                            />
                            <input 
                                type="text"
                                disabled={true}
                                value={address.Address_Line}
                                onChange={()=>setAddressLine(e.target.value)} 
                            />
                            <input 
                                type="text"
                                disabled={true}
                                value={address.City} 
                                onChange={()=>setCity(e.target.value)}
                            />
                        </div>
                    ))}</div>
                ):(
                    <div>{message}</div>
                )}            
        </div>
    )
}
export default Address