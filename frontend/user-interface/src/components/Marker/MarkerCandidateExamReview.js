import React, { useState, useEffect } from "react";
import { useLocation, useNavigate, Link } from 'react-router-dom'
import { Button, Container, Table } from 'react-bootstrap';
import axios from 'axios';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function MarkerCandidateExamReview() {
    const location = useLocation();
    const [candidateExam, setCandidateExam] = useState(location.state.candidateExam[0]);  //set candidate exam which is passed from previous page using the location method
    const [candidateCertificate, setCandidateCertificate] = useState({ candidateExamId: candidateExam.candidateExamId });  //set state of candidate certificate
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
            if (candidateExam.testResult == "PASS") {
                setCandidateCertificate({ ...candidateCertificate, candidateExamId: candidateExam.candidateExamId })
                console.log(JSON.stringify(candidateCertificate));
                const response = await axiosPrivate.post(`/api/CandidateCertificates`, candidateCertificate);
            }
            alert("Exam Approved!");
            navigate("/MarkerUI/MarkedExamsList");
        }
        catch (error) {
            console.error(error);
        }
    }

    //
    //Summary: Update candidate exam as marked, with date marked.  If candidate passed exam, create a candidate certificate
    const disqualifyExam = async () => {
        try {
            candidateExam.isMarked = true;  //set candidate exam as marked
            candidateExam.scoreReportDate = new Date();  //set the date marked as the date and time now
            candidateExam.testResult = "Failed due to disqualification"
            candidateExam.examScore = 0
            candidateExam.percentageScore = `0/${candidateExam.qa.count}`
            //candidate.Exam
            await axiosPrivate.put(`/api/CandidateExams/${candidateExam.candidateExamId}`, candidateExam);  //update candidate exam in db as marked with date

            alert("Exam Disqualified!");
            navigate("/MarkerUI/MarkedExamsList");
        }
        catch (error) {
            console.error(error);
        }
    }

    return (
        <div>
            <div className="container">
                <h1>Exam Marking Review</h1>

                <div>
                    <h4 className="mb-3">Preliminary Exam Result:</h4>
                    <table className="table table-bordered table-centered">
                        <tbody>
                            <tr>
                                <th className="col-6">Candidate Name</th>
                                <td className="col-6">{candidateExam.candidate.firstName} {candidateExam.candidate.lastName}</td>
                            </tr>
                            <tr>
                                <th className="col-6">Exam given for Certificate</th>
                                <td className="col-6">{candidateExam.exam.certificate.title}</td>
                            </tr>
                            <tr>
                                <th className="col-6">Overall Score</th>
                                <td className="col-6">{candidateExam.examScore} out of {candidateExam.exam.maximumScore}</td>
                            </tr>
                            <tr>
                                <th className="col-6">Exam Result</th>
                                <td className="col-6">{candidateExam.testResult}</td>
                            </tr>

                        </tbody>
                    </table>
                    <h4 className="mt-5 mb-3">Exam Details</h4>

                    {candidateExam.qa.map((questionanswer, count) => (
                        <table className="table table-bordered table-centered mb-5">
                            <tbody>
                                <tr>
                                    <th className="col-6">Question {++count}</th>
                                    <td lassName="col-6">{questionanswer.option.question.descriptionStem}</td>
                                </tr>
                                <tr>
                                    <td className="col-6">Option Selected</td>
                                    <td className="col-6">{questionanswer.option.description}</td>
                                </tr>
                                <tr>
                                    <td className="col-6">Correct Answer</td>
                                    <td className="col-6">{questionanswer.option.isCorrect ? "Yes" : "No"}</td>
                                </tr>
                                <tr>
                                    <td className="col-6">Points awarded</td>
                                    <td className="col-6">{questionanswer.option.isCorrect ? 1 : 0}</td>
                                </tr>
                            </tbody>
                        </table>
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