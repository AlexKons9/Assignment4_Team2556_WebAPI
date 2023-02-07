import { useLocation, useNavigate, Link } from "react-router-dom";
import React from 'react';
import htmlParse from 'html-react-parser';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function DetailsExam() {
      var count = 1;
      const location = useLocation();
      const examQuestions = location.state.examQuestionDetails;
      const axiosPrivate = useAxiosPrivate();
      const navigate = useNavigate();
    const handleDetails = async (questionId) => {
        try {
          const response = await axiosPrivate.get(`/api/Questions/${questionId}`);
          const questionDetails = response.data;
          navigate("/AdminUI/DetailsQuestion", {
            state: { questionDetails: questionDetails },
          });
        } catch (error) {
          console.error(error);
          alert("Error the Question requested doesn't exist.");
        }
      };
    
      return (
        <div>
          <h1>Details</h1>
    
          <div>
            <h4>Exam Questions</h4>
            <hr />
            {examQuestions.map((examQuestion, index) => (
                <div key={index}>

            <dl className="row">
              <dt className="col-sm-2">Question{index + 1}:</dt>
              <dd className="col-sm-10">{htmlParse(examQuestion.question.descriptionStem)}
               </dd>
            
              <dt className="col-sm-2">Topic:</dt>
              <dd className="col-sm-10">{examQuestion.question.topic.topicDescription} </dd>
              <dt className="col-sm-2"></dt>
              <dd className="col-sm-10"><button className="btn btn-success" onClick={() => handleDetails(examQuestion.question.questionId)}>Details</button> </dd>
            </dl>
            </div>
            ))
            }
            <hr />
    
              <div>
                <Link className='btn btn-secondary' to="../AdminUI/Exams">Back to List</Link>
              </div>
    
          </div>
        </div>
      );
    }
export default DetailsExam;