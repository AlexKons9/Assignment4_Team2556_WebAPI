import React, { useState } from "react";

import { useLocation, useNavigate } from "react-router-dom";
import MyCKEditor from "../MyCKEditor";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function CreateOptionsForm() {
  const axiosPrivate = useAxiosPrivate();

  // function that takes questionId from CreateQuestionsForm and stores it
  // to the optionsDTO.questionId
  const location = useLocation();

  // function that navigate to another js view (used in handleSubmit function)
  const navigate = useNavigate();
  const [optionDTO, setOptionDTO] = useState({
    questionId: location.state.questionId,
    description1: "",
    description2: "",
    description3: "",
    description4: "",
    correctAnswer: "",
  });

  const handleChange = (event, editor) => {
    const { name, value } = event.target;
    setOptionDTO({ ...optionDTO, [name]: value });
  };

  const editorHandleChangeDesc1 = (event, editor) => {
    const data = editor.getData();
    setOptionDTO({ ...optionDTO, description1: data });
  };

  const editorHandleChangeDesc2 = (event, editor) => {
    const data = editor.getData();
    setOptionDTO({ ...optionDTO, description2: data });
  };

  const editorHandleChangeDesc3 = (event, editor) => {
    const data = editor.getData();
    setOptionDTO({ ...optionDTO, description3: data });
  };

  const editorHandleChangeDesc4 = (event, editor) => {
    const data = editor.getData();
    setOptionDTO({ ...optionDTO, description4: data });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      await axiosPrivate.post("/api/Options", optionDTO);
      alert("Options created successfully!");
      navigate("/AdminUI/QuestionList");
    } catch (error) {
      console.error(error);
      alert("Error creating options");
    }
  };
  return (
    <div className="container">
      <h2>Create Options</h2>
      <form onSubmit={handleSubmit}>
        <input type="hidden" name="questionId" value={optionDTO.questionId} />
        <div className="form-group mt-4">
          <label className="pb-2">Option 1</label>
          <MyCKEditor
            className="form-control"
            type="text"
            name="description1"
            value={optionDTO.description1}
            onChange={editorHandleChangeDesc1}
          />
        </div>
        <div className="form-group mt-4">
          <label className="pb-2">Option 2</label>
          <MyCKEditor
            className="form-control"
            type="text"
            name="description2"
            value={optionDTO.description2}
            onChange={editorHandleChangeDesc2}
          />
        </div>
        <div className="form-group mt-4">
          <label className="pb-2">Option 3</label>
          <MyCKEditor
            className="form-control"
            type="text"
            name="description3"
            value={optionDTO.description3}
            onChange={editorHandleChangeDesc3}
          />
        </div>
        <div className="form-group mt-4">
          <label className="pb-2">Option 4</label>
          <MyCKEditor
            className="form-control"
            type="text"
            name="description4"
            value={optionDTO.description4}
            onChange={editorHandleChangeDesc4}
          />
        </div>
        <div className="form-group mt-4 mb-3">
          <label className="pb-2">Correct Answer</label>
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
        <div className="d-flex">
          <button type="submit" className="btn btn-primary align-self-start">
            Create
          </button>
        </div>
      </form>
    </div>
  );
}

export default CreateOptionsForm;
