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
    <div className="container-xl text-center">
    <h1>Candidates List</h1>
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
                  className="btn btn-outline-success"
                  onClick={() => handleDetails(i)}
                >
                  Details
                </button>{" "}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default CandidatesListQC;