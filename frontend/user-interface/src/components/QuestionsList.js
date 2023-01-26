import React, { useState, useEffect } from "react";
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

   //console.log(questions);

  return (
    <div>
      {questions.map(question => (
        <ul key={question.questionId}>
          <li>{question.descriptionStem}</li>
        </ul>
      ))}
    </div>
  );
}

export default QuestionsList;
