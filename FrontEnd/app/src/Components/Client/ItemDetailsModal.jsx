import React, { useState } from "react";
import './ItemDetailsModal.css'
import { useParams } from "react-router-dom";
import axios from "axios";

const ItemDetailsModal = ({ isOpen, onClose,Order_PlacementId }) => {
    const [itemName, setItemName] = useState("");
    const [itemLength, setItemLength] = useState("");
    const [itemWidth, setItemWidth] = useState("");
    const [itemHeight, setItemHeight] = useState("");
    const [itemWeight, setItemWeight] = useState("");
    const [itemQuantity, setItemQuantity] = useState("");
     const [specialInstructions, setSpecialInstructions] = useState({
        fragile: false,
        refrigerated: false,
        oversized: false
    });
    const url = "https://localhost:7216/api"

    if (!isOpen) return null;

    const handleSubmitItems = async(e)=>{
        e.preventDefault();
        console.log("Order_PlacementId",parseInt(Order_PlacementId))
         
        try{
            // Convert checkboxes to string
            const instructions = Object.entries(specialInstructions)
                .filter(([_, value]) => value)
                .map(([key]) => {
                    switch(key) {
                        case 'fragile': return 'Fragile Items';
                        case 'refrigerated': return 'Refrigerated Transport';
                        case 'oversized': return 'Oversized Item';
                        default: return key;
                    }
                })
                .join(', ');

            const itemOrder = {
                ItemName:itemName,
                Quantity:parseInt(itemQuantity),
                WeightPerItem:parseFloat(itemWeight),
                SpecialInstructions:instructions,
                orderDimension:{
                    Length:parseFloat(itemLength),
                    Height:parseFloat(itemHeight),
                    Width:parseFloat(itemWidth)
                },                
                OrderPlacementId:parseInt(Order_PlacementId)
            }
            await axios.post(`${url}/OrderItems/Add-OrderItems`,itemOrder)
            alert("Successfully added Items!!")
            onClick()}
        catch(e){
            console.log("ERROR", e.Message)
        }
    }

    const handleCheckboxChange = (instruction) => {
        setSpecialInstructions(prev => ({
            ...prev,
            [instruction]: !prev[instruction]
        }));
    };
    
    return(
         <div className="modal-overlay">
            <form onSubmit={handleSubmitItems}className="modal-content">
                <h3>Enter Order Item Details</h3>
                <div className="modal-inputs">
                    <div className="input-group">
                        <label>Item Name</label>
                        <input
                            type="text"
                            placeholder="Enter item name"
                            value={itemName}
                            onChange={(e) => setItemName(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Length (cm)</label>
                        <input
                            type="number"
                            placeholder="Enter length"
                            value={itemLength}
                            onChange={(e) => setItemLength(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Width (cm)</label>
                        <input
                            type="number"
                            placeholder="Enter width"
                            value={itemWidth}
                            onChange={(e) => setItemWidth(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Height (cm)</label>
                        <input
                            type="number"
                            placeholder="Enter height"
                            value={itemHeight}
                            onChange={(e) => setItemHeight(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Weight per Item(kg)</label>
                        <input
                            type="number"
                            placeholder="Enter weight"
                            value={itemWeight}
                            onChange={(e) => setItemWeight(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Quantity</label>
                        <input
                            type="number"
                            placeholder="Enter quantity"
                            value={itemQuantity}
                            onChange={(e) => setItemQuantity(e.target.value)}
                        />
                    </div>
                    <div className="input-group">
                        <label>Special Instructions</label>
                        <div className="checkbox-group">
                            <label htmlFor="" className="checkbox-label">
                                <input
                                    type="checkbox"
                                    placeholder=""
                                    checked={specialInstructions.fragile}
                                    onChange={(e) => handleCheckboxChange("fragile")}
                                />
                                Fragile Items
                            </label>
                            <label htmlFor="" className="checkbox-label">
                                <input
                                    type="checkbox"
                                    placeholder=""
                                    checked={specialInstructions.refrigerated}
                                    onChange={(e) => handleCheckboxChange("refrigerated")}
                                />
                                Refrigirated transport
                            </label>
                            <label htmlFor="" className="checkbox-label">
                                <input
                                    type="checkbox"
                                    placeholder=""
                                    checked={specialInstructions.oversized}
                                    onChange={(e) => handleCheckboxChange("oversized")}
                                />
                                Oversized item
                            </label>
                        </div>
                    </div>
                </div>
                <div className="modal-buttons">
                    <button type="button" onClick={onClose} className="cancel-btn">
                        Cancel
                    </button>
                    <button  type="submit" className="save-btn">
                        Save Details
                    </button>
                </div>
            </form>
        </div>
    )
}

export default ItemDetailsModal