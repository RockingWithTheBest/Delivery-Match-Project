import axios from "axios";
import {useNavigate} from 'react-router-dom'
import React, { useState } from "react";
import './PasswordChanger.css'

const PasswordChanger = ({openPassword, setOpenPassword}) =>{
    const url = "https://localhost:7216/api"
    const navigate = useNavigate()

    //State varaibles
    const [userId, setUserId] = useState("")
    const [password, setPassword] = useState("")
    const handlePasswordChange=async()=>{
        try{
            await axios.put(`${url}/User/PasswordChanger`,null,{
                params:{
                    UserId: parseInt(userId),
                    Password: password
                }
            })
            setOpenPassword(false)
            
            alert("Success")
            //navigate('/authpage')
        }
        catch(error){
            console.log("Message", error)
            alert("Error")
        }
    }

    const handleClose = () => {
        setOpenPassword(false);
    }
    
    return (
        <div className="password-resetter-div">
            <div className="proceed-entering">
                <h4 className="proceed-entering-header">Proceed in entering the details to change your password
                    <button className="close-button" onClick={handleClose}>×</button>
                </h4>
            </div>
            <div className="user-identify-password">
            {/* <form action=""> */}
                <label htmlFor="">User Identification</label>
                <input type="text" onChange={(e)=>setUserId(e.target.value)} />
                <label htmlFor="">New Password</label>
                <input type="text"  onChange={(e)=>setPassword(e.target.value)} />
                <button className="submit-changes"onClick={()=>handlePasswordChange()}>Submit Change</button>
            {/* </form> */}
            </div>


        </div>
    )
}

export default PasswordChanger