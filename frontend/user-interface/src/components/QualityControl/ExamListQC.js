import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";
import htmlParse from "html-react-parser";
import DeleteQuestion from "../Question/DeleteQuestion";


function ExamsListQC() {
  const [exams, setExams] = useState([]);
  const navigate = useNavigate();
  const [showModal, setShowModal] = useState(false);
  const [itemToDelete, setItemToDelete] = useState(0);
  const axiosPrivate = useAxiosPrivate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        //const response = await axios.get("https://localhost:7015/api/Questions");
        const response = await axiosPrivate.get("/api/Exams");
        setExams(response.data);
        console.log(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);

  const handleDetails = async (examId) => {
    console.log(examId);
    try {
      const response = await axiosPrivate.get(`/api/ExamQuestions/${examId}`);
      console.log(response.data);
      const examQuestionDetails = response.data;
      navigate("/Exams/Details", {
        state: { examQuestionDetails: examQuestionDetails },
      });
    } catch (error) {
      console.error(error);
      alert("Error the Question requested doesn't exist.");
    }
  };

return (
    <div>
        <h1>Exams List</h1>
      <table className="table">
        <thead>
          <tr>
            <th>Description</th>
            <th>Certificate Title</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {exams.map((exam,i) => (
            <tr key={exam.examId}>
              <td><h5>Exam {exam.examId}</h5></td>
              <td>{exam.certificate.title}</td>
              <td>
                <button className="btn btn-success" onClick={() => handleDetails(exam.examId)}>Details</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ExamsListQC;