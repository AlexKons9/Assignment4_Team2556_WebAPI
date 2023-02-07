import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function CreateExams() {
    const [exam, setExam] = useState({
        certificateId: "",
        passMark: "",
        maximumScore: "",
      });    
      const [examQuestions, setExamQuestions] = useState({
        examId: "",
        questionId:"",
      });
        const [certificates, setCertificates] = useState([]);
        const [certificate, setCertificate] = useState([]);
        const navigate = useNavigate();
        const axiosPrivate = useAxiosPrivate();
    
      useEffect(() => {
        const fetchCertificates = async () => {
          try {
            const response = await axiosPrivate.get("/api/Certificates");
            setCertificates(response.data);
            console.log(response.data);
        } catch (error) {
            console.error(error);
        }
    };
    fetchCertificates();
}, []);
const handleChange = (event) => {
    const { name, value } = event.target;
    setExam({ ...exam, [name]: value });
    setCertificate({ ...certificate, [name]: value });
    console.log(exam);
    console.log(certificate);
    
      };
 return(
     <>
    <h1>Create New Exam</h1>
 <form onSubmit={""}>


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
     <table className="table">
        <thead>
          <tr>
            <th>Topic Title</th>
          </tr>
        </thead>
        <tbody>
        {certificates.map((certificate) => (
            <tr key={certificate.certificateId} value={certificate.certificateId}>  
               <td>{certificate.title}</td> 
         </tr>
  ))}

        </tbody>
        </table>
   </div>
   
   <button type="submit" className="btn btn-primary">
     Create
   </button>
 </form>
</>
 );   
}
export default CreateExams;