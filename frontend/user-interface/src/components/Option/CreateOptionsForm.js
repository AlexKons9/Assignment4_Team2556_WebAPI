import React, { useState } from "react";
import axios from "axios";
import { useLocation, useNavigate } from "react-router-dom";
import MyCKEditor from '../MyCKEditor';

function CreateOptionsForm()
{ 
    // function that takes questionId from CreateQuestionsForm and stores it
    // to the optionsDTO.questionId
    const location = useLocation();
    // function that navigate to another js view (used in handleSubmit function)
    const navigate = useNavigate(); 
    const [optionDTO, setOptionDTO] = useState
        ({ questionId: location.state.questionId , description1: "", description2: "", description3: "", description4: "", correctAnswer: "" });

    const handleChange = (event,editor) => {
        const { name, value } = event.target;
        setOptionDTO({ ...optionDTO, [name]: value });
    };

    const editorHandleChangeDesc1 = (event,editor) => {
        const data = editor.getData();
        setOptionDTO({ ...optionDTO, description1: data });
    };

    const editorHandleChangeDesc2 = (event,editor) => {
        const data = editor.getData();
        setOptionDTO({ ...optionDTO, description2: data });
    };


    const editorHandleChangeDesc3 = (event,editor) => {
        const data = editor.getData();
        setOptionDTO({ ...optionDTO, description3: data });
    };

    const editorHandleChangeDesc4 = (event,editor) => {
        const data = editor.getData();
        setOptionDTO({ ...optionDTO, description4: data });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await axios.post("https://localhost:7015/api/Options", optionDTO);
            alert("Options created successfully!");
            navigate('/AdminUI');
        } catch (error) {
            console.error(error);
            alert("Error creating options");
        }
    };
        return (
            <>
            <form onSubmit={handleSubmit}>
                <input type="hidden" name="questionId" value={optionDTO.questionId} />
                <div className="form-group">
                    <label>Option 1</label>
                    <MyCKEditor className="form-control" type="text" name="description1" value={optionDTO.description1} onChange={editorHandleChangeDesc1} />
                </div>
                <div className="form-group">
                    <label>Option 2</label>
                    <MyCKEditor className="form-control" type="text" name="description2" value={optionDTO.description2} onChange={editorHandleChangeDesc2} />
                </div>
                <div className="form-group">
                    <label>Option 3</label>
                    <MyCKEditor className="form-control" type="text" name="description3" value={optionDTO.description3} onChange={editorHandleChangeDesc3} />
                </div>
                <div className="form-group">
                    <label>Option 4</label>
                    <MyCKEditor className="form-control" type="text" name="description4" value={optionDTO.description4} onChange={editorHandleChangeDesc4} />
                </div>
                <div className="form-group">
                    <label>Correct Answer</label>
                    <select className="form-control" name="correctAnswer" value={optionDTO.correctAnswer} onChange={handleChange}>
                        <option value="" disabled>Select Correct Answer</option>
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