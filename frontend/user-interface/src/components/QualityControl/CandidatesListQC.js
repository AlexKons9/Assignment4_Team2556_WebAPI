import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";
import DeleteQuestion from "../Question/DeleteQuestion"

function CandidatesListQC() {
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


  return (
    <div>
      <h1>Candidates List</h1>
      <table className="table">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {candidateList.map((candidate, i) => (
            <tr key={candidate.Id}>
              <td>{candidate.firstName}</td>
              <td>{candidate.lastName}</td>
              <td>
                <button
                  className="btn btn-success"
                  onClick={() => handleDetails(i)}
                >
                  Details
                </button>{""}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default CandidatesListQC;