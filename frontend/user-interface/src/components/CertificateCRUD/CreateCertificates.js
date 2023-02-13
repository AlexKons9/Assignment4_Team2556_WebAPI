import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function CreateCertificate() {
    
  const [certificate, setCertificate] = useState({
    title: "",
    isActive: (false),
  });

  const handleChange = (event) => {
    setCertificate({
        ...certificate,
        [event.target.name]: event.target.type === 'checkbox' ? event.target.checked : event.target.value
    });;
  };

  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axiosPrivate.post(
        "/api/Certificates",
        certificate
      );
      const certificateId = response.data.certificateId;
        navigate("/AdminUI/CreateTopics", {
          state: { certificateId: certificateId },
        });
    } catch (error) {
      console.error(error);
      alert("Error creating certificate");
    }
  };
   return (
    <div className="container">
        <h2>Create Certificate</h2>
       <form onSubmit={handleSubmit}>

         <div className="form-group">
          <label htmlFor="title" className="mb-2 mt-4">Certificate Title</label>
          <input
            type="text"
            className="form-control"
            id="title"
            name="title"
            value={certificate.title}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group mt-3">
           <label className="mx-2" htmlFor="isActive">Is Active</label>
            <input type="checkbox" className="form-check-input" id="isActive" name="isActive" value={certificate.isActive} onChange={handleChange}/>
        </div>
        
        <button type="submit" className="btn btn-primary">
          Create
        </button>
      </form>
     </div>
  );
}

export default CreateCertificate;