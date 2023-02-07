import React, { useState } from "react";
import { useLocation, Link } from 'react-router-dom'
import { Button, Container, Table } from 'react-bootstrap';

function MarkedExamDetails() {
    //transfer state of candidate exam from previous page
    const location = useLocation();
    const[candidateExam] = useState(location.state.candidateExam[0]);

    return (
        <div>
            <h1>Exam Details</h1>
            <hr />
            <div>
            <h4>Final Exam Result</h4>
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
            </div>
        </div>
    )
}

export default MarkedExamDetails;