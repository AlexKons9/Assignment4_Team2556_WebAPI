import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";
import htmlParse from "html-react-parser";

// import DeleteQuestion from "./DeleteQuestion";

function CertificatesListQC() {
  const [certificates, setCertificates] = useState([]);
  const navigate = useNavigate();
  const [showModal, setShowModal] = useState(false);
  const [itemToDelete, setItemToDelete] = useState(0);
  const axiosPrivate = useAxiosPrivate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axiosPrivate.get("/api/Certificates");
        setCertificates(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);

  const handleDetails = async (certificateId) => {
    try {
      const response = await axiosPrivate.get(`/api/Certificates/${certificateId}`);
      const certificateDetails = response.data;
      console.log(certificateDetails);
      navigate("/Certificates/CertificateDetails", {
        state: { certificateDetails: certificateDetails },
      });
    } catch (error) {
      console.error(error);
      alert("Error the Certificate requested doesn't exist.");
    }
  };

  return (
    <div>
      <h1>Certificates List</h1>
      <table className="table">
        <thead>
          <tr>
            <th>Description</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {certificates.map((certificate) => (
            <tr key={certificate.certificateId}>
              <td>{htmlParse(certificate.title)}</td>
              <td>
                <button
                  className="btn btn-success"
                  onClick={() => handleDetails(certificate.certificateId)}
                >
                  Details
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default CertificatesListQC;