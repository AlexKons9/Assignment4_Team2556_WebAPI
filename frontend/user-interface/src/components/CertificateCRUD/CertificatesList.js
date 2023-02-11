import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import DeleteCertificate from "./CertificateCrudDeleteModal"
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";
import htmlParse from "html-react-parser";

// import DeleteQuestion from "./DeleteQuestion";

function CertificatesList() {
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


  const showConfirmPopupHandler = (id) => {
    setShowModal(true);
    setItemToDelete(id);
    console.log(id);
  };
  const closeConfirmPopupHandler = () => {
    setShowModal(false);
    setItemToDelete(0);
  };

  const deleteConfirmHandler = async () => {
    await axiosPrivate
      .delete(`/api/Certificates/${itemToDelete}`)
      .then((response) => {
        setCertificates((existingData) => {
          return existingData.filter((_) => _.certificateId !== itemToDelete);
        });
        setItemToDelete(0);
        setShowModal(false);
      });
  };

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



  const handleEdit = async (certificateId) => {
    try {
      const response = await axiosPrivate.get(`/api/Certificates/${certificateId}`);
      const certificate = response.data;
      console.log(certificate);
      navigate("/AdminUI/Certificates/Edit", { state: { certificate: certificate } });
    } catch (error) {
      console.error(error);
      alert("Error the Question requested doesn't exist.");
    }
  };

  return (
    <div className="container">
      <DeleteCertificate
        showModal={showModal}
        title="Delete Confirmation!"
        body="Are you sure to delete this Certificate?"
        closeConfirmPopupHandler={closeConfirmPopupHandler}
        deleteConfirmHandler={deleteConfirmHandler}
      ></DeleteCertificate>

      <h1>Certificates List</h1>

      <p>
        {/* <button className='btn btn-primary'>Create New</button> */}
        <Link className="btn btn-outline-primary" to="Create">
          Create New Certificate
        </Link>
      </p>
      <table className="table">
        <thead>
          <tr>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {certificates.map((certificate) => (
            <tr key={certificate.certificateId}>
              <td>{htmlParse(certificate.title)}</td>
              <td>
                <button
                  className="btn btn-outline-secondary"
                  onClick={() => handleEdit(certificate.certificateId)}
                >
                  Edit
                </button>{" "}
                <button
                  className="btn btn-outline-success"
                  onClick={() => handleDetails(certificate.certificateId)}
                >
                  Details
                </button>{" "}
                <button
                  className="btn btn-outline-danger"
                  onClick={() => {
                    showConfirmPopupHandler(certificate.certificateId);
                  }}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default CertificatesList;