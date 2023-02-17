import { useLocation, useNavigate, Link } from "react-router-dom";
import React from "react";
import htmlParse from "html-react-parser";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";

function DetailsExam() {
  var count = 1;
  const location = useLocation();
  const examQuestions = location.state.examQuestionDetails;
  const exam = location.state.exam;
  const axiosPrivate = useAxiosPrivate();
  const navigate = useNavigate();
  const { auth } = useAuth();

  const handleDetails = async (questionId) => {
    try {
      const response = await axiosPrivate.get(`/api/Questions/${questionId}`);
      const questionDetails = response.data;
      navigate("/DetailsQuestion", {
        state: { questionDetails: questionDetails },
      });
    } catch (error) {
      console.error(error);
      alert("Error the Question requested doesn't exist.");
    }
  };

  return (
    <div className="container">
      <h1>Details</h1>

      <div>
        <h5 className="mt-5">Exam</h5>
        <table className="table table-bordered ">
          <tbody>
          <tr>
            <th className="col-6">Description</th>
            <td className="col-6">Exam {exam.examId}</td>
          </tr>
          <tr>
            <th>Certificate Title</th>
            <td>{exam.certificate.title}</td>
          </tr>
          <tr>
            <th className="col-6">Certificate Status</th>
            { exam.certificate.isActive === true ? <td>Active</td> : <td>NOT Active</td> }
          </tr>
          </tbody>
        </table>

        <h5 className="mt-5">Questions</h5>
        <table className="table table-bordered">
          <tbody>
          {examQuestions.map((examQuestion, index) => (

              <tr key={index} className="row">
                <th className="col-6">Question {index + 1} </th>
                <td className="col-6">
                  {htmlParse(examQuestion.question.descriptionStem)}
                </td>

                <th className="col-6">Topic</th>
                <td className="col-6">
                  {examQuestion.question.topic.topicDescription}{" "}
                </td>
                {/* <th className="col-6"></th>
                <td className="col-6">
                  <button
                    className="btn btn-success"
                    onClick={() =>
                      handleDetails(examQuestion.question.questionId)
                    }
                  >
                    Details
                  </button>{" "}
                </td> */}
              </tr>

          ))}
          </tbody>
        </table>

        <div>
          <Link
            className="btn btn-secondary"
            to={
              auth?.roles == "Admin"
                ? "../AdminUI/Exams"
                : "/QualityControlUI/ExamList"
            }
          >
            Back to List
          </Link>
        </div>
      </div>
    </div>
  );
}
export default DetailsExam;
