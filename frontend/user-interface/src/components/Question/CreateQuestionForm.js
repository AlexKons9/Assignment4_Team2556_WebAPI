﻿import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import MyCKEditor from '../MyCKEditor';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function CreateQuestionForm() {
  const [question, setQuestion] = useState({
    descriptionStem: "",
    topicId: "",
  });
  const [topics, setTopics] = useState([]);
  const [certificates, setCertificates] = useState([]);
  const [selectedCertificate, setSelectedCertificate] = useState({certificateId:""});
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();

  useEffect(() => {
    const fetchTopics = async () => {
      try {
        const response = await axiosPrivate.get("/api/Topics");
        setTopics(response.data);     
        const response2 = await axiosPrivate.get("/api/Certificates");
        setCertificates(response2.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchTopics();
  }, []);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setQuestion({ ...question, [name]: value });

  };  
  const handleCertificateChange = (event) => {
    const { name, value } = event.target;
    setSelectedCertificate({[name]: value });

  };

  // const myCKEditorHandleChange = (event,editor) => {
  //   const data = editor.getData();
  //   setQuestion({ ...question, descriptionStem: data });
  // };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axiosPrivate.post(
        "/api/Questions",
        question
      );
      alert("Question created successfully!");
      console.log(response.data);
      const questionId = response.data.questionId;
      // console.log(questionId);
      navigate("/AdminUI/CreateOptionsForm", {
        state: { questionId: questionId },
      });
    } catch (error) {
      console.error(error);
      alert("Error creating question");
    }
  };
  console.log(question.descriptionStem);
  return (
    <>
      <form onSubmit={handleSubmit}>

        <div className="form-group">
          <label htmlFor="descriptionStem">Description Stem</label>
          <MyCKEditor
            //type="text"
            className="form-control"
            id="descriptionStem"
            name="descriptionStem"
            //value={question.descriptionStem}
           // onChange={myCKEditorHandleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="certificateId">Certificate</label>
          <select
            className="form-control"
            id="certificateId"
            name="certificateId"
            value={selectedCertificate.certificateId}
            onChange={handleCertificateChange}
            required
          >
            <option value="" disabled>
              Select a certificate
            </option>
            {certificates.map((certificate) => (
              <option key={certificate.certificateId} value={certificate.certificateId}>
                {certificate.title}
              </option>
            ))}
          </select>
        </div>        
        <div className="form-group">
          <label htmlFor="topicId">Topic</label>
          <select
            className="form-control"
            id="topicId"
            name="topicId"
            value={question.topicId}
            onChange={handleChange}
            required
            >
            <option value="" disabled>
              Select a topic
            </option>
            {topics.map((topic) => (
            (topic.certificateId==selectedCertificate.certificateId  &&
                <option key={topic.topicId} value={topic.topicId}>
                {topic.topicDescription}
                </option>
            )
          ))}
          </select>
        </div>
        
        <button type="submit" className="btn btn-primary">
          Create
        </button>
      </form>
    </>
  );
}

export default CreateQuestionForm;
