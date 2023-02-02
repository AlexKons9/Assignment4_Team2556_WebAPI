import React, { useState } from "react";
import axios from "axios";
import { useLocation, useNavigate } from "react-router-dom";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function GenerateExam()
{
    const location = useLocation();
    // function that navigate to another js view (used in handleSubmit function)
    const navigate = useNavigate();
    const [examForm, setExamForm] = useState({
        candidateExamId: location.state.candidateExamId,
        questions: location.state.questionList,
        chosenOptionsId:[]
    });
    const axiosPrivate = useAxiosPrivate();
    
    const handleOptionSelection  = (i, optionId) => {
        //const { name, value } = event.target;
        const updatedChosenOptionsId = [...examForm.chosenOptionsId];
        updatedChosenOptionsId[i] = optionId;
        setExamForm({ ...examForm, chosenOptionsId: updatedChosenOptionsId  });
    };


    const handleSubmit = async (event) => {
        event.preventDefault();
        try {      
            //await axios.post("https://localhost:7015/api/CandidateExams",examForm);
            await axiosPrivate.post("/api/CandidateExams",examForm);
            //const response = await axios.get(`https://localhost:7015/api/CandidateExams/ExamResults/${examForm.candidateExamId}`)
            const response = await axiosPrivate.get(`/api/CandidateExams/ExamResults/${examForm.candidateExamId}`)
            const examResults = response.data;
            navigate('/CandidateUI/CandidateExamResults', { state: { results: examResults } });

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
                            <div key={option.optionId}>
                                <input
                                    type="radio"
                                    name={`chosenOptionsId[${i}]`}
                                    value={option.optionId}
                                    onChange={() => handleOptionSelection(i, option.optionId)} //handleOptionSelection
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