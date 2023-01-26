import React, { useState, useEffect } from "react";
import axios from "axios";

function CreateQuestionForm() {
    // const [question, setQuestion] = useState({ descriptionStem: "", topicId: "" });

    // const handleSubmit = async (e) => {
    //     e.preventDefault();
    //     try {
    //         console.log(question)
    //         await axios.post("https://localhost:7015/api/Questions", question);
    //     } catch (error) {
    //         console.error(error);
    //     }
    // }

    // const handleChange = (event) => {
    //     const { name, value } = event.target;
    //     setQuestion({ ...question, [name]: value });
    //     //setQuestion({ ...question, [e.target.name]: e.target.value });
    //     //console.log(question);
    // }

    // const [topics, setTopics] = useState([]);

    // useEffect(() => {
    //     const fetchData = async () => {
    //         try {
    //             const response = await axios.get("https://localhost:7015/api/Topics");
    //             setTopics(response.data);
    //         } catch (error) {
    //             console.error(error);
    //         }
    //     };
    //     fetchData();
    // }, []);

    // console.log(topics);

    // return (
    //     <>
    //         <form onSubmit={handleSubmit}>
    //             <label>Description:</label>
    //             <input type="text" name="descriptionStem" value={question.descriptionStem} onChange={handleChange} />
    //             <label>Topics:</label>
    //             <select type="text" name="topicId" value={question.topicId} onChange={handleChange}>
    //             {topics.map(topic => (
    //                 <option key={topic.topicId} value={topic.topicId}>{topic.topicDescription}</option>
    //             ))}
    //             </select>

    //             <button type="submit">Create</button>
    //         </form>
    //         <p>Hello</p>
    //     </>
    // );
    const [question, setQuestion] = useState({ descriptionStem: "", topicId: "" });
    const [topics, setTopics] = useState([]);
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
            console.log(question)
            await axios.post("https://localhost:7015/api/Questions", question);
            alert("Question created successfully!");
        } catch (error) {
            console.error(error);
            alert("Error creating question");
        }
    };
    return (
        <>
            <form onSubmit={handleSubmit}>
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
        </>);
}

export default CreateQuestionForm;
