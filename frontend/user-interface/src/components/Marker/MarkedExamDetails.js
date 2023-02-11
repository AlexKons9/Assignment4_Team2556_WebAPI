import React, { useState } from "react";
import { useLocation, Link } from 'react-router-dom'
import { Button, Container, Table } from 'react-bootstrap';

function MarkedExamDetails() {
    //transfer state of candidate exam from previous page
    const location = useLocation();
    const[candidateExam] = useState(location.state.candidateExam[0]);
    console.log(candidateExam.testResult)

    return (
        <div className="container">
            <h1>Exam Details</h1>
            <hr />
            <div>
            <h4>Final Exam Result</h4>
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
                        <dd className="col-6 text-start">{candidateExam.testResult == "Failed due to disqualification." ? "0 due to disqualification." : questionanswer.option.isCorrect ? 1 : 0}</dd>
                    </dl>
                ))}
            </div>
        </div>
    )
}

export default MarkedExamDetails;