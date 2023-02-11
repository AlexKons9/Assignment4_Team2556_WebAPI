import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function EditTopics() {

  const location = useLocation();

  const [certificateId, setCertificateId] = useState(location.state.certificateId);
  const [topics, setTopics] = useState(location.state.topics ? location.state.topics : [{ topicDescription: "", certificateId: certificateId, certificate: null }]);
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();


  const handleTopic = (event, index) => {
    const values = [...topics];
    values[index].topicDescription = event.target.value;
    setTopics(values);
  };


  const handleAddTopic = () => {
    setTopics([...topics, { topicDescription: "", certificateId: certificateId, certificate: null }]);
  };


  const handleDeleteTopic = async (index) => {
    const topicToDelete = topics[index];
    try {
      await axiosPrivate.delete(`/api/Topics/${topicToDelete.topicId}`);
      const values = [...topics];
      values.splice(index, 1);
      setTopics(values);
    } catch (error) {
      console.error(error);
      alert("Error deleting topic");
    }
  };



  const handleRemoveTopic = (index) => {
    const values = [...topics];
    values.splice(index, 1);
    setTopics(values);
    handleDeleteTopic(index);
  };




  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axiosPrivate.put(
        `api/Topics/UpdateTopics`,
        topics
      );
      alert("Certificate updated successfully!");
      navigate("/AdminUI/Certificates");
    } catch (error) {
      console.error(error);
      alert("Error updating certificate");
    }
  };
  return (
    <div className="container w-25">
      <form onSubmit={handleSubmit}>
        {" "}
        <h1>Edit Certificate Topics</h1>{" "}
        <input type="hidden" value={certificateId} />{" "}
        <div>
          {" "}
          {topics.map((topic, index) => (
            <div className="input-group-sm mb-4" key={index}>
              <label>
                Topic {index + 1}:
              </label>
              <div className="row">
                <input
                  type="text"
                  className="form-control mb-1"
                  value={topic.topicDescription}
                  onChange={(e) => handleTopic(e, index)}
                />
                <p className="btn btn-outline-danger" type="button" onClick={() => handleRemoveTopic(index)}>
                  Remove Topic
                </p>
              </div>
            </div>
          ))}
          <button
            type="button"
            className="btn btn-outline-success"
            onClick={handleAddTopic}
          >
            {" "}
            Add Topic
          </button>{" "}
        </div>{" "}
        <button type="submit" className="btn btn-primary">
          {" "}
          Update Certificate
        </button>{" "}
      </form>
    </div>
  );
}
export default EditTopics;
