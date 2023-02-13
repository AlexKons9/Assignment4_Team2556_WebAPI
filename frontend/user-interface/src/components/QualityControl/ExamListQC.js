import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";
import DeleteQuestion from "../Question/DeleteQuestion";
import "../Question/QuestionsList.css";


function ExamsList() {
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
      const examQuestionDetails = response.data;
      const response2 = await axiosPrivate.get(`/api/Exams/${examId}`);
      const exam = response2.data;
      navigate("/Exams/Details", {
        state: { exam: exam, examQuestionDetails: examQuestionDetails },
      });
    } catch (error) {
      console.error(error);
      alert("Error the Question requested doesn't exist.");
    }
  };

return (
    <div className="container-xl text-center">
        <h1>Exams List</h1>
      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">Description</th>
            <th scope="col">Certificate Title</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          {exams.map((exam,i) => (
            <tr key={exam.examId}>
              <td scope="row"><h6>Exam {exam.examId}</h6></td>
              <td scope="row"><h6>{exam.certificate.title}</h6></td>
              <td id="table-button">
                <button
                  className="btn btn-outline-success"
                onClick={() => handleDetails(exam.examId)}
                >
                  Details
                </button>{" "}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ExamsList;