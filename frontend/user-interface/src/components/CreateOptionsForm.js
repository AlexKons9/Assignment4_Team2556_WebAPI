import React, { useState, useEffect } from "react";
import axios from "axios";
import { useParams } from "react-router-dom";

function CreateOptionsForm()
{ 
    const [optionDTO, setOptionDTO] = useState
        ({ questionId: useParams(), description1: "", description2: "", description3: "", description4: "", correctAnswer: "" });

    const handleChange = (event) => {
        const { name, value } = event.target;
        setOptionDTO({ ...optionDTO, [name]: value });
    };
    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await axios.post("https://localhost:7015/api/Options", optionDTO);
            alert("Options created successfully!");
        } catch (error) {
            console.error(error);
            alert("Error creating options");
        }
    };
        return (
            <>
            <form>
                    <input type="hidden" name="questionId" value={optionDTO.questionId} />
                <div className="form-group">
                    <label>Option 1</label>
                    <input className="form-control" type="text" name="description1" value={optionDTO.description1} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Option 2</label>
                    <input className="form-control" type="text" name="description2" value={optionDTO.description2} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Option 3</label>
                    <input className="form-control" type="text" name="description3" value={optionDTO.description3} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Option 4</label>
                    <input className="form-control" type="text" name="description4" value={optionDTO.description4} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Correct Answer</label>
                    <select className="form-control" name="correctAnswer" value={optionDTO.correctAnswer} onChange={handleChange}>
                        <option value={1}>Option 1</option>
                        <option value={2}>Option 2</option>
                        <option value={3}>Option 3</option>
                        <option value={4}>Option 4</option>
                    </select>
                </div>
                <button type="submit" className="btn btn-primary">Create</button>
            </form>
            </>);

}

    export default CreateOptionsForm;