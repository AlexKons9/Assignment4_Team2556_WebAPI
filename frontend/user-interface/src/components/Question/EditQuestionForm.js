import { useLocation, useNavigate } from "react-router-dom";
import {  useEffect, useState } from "react";
import axios from "axios";
import MyCKEditor from '../MyCKEditor';

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

    const myCKEditorHandleChange = (event,editor) => {
        const data = editor.getData();
        setQuestion({ ...question, descriptionStem: data });
      };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await axios.put(`https://localhost:7015/api/Questions/${question.questionId}`, question);
            alert("Question edited successfully!");
            var response = await axios.get(`https://localhost:7015/api/Options/${question.questionId}`);
            var options = response.data;
            console.log(options);
            navigate('/AdminUI/EditOptionsForm', {state: { options: options}});
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
                    <MyCKEditor
                        type="text"
                        className="form-control"
                        id="descriptionStem"
                        name="descriptionStem"
                        value={question.descriptionStem}
                        onChange={myCKEditorHandleChange}
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
                <button type="submit" className="btn btn-primary">Edit</button></form>
        </>
    );
}

export default EditQuestionForm;