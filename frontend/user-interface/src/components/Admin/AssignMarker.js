import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Container, Table, Button } from 'react-bootstrap';
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

const CandidateExamsList = () => {
    const [candidateExams, setCandidateExams] = useState([]);  //set state of unmarked candidate exams array
    const [markers, setMarkers] = useState([]); //set state of markers array
    const [selectedMarker, setSelectedMarker] = useState(null); //set state of selected marker
    const axiosPrivate = useAxiosPrivate();

    //retrieve all unmarked candidate exams
    useEffect(() => {
        const fetchData = async () => {
            const result = await axiosPrivate.get('/api/CandidateExams/unmarked');
            setCandidateExams(result.data);
            //console.log(result.data)
        };

        fetchData();
    }, []);

    useEffect(() => {
        const fetchData = async () => {
            const result = await axiosPrivate.get('/api/Users/GetAllMarkers');
            setMarkers(result.data);
            console.log(result.data)
        };

        fetchData();
    }, []);

    const handleMarkerSelect = event => {
        setSelectedMarker(event.target.value);
        console.log(event.target.value);
    };

    const assignMarker = async (candidateExam) => {
        candidateExam.markerId = selectedMarker;
        console.log(candidateExam)
        await axiosPrivate.put(`/api/CandidateExams/${candidateExam.candidateExamId}`, candidateExam);
        alert("Marker has been updated!")

        const updatedCandidateExams = candidateExams.map(ce => {
            if (ce.candidateExamId === candidateExam.candidateExamId) {
                return candidateExam;
            }
            return ce;
        });

        setCandidateExams(updatedCandidateExams);
    };


    return (
        <Container>
                    <h1>Assign Markers</h1>
                    <h3>Unmarked Candidate Exams List</h3>
            <hr />
            {candidateExams.length === 0 ? <div>There are no pending exams for marking.</div> :
            <Table>
                <thead>
                    <tr>
                        <th style={{ whiteSpace: "nowrap" }}>Candidate Exam ID</th>
                        <th style={{ whiteSpace: "nowrap" }}>Certificate Type</th>
                        <th style={{ whiteSpace: "nowrap" }}>Candidate First Name</th>
                        <th style={{ whiteSpace: "nowrap" }}>Candidate Last Name</th>
                        <th style={{ whiteSpace: "nowrap" }}>Exam Date</th>
                        <th style={{ whiteSpace: "nowrap" }}>Marked?</th>
                        <th style={{ whiteSpace: "nowrap" }}>Assigned to marker</th>
                        <th style={{ whiteSpace: "nowrap" }}>Select/Change Marker</th>
                    </tr>
                </thead>
                <tbody>
                    {candidateExams.map(candidateExam => (
                        <tr key={candidateExam.candidateExamId}>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.candidateExamId}</td>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.exam.certificate.title}</td>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.candidate.firstName}</td>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.candidate.lastName}</td>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.examDate.toLocaleString()}</td>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.isMarked.toString()}</td>
                            <td style={{ whiteSpace: "nowrap" }}>{candidateExam.markerId}</td>
                            <td style={{ whiteSpace: "nowrap" }}>
                                <select onChange={handleMarkerSelect}>
                                    <option value="">Select a marker</option>
                                    {markers.map(marker => (
                                        <option key={marker.id} value={marker.id}>
                                            {marker.firstName} {marker.lastName}
                                        </option>
                                    ))}
                                </select>
                                <button type="button" onClick={() => assignMarker(candidateExam)}>
                                    Assign
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>}
        </Container>
    );
};

export default CandidateExamsList;
