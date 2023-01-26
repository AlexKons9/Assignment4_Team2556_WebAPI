import React, { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from "axios";

function QuestionsList() {
    const [questions, setQuestions] = useState([]);

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



    return (
        <>
            <h1>Index</h1>

            <p>
                <button className='btn btn-primary'>Create New</button>
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
