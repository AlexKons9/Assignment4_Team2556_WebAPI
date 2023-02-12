import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";
import DeleteQuestion from "../Question/DeleteQuestion";
import "../Question/DetailsQuestion.css";

function CandidatesList() { 
    const [candidateList, setCandidateList] = useState([]);
    const axiosPrivate = useAxiosPrivate();
    const navigate = useNavigate();
    const [showModal, setShowModal] = useState(false);
    const [itemToDelete, setItemToDelete] = useState(0);
    useEffect(() => {
        const fetchData = async () => {
          try {
            const response = await axiosPrivate.get("/api/Candidate");
            setCandidateList(response.data);
          } catch (error) {
            console.error(error);
          }
        };
        fetchData();
      }, []);
      const handleDetails = async (i) => {
        try {
            console.log(candidateList[i]);
          const response = await axiosPrivate.get(`/api/Candidate/${candidateList[i].userName}`);
          const candidateDetails = response.data;
          navigate("/Candidates/Details", {
            state: { candidateDetails: candidateDetails },
          });
        } catch (error) {
          console.error(error);
          alert("Error the Candidate requested doesn't exist.");
        }
      };      
      const handleEdit = async (i) => {
        try {
            console.log(candidateList[i]);
          const response = await axiosPrivate.get(`/api/Candidate/${candidateList[i].userName}`);
          const candidateDetails = response.data;
          navigate("/AdminUI/Candidates/Edit", {
            state: { candidateDetails: candidateDetails },
          });
        } catch (error) {
          console.error(error);
          alert("Error the Candidate requested doesn't exist.");
        }
      };
      const showConfirmPopupHandler = (userName) => {
        setShowModal(true);
        setItemToDelete(userName);
        console.log(userName);
      };
      const closeConfirmPopupHandler = () => {
        setShowModal(false);
        setItemToDelete(0);
      };
    
      const deleteConfirmHandler = async () => {
        await axiosPrivate
          .delete(`/api/Candidate/${itemToDelete}`)
          .then((response) => {
            setCandidateList((existingData) => {
              return existingData.filter((_) => _.userName !== itemToDelete);
            });
            setItemToDelete(0);
            setShowModal(false);
          });
      };    

    return(
    <div className="container-xl text-center">
      <DeleteQuestion
        showModal={showModal}
        title="Delete Confirmation!"
        body="Are you sure to delete this Candidate?"
        closeConfirmPopupHandler={closeConfirmPopupHandler}
        deleteConfirmHandler={deleteConfirmHandler}
      ></DeleteQuestion>
    <h1>Candidates List</h1>
    <p>
        <Link className="btn btn-outline-primary" to="Register">
          Create New
        </Link>
      </p>
      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">First Name</th>    
            <th scope="col">Last Name</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          {candidateList.map((candidate,i) => (
            <tr key={candidate.Id}>
              <td scope="row"><h6>{candidate.firstName}</h6></td>
              <td scope="row"><h6>{candidate.lastName}</h6></td>
              <td>
                <button
                  className="btn btn-outline-secondary"
                  onClick={() => handleEdit(i)}
                >
                  Edit
                </button>{" "}
                
                <button
                  className="btn btn-outline-success"
                  onClick={() => handleDetails(i)}
                >
                  Details
                </button>{" "}
                
                <button
                  className="btn btn-outline-danger"
                  onClick={() => {
                    showConfirmPopupHandler(candidateList[i].userName)}}
                >
                  Delete
                </button>{" "}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
    )
}

export default CandidatesList;