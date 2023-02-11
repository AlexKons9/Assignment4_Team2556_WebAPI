import React, { useState, useEffect } from "react";
import { useLocation, useNavigate, Link } from 'react-router-dom'
import { Button, Container, Table } from 'react-bootstrap';
import axios from 'axios';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function MarkerCandidateExamReview() {
    const location = useLocation();
    const[candidateExam, setCandidateExam] = useState(location.state.candidateExam[0]);  //set candidate exam which is passed from previous page using the location method
    const[candidateCertificate, setCandidateCertificate] = useState({candidateExamId: candidateExam.candidateExamId});  //set state of candidate certificate
    const navigate = useNavigate(); //navigate function to automatically redirect page
    const axiosPrivate = useAxiosPrivate(); //custom axios function with user credentials in header


    //
    //Summary: Update candidate exam as marked, with date marked.  If candidate passed exam, create a candidate certificate
    const approveExam = async () => {
        try {
            candidateExam.isMarked = true;  //set candidate exam as marked
            candidateExam.scoreReportDate = new Date();  //set the date marked as the date and time now
            await axiosPrivate.put(`/api/CandidateExams/${candidateExam.candidateExamId}`, candidateExam);  //update candidate exam in db as marked with date

            //If candidate passed exam, create certificate and save to db
            if(candidateExam.testResult == "PASS") {
                setCandidateCertificate({...candidateCertificate, candidateExamId: candidateExam.candidateExamId})
                console.log(JSON.stringify(candidateCertificate));
                const response = await axiosPrivate.post(`/api/CandidateCertificates`, candidateCertificate);
            }
            alert("Exam Approved!");
            navigate("/MarkerUI/MarkedExamsList");
        }
        catch(error) {
            console.error(error);
        }
    }

        //
    //Summary: Update candidate exam as marked, with date marked.  If candidate passed exam, create a candidate certificate
    const disqualifyExam = async () => {
        try {
            candidateExam.isMarked = true;  //set candidate exam as marked
            candidateExam.scoreReportDate = new Date();  //set the date marked as the date and time now
            candidateExam.testResult = "Failed due to disqualification."
            candidateExam.examScore = 0
            candidateExam.percentageScore = `0/${candidateExam.qa.count}`
            //candidate.Exam
            await axiosPrivate.put(`/api/CandidateExams/${candidateExam.candidateExamId}`, candidateExam);  //update candidate exam in db as marked with date

            alert("Exam Disqualified!");
            navigate("/MarkerUI/MarkedExamsList");
        }
        catch(error) {
            console.error(error);
        }
    }

    return (
        <div>
        <div className="container">
            <h1>Exam Marking Review</h1>
            
            <div>
            <h4>Preliminary Exam Result:</h4>
                <dl className="row mt-3">
                        <dt className="col-6 text-end">Candidate: </dt>
                        <dd className="col-6 text-start">{candidateExam.candidate.firstName} {candidateExam.candidate.lastName}</dd>
                        <dt className="col-6 text-end">Exam: </dt>
                        <dd className="col-6 text-start">{candidateExam.exam.certificate.title}</dd>
                        <dt className="col-6 text-end">Overall Score</dt>
                        <dd className="col-6 text-start">{candidateExam.examScore} out of {candidateExam.exam.maximumScore}</dd>
                        <dt className="col-6 text-end">Exam Result: </dt>
                        <dd className="col-6 text-start">{candidateExam.testResult}</dd>
                    </dl>
                    <hr />
                <h4>Exam Details</h4>
                {candidateExam.qa.map((questionanswer) => (
                    <dl className="row mt-4">
                        <dt className="col-6 text-end">Question: </dt>
                        <dd className="col-6 text-start">{questionanswer.option.question.descriptionStem}</dd>
                        <dt className="col-6 text-end">Option Selected: </dt>
                        <dd className="col-6 text-start">{questionanswer.option.description}</dd>
                        <dt className="col-6 text-end">Correct Answer: </dt>
                        <dd className="col-6 text-start">{questionanswer.option.isCorrect ? "Yes" : "No"}</dd>
                        <dt className="col-6 text-end">Points awarded: </dt>
                        <dd className="col-6 text-start">{questionanswer.option.isCorrect ? 1 : 0}</dd>
                    </dl>
                ))}
                <button className="btn btn-outline-success mx-1" onClick={() => approveExam()}>Approve Exam Result</button>
                <button className="btn btn-outline-danger" onClick={() => disqualifyExam()}>*Disqualify Exam</button> 
            </div>
        </div>
                <p></p>
                <p><strong>*Disqualification disclaimer:</strong> A disqualified exam will result in an automatic failure of the exam with a score of zero.</p>
                <p><strong>*The conditions </strong>for disqualification include plagarism, cheating, and/or any type of external assistance via physical or electronic communication.</p>
        </div>
    )
}

export default MarkerCandidateExamReview;