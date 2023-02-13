import React, { useState } from "react";
import { useLocation, Link } from 'react-router-dom'
import { Button, Container, Table } from 'react-bootstrap';

function MarkedExamDetails() {
    //transfer state of candidate exam from previous page
    const location = useLocation();
    const [candidateExam] = useState(location.state.candidateExam[0]);
    console.log(candidateExam.testResult)

    return (
        // <div className="container">
        //     <h1>Exam Details</h1>
        //     <hr />
        //     <div>
        //     <h4>Final Exam Result</h4>
        //         <dl className="row mt-3">
        //                 <dt className="col-6 text-end">Candidate: </dt>
        //                 <dd className="col-6 text-start">{candidateExam.candidate.firstName} {candidateExam.candidate.lastName}</dd>
        //                 <dt className="col-6 text-end">Exam: </dt>
        //                 <dd className="col-6 text-start">{candidateExam.exam.certificate.title}</dd>
        //                 <dt className="col-6 text-end">Overall Score</dt>
        //                 <dd className="col-6 text-start">{candidateExam.examScore} out of {candidateExam.exam.maximumScore}</dd>
        //                 <dt className="col-6 text-end">Exam Result: </dt>
        //                 <dd className="col-6 text-start">{candidateExam.testResult}</dd>
        //             </dl>
        //         <h4>Exam Details</h4>
        //         {candidateExam.qa.map((questionanswer) => (
        //             <dl className="row mt-4">
        //                 <dt className="col-6 text-end">Question: </dt>
        //                 <dd className="col-6 text-start">{questionanswer.option.question.descriptionStem}</dd>
        //                 <dt className="col-6 text-end">Option Selected: </dt>
        //                 <dd className="col-6 text-start">{questionanswer.option.description}</dd>
        //                 <dt className="col-6 text-end">Correct Answer: </dt>
        //                 <dd className="col-6 text-start">{questionanswer.option.isCorrect ? "Yes" : "No"}</dd>
        //                 <dt className="col-6 text-end">Points awarded: </dt>
        //                 <dd className="col-6 text-start">{candidateExam.testResult == "Failed due to disqualification." ? "0 due to disqualification." : questionanswer.option.isCorrect ? 1 : 0}</dd>
        //             </dl>
        //         ))}
        //     </div>
        // </div>

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
                                    <td className="col-6">{candidateExam.testResult == "Failed due to disqualification" ? "0 due to disqualification" : questionanswer.option.isCorrect ? 1 : 0}</td>
                                </tr>
                            </tbody>
                        </table>
                    ))}
            <div className=""><Link id="backButton" className='btn btn-secondary align-self-start' to={"../MarkerUI/MarkedExamsList"}>Back to List</Link>
            </div>
                </div>
            </div>
        </div>
    )
}

export default MarkedExamDetails;