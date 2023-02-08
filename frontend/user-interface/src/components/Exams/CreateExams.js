import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import htmlParse from 'html-react-parser';

function CreateExams() {
    const [count, setCount] = useState(0)
    const [exam, setExam] = useState({
        certificateId: "",
        passMark: "",
        maximumScore:"",
      });    
    const [examQuestions, setExamQuestions] = useState([]);
    const [questions, setQuestions] = useState([]);
    const [certificates, setCertificates] = useState([]);
    const navigate = useNavigate();
    const axiosPrivate = useAxiosPrivate();
    
      useEffect(() => {
        const fetchData = async () => {
          try {
            const response = await axiosPrivate.get("/api/Certificates");
            setCertificates(response.data);
            const response2 = await axiosPrivate.get("/api/Questions");
            setQuestions(response2.data);
            console.log(response.data);
            console.log(questions);
        } catch (error) {
            console.error(error);
        }
    };
    fetchData();
}, []);
const handleChange = (event) => {
    const { name, value } = event.target;
    setExam({ ...exam, [name]: value }); 
      };  
const handleBoxChange =(event) => {
  const {value,checked} = event.target
  if (checked) {
    setExamQuestions(pre => [...pre,value]);
    setCount(count+1)
  } else {
    setExamQuestions(pre =>{
      return[...pre.filter(skill=>skill!==value)]
    });    
    setCount(count-1)
  }
};

const handleSubmit = async (event) => {
  event.preventDefault();
  try {
    const response = await axiosPrivate.post("/api/Exams",exam);
     console.log(response.data);
    const examId = response.data.examId;
    alert("Exam created successfully!");
    await axiosPrivate.post("/api/ExamQuestions",{examId:examId,examQuestions:examQuestions});
    // console.log(questionId);
    // navigate("/AdminUI/CreateOptionsForm");
  } catch (error) {
    console.error(error);
    alert("Error creating Exam");
  }
};
console.log(examQuestions);
 return(
     <>
    <h1>Create New Exam</h1>
 <form onSubmit={handleSubmit} className="row g-3 form-container">


   <div className="form-group">
        
     <label htmlFor="certificateId">Certificates</label>
     <select
       className="form-control"
       id="certificateId"
       name="certificateId"
       value={exam.certificateId}
       onChange={handleChange}
       required
       >
      <option value="" disabled>
         Select a Certificate
       </option>
       {certificates.map((certificate) => (
         <option key={certificate.certificateId} value={certificate.certificateId}>
           {certificate.title}
         </option>
           ))}
         
    </select>
   </div>
  <div className="form-group">
  <h3>Add Exam Questions:</h3>
   {questions.map((question, index) => (
    <div key={index}>
     {question.topic.certificateId==exam.certificateId && 
                  
    <div className="form-group">
      <input type="checkbox" id="questionId" name="questionId" value={question.questionId} onChange={handleBoxChange}/>
    <label for="questionId"> <hr/> &nbsp;{question.topic.topicDescription} :{htmlParse(question.descriptionStem)} </label>
    </div>               
      }
    </div>
    ))}
  </div>
    <div className="col-md-6">
      <label for="passMark" className="form-label"> Pass Mark :</label>
      <input id="passMark" name="passMark" type="number" className="form-control" value={exam.passMark} onChange={handleChange}></input>
    </div>     
    <div className="col-md-6">
      <label for="maximumScore" className="form-label"> Maximum Mark :</label>
      <input id="maximumScore" name="maximumScore" type="number" className="form-control" value={exam.maximumScore} onChange={handleChange}></input>
    </div> 
  
   
   <button type="submit" className="btn btn-primary col-md-1 mx-auto">
     Create
   </button>
 </form>
</>
 );   
}
export default CreateExams;