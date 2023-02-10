import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function EditTopics()
{ 
    const location = useLocation();
    const certificateId = location.state.certificateId;
    const [topics, setTopics] = useState(
        [
            
        ]);
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
          console.log(response.data);
          navigate("/AdminUI/Certificates");
        } catch (error) {
          console.error(error);
          alert("Error creating certificate");
        }
      };
      return (
        <form onSubmit={handleSubmit}>
            <h1>Add Topics to Certificate</h1>
          <input type="hidden" value={certificateId} />
          <div>
            {topics.map((topic, index) => (
              <div key={index}>
                <label>
                  Topic {index + 1}:
                  <input type="text" value={topic} onChange={(e) => handleTopic(e, index)} />
                </label>
                <button type="button" onClick={() => handleRemoveTopic(index)}>
                  Remove Topic
                </button>
              </div>
            ))}
            <button type="button" className="btn btn-success" onClick={handleAddTopic}>
              Add Topic
            </button>            
          </div>
        <button type="submit" className="btn btn-primary">
          Create Certificate
        </button>
        </form>
      );
}

export default EditTopics;