import axios from "axios"
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"

const Documents =()=>{
    const url = "https://localhost:7216/api"
    const {DriverId} = useParams()
    const [document, setDocuments]= useState(null)
    const getDoc = async()=>{
        const response =  await axios.get(`${url}/Document/Get-Single-Doc`,{
            params:{
                DriverId:parseInt(DriverId)
            }
        })
        setDocuments(response.data)
    }

    useEffect(()=>{
        getDoc()
    },DriverId)

    return(
        <div>Document</div>
    )
}
export default Documents