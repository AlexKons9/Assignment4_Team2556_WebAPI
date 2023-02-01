import React, { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
//import axios from "axios";
import useAxiosPrivate from "../hooks/useAxiosPrivate"
import { Link } from "react-router-dom";
import CreateQuestion from "./CreateQuestionForm";
import useRefreshToken from "../hooks/useRefreshToken";

function QuestionsList() {
    const [questions, setQuestions] = useState([]);
    const axiosPrivate = useAxiosPrivate();
    const refresh = useRefreshToken();

    useEffect(() => {
        
        const fetchData = async () => {
            try {
                const response = await axiosPrivate.get("/api/Questions");
                console.log(response)
                console.log("data" + response.data)
                setQuestions(response.data);

                if(response === null) {
                    console.log("is null")
                }
            } catch (error) {
                console.error(error);
            }
        };
        fetchData();
    }, []);

    console.log(questions);

    return (
        <>
            <h1>Question List</h1>

            <p>
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
                                {question.descriptionStem}
                            </td>
                            <td>
                                <button className='btn btn-secondary'>Edit</button> | 
                                <button className='btn btn-success' >Details</button> | 
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
