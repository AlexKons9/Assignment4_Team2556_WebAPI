import React, { useState } from "react";
import axios from "axios";
import { useLocation, useNavigate } from "react-router-dom";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function CreateTopics() {
  const location = useLocation();
  const [certificateId, setCertificateId] = useState(location.state.certificateId);
  const [topics, setTopics] = useState([""]);
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate()
  const handleTopic = (event, index) => {
    const values = [...topics];
    values[index] = event.target.value;
    setTopics(values);
  };

  const handleAddTopic = () => {
    setTopics([...topics, ""]);
  };

  const handleRemoveTopic = (index) => {
    const values = [...topics];
    values.splice(index, 1);
    setTopics(values);
  };
  const handleSubmit = async (event) => {
    event.preventDefault();
    console.log(topics);
    console.log(certificateId);
    try {
      const response = await axiosPrivate.post(
        `/api/Topics/ListOfTopics?certificateId=${certificateId}`, topics
      );
      alert("Certificate created successfully!");
      navigate("/AdminUI/Certificates");
    } catch (error) {
      console.error(error);
      alert("Error creating certificate");
    }
  };
  return (
    <div className="container w-25">
      <form onSubmit={handleSubmit}>
        <h1>Create Certificate</h1>
        <h3 className="mb-4">Add Topics</h3>
        <input type="hidden" value={certificateId} />
        <div>
          {topics.map((topic, index) => (
            <div className="input-group-sm mb-4">
              <label key={index}>
                Topic {index + 1}:
              </label>
              <div className="row">
                <input type="text" className="form-control mb-1" value={topic} onChange={(e) => handleTopic(e, index)} />
                <p type="button" className="btn btn-outline-danger" onClick={() => handleRemoveTopic(index)}>
                  Remove Topic
                </p>
              </div>
            </div>
          ))}
          <p type="button" className="btn btn-outline-success" onClick={handleAddTopic}>
            Add Topic
          </p>
        </div>
        <button type="submit" className="btn btn-primary">
          Create Certificate
        </button>
      </form>
    </div>
  );
}

export default CreateTopics;