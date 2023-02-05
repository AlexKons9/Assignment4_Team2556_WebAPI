import { useLocation, useNavigate } from "react-router-dom";
import {  useEffect, useState } from "react";
import axios from "axios";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function EditCandidate() {
    const location = useLocation();
    const navigate = useNavigate();
    const [candidate, setCandidate] = useState({firstName: location.state.candidateDetails.firstName});
     console.log(candidate);
    const axiosPrivate = useAxiosPrivate();


    const handleChange = (event) => {
        const { name, value } = event.target;
        setCandidate({ ...candidate, [name]: value });
    };

    const handleSubmit = async () => {
        try {
            console.log(candidate);
            await axiosPrivate.put(`/api/Candidate/${candidate.userName}`);
            alert("Candidate edited successfully!");

            navigate('/AdminUI/Candidates');
        } 
        catch (error) {
            console.error(error);
            alert("Error editing Candidate");
        }
    };

    return (
        <>
        <h1>Edit Candidate</h1>
            <form onSubmit={handleSubmit}>
                {/* <input type="hidden" name="username" value={candidate.userName} /> */}
                <div className="form-group">
                    <label htmlFor="firstName">First Name</label>
                    <input
                        className="form-control"
                        id="firstName"
                        name="firstName"
                        value={candidate.firstName}
                        onChange={handleChange}
                        required>
                        
                    </input>
                </div>
                <button type="submit" className="btn btn-primary">Edit</button></form>
        </>
    );
}

export default EditCandidate;