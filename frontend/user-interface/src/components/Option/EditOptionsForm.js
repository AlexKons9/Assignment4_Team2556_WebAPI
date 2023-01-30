import React, { useState } from "react";
import axios from "axios";
import { useLocation, useNavigate } from "react-router-dom";

function EditOptionsForm() {
  const location = useLocation();
  const navigate = useNavigate();

  var count = 0;
  var correctAnswerIndex = 0;
  
  const oldQuestion = location.state.options;
  oldQuestion.map(option => {
      count++;
      if(option.isCorrect == true)
      {
          correctAnswerIndex = count;
      }
  });

  const [optionDTO, setOptionDTO] = useState({
    questionId: location.state.options[0].questionId,
    description1: location.state.options[0].description,
    description2: location.state.options[1].description,
    description3: location.state.options[2].description,
    description4: location.state.options[3].description,
    correctAnswer: correctAnswerIndex
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setOptionDTO({ ...optionDTO, [name]: value });
};

const handleSubmit = async (event) => {
    event.preventDefault();
    try {
        const response = await axios.put(`https://localhost:7015/api/Options`, optionDTO);
        alert("Options edited successfully!");
        navigate('/AdminUI');
    } 
    catch (error) {
        console.error(error);
        alert("Error editing question");
    }
};

  return (
    <>
      <form onSubmit={handleSubmit}>
        <input type="hidden" name="questionId" value={optionDTO.questionId} />
        <div className="form-group">
          <label>Option 1</label>
          <input
            className="form-control"
            type="text"
            name="description1"
            value={optionDTO.description1}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Option 2</label>
          <input
            className="form-control"
            type="text"
            name="description2"
            value={optionDTO.description2}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Option 3</label>
          <input
            className="form-control"
            type="text"
            name="description3"
            value={optionDTO.description3}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Option 4</label>
          <input
            className="form-control"
            type="text"
            name="description4"
            value={optionDTO.description4}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Correct Answer</label>
          <select
            className="form-control"
            name="correctAnswer"
            value={optionDTO.correctAnswer}
            onChange={handleChange}
          >
            <option value="" disabled>
              Select Correct Answer
            </option>
            <option value={1}>Option 1</option>
            <option value={2}>Option 2</option>
            <option value={3}>Option 3</option>
            <option value={4}>Option 4</option>
          </select>
        </div>
        <button type="submit" className="btn btn-primary">
          Edit
        </button>
      </form>
    </>
  );
}

export default EditOptionsForm;
