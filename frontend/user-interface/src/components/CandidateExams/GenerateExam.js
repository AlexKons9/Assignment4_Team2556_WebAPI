import React, { useState } from "react";
import axios from "axios";
import { useLocation, useNavigate } from "react-router-dom";

function GenerateExam()
{
    const location = useLocation();
    // function that navigate to another js view (used in handleSubmit function)
    const navigate = useNavigate();
    const [examForm, setExamForm] = useState({
        candidateExamId: location.state.candidateExamId,
        questions: location.state.questionList,
        chosenOptionsId:'',
    });
    const handleOptionSelection = (questionId, optionId) => {
        setExamForm({ ...examForm, [questionId]: optionId });
    };
    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            
            console.log(examForm);
            const response = await axios.post(
                "https://localhost:7015/api/CandidateExams",
                examForm
            );
            navigate('/CandidateUI');
        } catch (error) {
            console.error(error);
            alert("Error on Submit");
        }
    };

    return (
        <>
            <h2>Exam Time</h2>
            <form onSubmit={handleSubmit}>
                <input type="hidden" name="candidateExamId" value={examForm.candidateExamId} />
                {examForm.questions.map((question, i) => (
                    <div key={question.questionId}>
                        <p>{question.descriptionStem}</p>
                        {question.options.map((option, j) => (
                            <div key={option.optionsId}>
                                <input
                                    type="radio"
                                    name={`examForm.ChosenOptionsId[${i}]`}
                                    value={option.optionId}
                                    onChange={() => handleOptionSelection(question.questionId, option.optionsId)}
                                />
                                {option.description}
                            </div>
                        ))}
                    </div>
                ))}
                <input type="submit" value="Submit Exam" className="btn btn-primary" />
            </form>
        </>
    );
};
export default GenerateExam;