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

  const showConfirmPopupHandler = (id) => {
    setShowModal(true);
    setItemToDelete(id);
    console.log(id);
    };
  const closeConfirmPopupHandler = () => {
    setShowModal(false);
    setItemToDelete(0);
  };

  const deleteConfirmHandler = async () => {
    await axiosPrivate
      .delete(`/api/Exams/${itemToDelete}`)
      .then((response) => {
        setExams((existingData) => {
          return existingData.filter((_) => _.examId !== itemToDelete);
        });
        setItemToDelete(0);
        setShowModal(false);
      });
  };

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

  const handleEdit = async (examId) => {
    try {
      const response = await axiosPrivate.get(`/api/Exams/${examId}`);
      const exam = response.data;
      const response2 = await axiosPrivate.get(`/api/ExamQuestions/${examId}`);
      
      const examQuestions = response2.data.map(question => question.questionId);
      console.log(examQuestions);
      navigate("/AdminUI/Exams/Edit"
       , { state: { exam: exam , examQuestions:examQuestions } }
      );

    } catch (error) {
      console.error(error);
      alert("Error the Exam requested doesn't exist.");
    }
  };

return (
    <div className="container-xl text-center">
      <DeleteQuestion
        showModal={showModal}
        title="Delete Confirmation!"
        body="Are you sure to delete this Exam?"
        closeConfirmPopupHandler={closeConfirmPopupHandler}
        deleteConfirmHandler={deleteConfirmHandler}
        ></DeleteQuestion>
        <h1>Exams List</h1>
      <p>
        <Link className="btn btn-outline-primary" to="Create">
          Create New
        </Link>
      </p>
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
                  className="btn btn-outline-secondary"
                onClick={() => handleEdit(exam.examId)}
                >
                  Edit
                </button>{" "}
                
                <button
                  className="btn btn-outline-success"
                onClick={() => handleDetails(exam.examId)}
                >
                  Details
                </button>{" "}
                
                <button
                  className="btn btn-outline-danger"
                  onClick={() => {
                    showConfirmPopupHandler(exam.examId);
                  }}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ExamsList;