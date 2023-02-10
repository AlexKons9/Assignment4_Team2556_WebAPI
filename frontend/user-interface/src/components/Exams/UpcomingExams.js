import React, { useState, useEffect } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

function UpcomingExams () {
  const [upcomingExams, setUpcomingExams] = useState([]);
  const { auth } = useAuth();
  const userName = auth.userName;
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axiosPrivate.get(`api/CandidateExams/ScheduledExams?userName=${userName}`);
        setUpcomingExams(response.data);
      } catch (error) {
        console.error(error);
      }
    };  
    fetchData();
  }, []);


  const takeExamHandler = async (examId) => {
    try {
      const response = await axiosPrivate.get(`api/CandidateExams/GetScheduledExamForm/${examId}`);
      console.log(response.data);

      const candidateExamId = response.data.candidateExamId;
      const questionsList = response.data.questions;
      
      
      navigate("/CandidateUI/GenerateExam", {
        state: {
          candidateExamId: candidateExamId,
          questionList: questionsList
        }
      });
    } catch (error) {
      console.error(error);
      alert("Error");
    }
  };



  // Gets the date in D/M/YYYY
  function getRemainingDays(examDate) {
    const currentDate = new Date();
    currentDate.setHours(0,0,0,0);
    const dateOfTheExam = new Date(examDate);
    dateOfTheExam.setHours(0,0,0,0);
    const timeDiff = Math.abs(dateOfTheExam.getTime() - currentDate.getTime());
    return Math.ceil(timeDiff / (1000 * 3600 * 24));
  }

  return(
    <div>
      <h1>Upcoming Exams</h1>
      <table className="table">
        <thead>
          <tr>
            <th>Certificate In</th>
            <th>Exam Date</th>
            <th>Days Remaining</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
        {upcomingExams.map((upcomingExam) => (
          <tr key={upcomingExam.candidateExamId}>
            <td>{upcomingExam.exam.certificate.title}</td>
            <td>{new Date(upcomingExam.examDate).toDateString()}</td>
            <td>{getRemainingDays(upcomingExam.examDate)}</td>
            <td>
              <button className="btn btn-success" onClick={() => takeExamHandler(upcomingExam.candidateExamId)} disabled={getRemainingDays(upcomingExam.examDate) > 0}>Take the Exam!</button>
            </td>
          </tr>
        ))}
        </tbody>
      </table>
    </div>
  );
}

export default UpcomingExams;