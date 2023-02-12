import React, { useState, useEffect } from 'react';
import { Container, Table, Button } from 'react-bootstrap';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

const CandidateExamsList = () => {
    const [candidateExams, setCandidateExams] = useState([]);  //set state of unmarked candidate exams array
    const [markers, setMarkers] = useState([]); //set state of markers array
    const [selectedMarker, setSelectedMarker] = useState(null); //set state of selected marker
    const axiosPrivate = useAxiosPrivate(); //custom axios function with user credentials in header

    //
    //Summary: retrieve and set all unmarked candidate exams
    useEffect(() => {
        const fetchData = async () => {
            const result = await axiosPrivate.get('/api/CandidateExams/unmarked'); //get unmarked candidate exams
            setCandidateExams(result.data); //set state of unmarked candidate exams array
        };

        fetchData();
    }, []);


    //
    //Summary: Get and set state of all marker users in array
    useEffect(() => {
        const fetchData = async () => {
            const result = await axiosPrivate.get('/api/Users/GetAllMarkers'); //get users that are markers
            setMarkers(result.data); //set array of markers
        };

        fetchData();
    }, []);


    //
    //Summary: Set chosen marker to selected marker state
    const handleMarkerSelect = event => {
        setSelectedMarker(event.target.value);
    };


    //
    //Summary: Assign chosen marker to the candidate exam
    const assignMarker = async (candidateExam) => {
        candidateExam.markerId = selectedMarker;  //assign selected marker to candidate exam
        await axiosPrivate.put(`/api/CandidateExams/${candidateExam.candidateExamId}`, candidateExam);  //update database with chosen marker
        alert("Marker has been updated!")

        //update state of candidateExams with the chosen marker
        const updatedCandidateExams = candidateExams.map(ce => {
            if (ce.candidateExamId === candidateExam.candidateExamId) {
                return candidateExam;
            }
            return ce;
        });
        setCandidateExams(updatedCandidateExams);
    };


    return (
        <div className="mx-5">
            <h1>Assign Markers</h1>
            <h3>Unmarked Candidate Exams List</h3>
            <hr />
            {candidateExams.length === 0 ? <div>There are no pending exams for marking.</div> :
                <table className="table table-centered table-striped">
                    <thead className="align-middle">
                        <tr>
                            <th>Candidate Exam ID</th>
                            <th>Certificate Type</th>
                            <th>Candidate First Name</th>
                            <th>Candidate Last Name</th>
                            <th>Exam Date</th>
                            <th>Marker Id</th>
                            <th>Select/Change Marker</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {candidateExams.map(candidateExam => (
                            <tr key={candidateExam.candidateExamId}>
                                <td className="col-1">{candidateExam.candidateExamId}</td>
                                <td className="col-1">{candidateExam.exam.certificate.title}</td>
                                <td className="col-1">{candidateExam.candidate.firstName}</td>
                                <td className="col-1">{candidateExam.candidate.lastName}</td>
                                <td className="col-1">{new Date(candidateExam.examDate).toDateString()}</td> 
                                <td className="col-2">{candidateExam.markerId}</td>
                                <td className="col-2">
                                    <select className="form-select" onChange={handleMarkerSelect}>
                                        <option value="">Select/Change marker</option>
                                        {markers.map(marker => (
                                            <option key={marker.id} value={marker.id}>
                                                {marker.firstName} {marker.lastName}
                                            </option>
                                        ))}
                                    </select>
                                    </td>
                                    <td className="col-1">
                                    <button type="button" className="btn btn-outline-success mb-4" onClick={() => assignMarker(candidateExam)}>
                                        Assign
                                    </button>
                                    </td>
                            </tr>
                        ))}
                    </tbody>
                </table>}
        </div>
    );
};

export default CandidateExamsList;
