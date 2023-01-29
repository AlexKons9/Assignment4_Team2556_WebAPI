import React, { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";
import CreateQuestion from "./CreateQuestionForm";

function QuestionsList() {
    const [questions, setQuestions] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get("https://localhost:7015/api/Questions");
                setQuestions(response.data);
            } catch (error) {
                console.error(error);
            }
        };
        fetchData();
    }, []);

    const handleDetails = async (questionId) =>  {
        try {
            const response = await axios.get(`https://localhost:7015/api/Questions/${questionId}`);
            const questionDetails = response.data;
            navigate('/AdminUI/DetailsQuestion', {state: { questionDetails: questionDetails}});
        } catch (error) {
            console.error(error);
            alert("Error the Question requested doesn't exist.");
        }
    }


    return (
        <>
            <h1>Question List</h1>

            <p>
                {/* <button className='btn btn-primary'>Create New</button> */}
                <Link className='btn btn-primary' to="CreateQuestionForm">Create New</Link>
            </p>
            <table className="table">
                <thead>
                    <tr>
                        <th>
                            Description
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {questions.map(question => (
                        <tr key={question.questionId}>
                            <td>
                                {(question).descriptionStem}
                            </td>
                            <td>
                                <button className='btn btn-secondary' >Edit</button> | 
                                <button className='btn btn-success' onClick={() => handleDetails(question.questionId)}>Details</button> | 
                                <button className='btn btn-danger' >Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
}

export default QuestionsList;
