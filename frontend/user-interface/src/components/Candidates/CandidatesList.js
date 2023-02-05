import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";

function CandidatesList() { 
    const [candidateList, setCandidateList] = useState([]);
    const axiosPrivate = useAxiosPrivate();
    const navigate = useNavigate();

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
          navigate("/AdminUI/Candidates/Details", {
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

    return(
    <div>
    <h1>Candidates List</h1>
    <p>
        {/* <button className='btn btn-primary'>Create New</button> */}
        <Link className="btn btn-primary" to="Register">
          Create New Candidate
        </Link>
      </p>
      <table className="table">
        <thead>
          <tr>
            <th>First Name</th>    
            <th>Last Name</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {candidateList.map((candidate,i) => (
            <tr key={candidate.Id}>
              <td>{candidate.firstName}</td>
              <td>{candidate.lastName}</td>
              <td>
                <button
                  className="btn btn-secondary"
                  onClick={() => handleEdit(i)}
                >
                  Edit
                </button>{" "}
                |
                <button
                  className="btn btn-success"
                  onClick={() => handleDetails(i)}
                >
                  Details
                </button>{""}
                |
                <button
                  className="btn btn-danger"
                  //onClick={""}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
    )
}

export default CandidatesList;