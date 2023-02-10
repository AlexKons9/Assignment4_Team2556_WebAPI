import React, { useState } from "react";
import axios from "axios";
import { useLocation, useNavigate } from "react-router-dom";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function CreateTopics()
{ 
    const location = useLocation();
    const [certificateId, setCertificateId] = useState(location.state.certificateId);
    const [topics, setTopics] = useState([{ topicName: "" }]);
    const handleTopic = (event, index) => {
        const values = [...topics];
        values[index].topicName = event.target.value;
        setTopics(values);
      };
    
      const handleAddTopic = () => {
        setTopics([...topics, { topicName: "" }]);
      };
    
      const handleRemoveTopic = (index) => {
        const values = [...topics];
        values.splice(index, 1);
        setTopics(values);
      };
      console.log(topics);
      console.log(certificateId);
      return (
        <form>
            <h1>Add Topics to Certificate</h1>
          <input type="hidden" value={certificateId} />
          <div>
            {topics.map((topic, index) => (
              <div key={index}>
                <label>
                  Topic {index + 1}:
                  <input type="text" value={topic.topicName} onChange={(e) => handleTopic(e, index)} />
                </label>
                <button type="button" onClick={() => handleRemoveTopic(index)}>
                  Remove Topic
                </button>
              </div>
            ))}
            <button type="button" onClick={handleAddTopic}>
              Add Topic
            </button>
          </div>
        </form>
      );
}

export default CreateTopics;