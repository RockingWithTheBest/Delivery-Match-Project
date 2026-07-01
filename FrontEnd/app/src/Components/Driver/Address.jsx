import axios from "axios";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import AddressIcon from './Icons/address-svgrepo-com.png'
import './Address.css'

const Address =()=>{
    //state variables
    const [label,setAddressLabel] = useState("")
    const [location,setLocation]= useState("")
    const [longitude,setLongitude]= useState("")
    const [latitude,setLatitude]= useState("")
    const [btnName, setBtnName] =  useState("Edit Address")
    const [userId, setUserId] = useState("")
    const [disableTrue,setDisableToTrue] = useState(true)

    //state variables
    const [longitudeA, setLongitudeA] = useState("")
    const [locationA, setLocationA] = useState("")
    const [latitudeA, setLatitudeA] = useState("")
    const [labelA, setLabelA] = useState("")
    const [openModal, setOpenModal] = useState(false)
    
    //Notifications
    const [notification, setNotification] = useState({ show: false, message: '', type: 'info' });
    
    //address data
    const data = [
        {
            Id:1,
            Location:"Mogilev Hotel, Mogilev, Belarus",
            Latitude:53.910044,
            Longitude:30.332437,
        },
        {
            Id:2,
            Location:"Minsk Gates, Minsk, Belarus",
            Latitude:53.89199071093835,
            Longitude:27.55104917836086,
        },
        {
            Id:3,
            Location:"Konkovo District, Moscow, Russia",
            Latitude:55.6377564,
            Longitude:37.5113901,
        },
        {
            Id:4,
            Location:"Krylatskiye Kholmy street, Krylatskoye District, Moscow, Russia",
            Latitude:55.75968473520998,
            Longitude:37.42666021443734,
        },
        {
            Id:5,
            Location:"Street Kirowa 2, Minsk, Belarus",
            Latitude:53.8961884,
            Longitude:27.5574283,
        }
    ]
    //url
    const url ="https://localhost:7216/api"
    //params
    const {DriverId} = useParams()

    const addAddress = async() =>{
        try{        
            const record = {
                Label:labelA,
                Location:locationA,
                Latitude:latitudeA,
                Longitude:longitudeA,
                UserId:parseInt(DriverId)
            }

            axios.post(`${url}/Address/Add-Addresses`,record)
        }
        catch(err){
            console.log("Message", err)
        }
    }
    const getAddressesByDriverId = async()=>{
        const responseDriver = await axios.get(`${url}/Driver/get-driver-byUserId`,{
            params:{
                UserId:parseInt(DriverId)
            }
        })

        const responseUser = await axios.get(`${url}/User/Get-Users-By-Id`,{
            params:{
                id:parseInt(responseDriver.data.UserId)
            }
        })

        console.log(responseUser.data)
        setLocation(responseUser.data.Id)
        const responseAddress = await axios.get(`${url}/Address/Get-Addresses-By-UserId`,{
            params:{
                UserId:parseInt(responseUser.data.Id)
            }
        })        

        setUserId(responseDriver.data.UserId)
        setAddressLabel(responseAddress.data.Label)
        setLocation(responseAddress.data.Location)
    }

    const handleDriverLocationSetting =async(value)=>{
        try{
            console.log("Data",data)
            const addressData = data.find(f=>f.Id == value)
            const address = {
                Label: label,
                Location: addressData.Location,
                Latitude: addressData.Latitude,
                Longitude: addressData.Longitude,
            }
            
            console.log("ADDRESS000",address)
            await axios.put(`${url}/Address/Editing_Addresses`,address,{
                params:{
                    Id:parseInt(userId)
                }
            })
            alert("SUCCESS")
        }
        catch(err){
            console.log("Error Message",err)
        }
    }

    const handleEditAndDisableAddressData =()=>{
        if(disableTrue==true){
            setDisableToTrue(false)
            setBtnName("Save Address")
            handleDriverLocationSetting()
        }
        else if(disableTrue == false){
            setDisableToTrue(true)
            setBtnName("Edit Address")
        }
    }

    useEffect(()=>{
        getAddressesByDriverId()
        console.log("DATA", location)
    },[DriverId])

    useEffect(() => {    
        window.hideNotification = () => setNotification({ ...notification, show: false });
    }, [notification]);

    return(
        <div className="address-driver">
                <div  className="address-info-display">
                    <div>
                        <img src={AddressIcon} className="address-iicon" alt="" />
                        <p>Address Information</p>
                    </div>                    
                    
                <div className="address-add">
                    <button onClick={()=>handleEditAndDisableAddressData()}>{btnName}</button>
                    <button className="add-address-btn">
                        Add Address
                    </button>
                </div>
                </div> 
            <form action="" className="driver-address-form">
                
                <div className="input-group-info">
                    <label htmlFor="">Label</label>
                    <input 
                        type="text"
                        value={label}
                        onChange={(e)=>setAddressLabel(e.target.value)}
                        disabled={disableTrue}
                    />
                </div>
               
                <div className="input-group-info">
                    <label htmlFor="">Location</label>
                    <input 
                        type="text"
                        value={ location || ''}
                        //  onChange={(e)=>setLocation(e.target.value)}
                        disabled={disableTrue}
                    />
                </div>

                <div className="input-group-info">
                    <select 
                        name="" 
                        id=""
                        disabled={disableTrue}
                        value={location}
                        onChange={(e)=>{
                            const selectedId = parseInt(e.target.value)//convert to number
                            const selectedLocation = data.find(i=>i.Id === selectedId)

                            if(selectedLocation){
                                console.log("selectedLocation",selectedLocation.Location)
                                setLocation(selectedLocation.Location),
                                handleDriverLocationSetting(selectedId)
                            }
                        }
                    }>
                        <option value="">Select new Location</option>
                        {data.map(o=>(
                            <option key={o.Id} value={o.Id}>
                                {o.Location}
                            </option>
                        ))}
                    </select>
                </div>
            </form>
            {openModal &&
                <div onClick={()=>setOpenModal(false)}>
                    <div onClick={(e)=>e.stopPropagation()}>
                        <h3>Add New Address</h3>
                    </div>
                </div>
            }
        </div>
    )
}

export default Address