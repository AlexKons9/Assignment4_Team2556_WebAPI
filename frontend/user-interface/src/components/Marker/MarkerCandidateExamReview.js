import React, { useState, useEffect } from "react";
import { useLocation, useNavigate, Link } from 'react-router-dom'
import { Button, Container, Table } from 'react-bootstrap';
import axios from 'axios';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function MarkerCandidateExamReview() {
    const location = useLocation();
    const[candidateExam, setCandidateExam] = useState(location.state.candidateExam[0]);
    const[candidateCertificate, setCandidateCertificate] = useState({candidateExamId: candidateExam.candidateExamId});
    const navigate = useNavigate();
    const axiosPrivate = useAxiosPrivate();

    const approveExam = async () => {
        try {
            candidateExam.isMarked = true;
            candidateExam.scoreReportDate = new Date();
            console.log(JSON.stringify(candidateExam));
            await axiosPrivate.put(`/api/CandidateExams/${candidateExam.candidateExamId}`, candidateExam);

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

    return (
        <div>
            <h1>Exam Marking Review</h1>
            <hr />
            <div>
            <h4>Preliminary Exam Result</h4>
                <dl className="row">
                        <dt className="col-sm-2">Candidate: </dt>
                        <dd className="col-sm-10">{candidateExam.candidate.firstName} {candidateExam.candidate.lastName}</dd>
                        <dt className="col-sm-2">Exam given for Certificate: </dt>
                        <dd className="col-sm-10">{candidateExam.exam.certificate.title}</dd>
                        <dt className="col-sm-2">Overall Score</dt>
                        <dd className="col-sm-10">{candidateExam.examScore} out of {candidateExam.exam.maximumScore}</dd>
                        <dt className="col-sm-2">Exam Result: </dt>
                        <dd className="col-sm-10">{candidateExam.testResult}</dd>
                    </dl>
                <h4>Exam Details</h4>
                {candidateExam.qa.map((questionanswer) => (
                    <dl className="row">
                        <dt className="col-sm-2">Question: </dt>
                        <dd className="col-sm-10">{questionanswer.option.question.descriptionStem}</dd>
                        <dt className="col-sm-2">Option Selected: </dt>
                        <dd className="col-sm-10">{questionanswer.option.description}</dd>
                        <dt className="col-sm-2">Correct Answer: </dt>
                        <dd className="col-sm-10">{questionanswer.option.isCorrect ? "Yes" : "No"}</dd>
                        <dt className="col-sm-2">Points awarded: </dt>
                        <dd className="col-sm-10">{questionanswer.option.isCorrect ? 1 : 0}</dd>
                    </dl>
                ))}
                <Button className="btn btn-success" onClick={() => approveExam()}>Approve Exam Result</Button>
            </div>
        </div>
    )
}

export default MarkerCandidateExamReview;