import React, { useState } from "react";
import axios from "axios";

function CreateQuestion() {
    const [question, setQuestion] = useState({});

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post("https://localhost:7015/api/Questions", question);
        } catch (error) {
            console.error(error);
        }
    }

    const handleChange = (e) => {
        setQuestion({ ...question, [e.target.name]: e.target.value });
    }

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Description:
                <input type="text" name="descriptionStem" onChange={handleChange} />
            </label>
            <button type="submit">Create</button>
        </form>
    );
}

export default CreateQuestion;
