import React, { useState, useEffect } from "react";
import { useLocation,useNavigate } from "react-router-dom";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function EditCertificate() {
  const location = useLocation();
  const [certificate, setCertificate] = useState({
    certificateId: location.state.certificate.certificateId,
    title: location.state.certificate.title,
    isActive: location.state.certificate.isActive,
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
      const response = await axiosPrivate.put(
        `/api/Certificates/${certificate.certificateId}`,
        certificate
      );
      const topics = await axiosPrivate.get(`api/Topics/CertificateTopics/${certificate.certificateId}`);
      navigate("/AdminUI/EditTopics", {
        state: { certificateId: certificate.certificateId, topics: topics.data },
      });
    } catch (error) {
      console.error(error);
      alert("Error creating certificate");
    }
  };
console.log(certificate)
   return (
    <div className="container">
      <h2>Edit Certificate</h2>
       <form onSubmit={handleSubmit}>
         <div className="form-group">
          <label htmlFor="title">Title</label>
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

        <div className="form-group  mt-3">
           <label className="mx-2" htmlFor="isActive">Is Active</label>
            <input type="checkbox" className="form-check-input" id="isActive" name="isActive" value={certificate.isActive} checked={certificate.isActive} onChange={handleChange}/>
        </div>
        
        <button type="submit" className="btn btn-primary">
          Edit
        </button>
      </form>
     </div>
  );
}

export default EditCertificate;