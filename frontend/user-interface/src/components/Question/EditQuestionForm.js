import { useLocation, useNavigate } from "react-router-dom";
import {  useEffect, useState } from "react";
import axios from "axios";

function EditQuestionForm() {
    const location = useLocation();
    const navigate = useNavigate();
    const [topics, setTopics] = useState([]);
    const [question, setQuestion] = useState({questionId: location.state.question.questionId, descriptionStem: location.state.question.descriptionStem, topicId: location.state.question.topicId});

    useEffect(() => {
        const fetchTopics = async () => {
            try {
                const response = await axios.get("https://localhost:7015/api/Topics");
                setTopics(response.data);
            } catch (error) {
                console.error(error);
            }
        };
        fetchTopics();
    }, []);

    const handleChange = (event) => {
        const { name, value } = event.target;
        setQuestion({ ...question, [name]: value });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            console.log(question);
            const response = await axios.put(`https://localhost:7015/api/Questions/${question.questionId}`, question);
            alert("Question created successfully!");
            navigate('/AdminUI/EditOptionsForm', {state: { questionId: question.questionId}});
        } 
        catch (error) {
            console.error(error);
            alert("Error editing question");
        }
    };

    return (
        <>
            <form onSubmit={handleSubmit}>
                <input type="hidden" name="questionId" value={question.questionId} />
                <div className="form-group">
                    <label htmlFor="descriptionStem">Description Stem</label>
                    <input
                        type="text"
                        className="form-control"
                        id="descriptionStem"
                        name="descriptionStem"
                        value={question.descriptionStem}
                        onChange={handleChange}
                        required />
                </div>
                <div className="form-group">
                    <label htmlFor="topicId">Topic</label>
                    <select
                        className="form-control"
                        id="topicId"
                        name="topicId"
                        value={question.topicId}
                        onChange={handleChange}
                        required>
                        <option value="" disabled>Select a topic</option>
                        {topics.map((topic) => (<option key={topic.topicId} value={topic.topicId}>{topic.topicDescription}</option>))}
                    </select>
                </div>
                <button type="submit" className="btn btn-primary">Create</button></form>
        </>
    );
}

export default EditQuestionForm;