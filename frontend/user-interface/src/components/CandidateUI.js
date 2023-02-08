import "bootstrap/dist/css/bootstrap.min.css";
import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { Link } from "react-router-dom";
import useAuth from "../hooks/useAuth";
import useAxiosPrivate from "../hooks/useAxiosPrivate";

function CandidateUI() {
  const [voucherDescription, setVoucherDescription] = useState();
  const navigate = useNavigate();
  const { auth } = useAuth();
  const userName = auth.userName;
  const axiosPrivate = useAxiosPrivate();


  const handleChange = (event) => {
    const { name, value } = event.target;
    setVoucherDescription({ ...voucherDescription, [name]: value });
  };

  
  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      //console.log(voucherDescription.voucher);
      const answer = await axiosPrivate.get(`/api/Vouchers/GetVoucher/${voucherDescription.voucher}`);
      const voucher = answer.data;
      //console.log(JSON.stringify(voucher));
      const response = await axiosPrivate.post(`/api/CandidateExams/InsertVoucher/${userName}`, voucher);
      console.log(response.data);
      const candidateExamId = response.data.candidateExamId;
      const questionsList = response.data.questions;
      
      navigate("/CandidateUI/GenerateExam", {
        state: {
          candidateExamId: candidateExamId,
          questionList: questionsList,
        },
      });
    } catch (error) {
      console.error(error);
      alert("Error creating Exam");
    }
  };
  return (
    <div className="container">
      <h3>Welcome Candidate, Insert your Voucher to start your Exam:</h3>
      <form onSubmit={handleSubmit}>

        <div className="form-group ">
          <label className="form-label" htmlFor="voucher">Insert your Voucher:</label>
          <input onChange={handleChange} className="form-control" type="text" id="voucher" name="voucher"></input>
        </div>

        <button type="submit" className="btn btn-primary">
          Generate Exam
        </button>
      </form>
    </div>
  );
}

export default CandidateUI;
