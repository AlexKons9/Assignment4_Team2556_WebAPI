import React, { useState, useEffect } from "react";
import { useNavigate, Link } from "react-router-dom";
import MyCKEditor from "../MyCKEditor";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import "../GenericCss/Buttons.css";

function CreateQuestionForm() {
  const [question, setQuestion] = useState({
    descriptionStem: "",
    topicId: "",
  });
  const [topics, setTopics] = useState([]);
  const [certificates, setCertificates] = useState([]);
  const [selectedCertificate, setSelectedCertificate] = useState({
    certificateId: "",
  });
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
    setSelectedCertificate({ [name]: value });
  };

  const myCKEditorHandleChange = (event, editor) => {
    const data = editor.getData();
    setQuestion({ ...question, descriptionStem: data });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axiosPrivate.post("/api/Questions", question);
      const questionId = response.data.questionId;
      navigate("/AdminUI/CreateOptionsForm", {
        state: { questionId: questionId },
      });
    } catch (error) {
      console.error(error);
      alert("Error creating question");
    }
  };

  return (
    <div className="container">
      <h2>Create Question</h2>

      <form onSubmit={handleSubmit}>
        <div>
          <div className="form-group mt-4">
            <label className="pb-2" htmlFor="descriptionStem">Description Stem</label>
            <MyCKEditor
              type="text"
              className="form-control"
              id="descriptionStem"
              name="descriptionStem"
              value={question.descriptionStem}
              onChange={myCKEditorHandleChange}
              required
            />
          </div>
          <div className="form-group mt-4">
            <label className="pb-2" htmlFor="certificateId">Certificate</label>
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
                <option
                  key={certificate.certificateId}
                  value={certificate.certificateId}
                >
                  {certificate.title}
                </option>
              ))}
            </select>
          </div>
        </div>
        <div className="form-group mt-4 mb-4">
          <label className="pb-2" htmlFor="topicId">Topic</label>
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
            {topics.map(
              (topic) =>
                topic.certificateId == selectedCertificate.certificateId && (
                  <option key={topic.topicId} value={topic.topicId}>
                    {topic.topicDescription}
                  </option>
                )
            )}
          </select>
        </div>

        
        <div className="d-flex">
          <button type="submit" className="btn btn-primary">Create</button>
          <Link id="backButton" className='btn btn-secondary align-self-start'  to={"../AdminUI/QuestionList"}>Back to List</Link>
        </div>
      </form>
    </div>
  );
}

export default CreateQuestionForm;
