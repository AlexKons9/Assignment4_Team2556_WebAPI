import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Container, Countainer, Table } from 'react-bootstrap';
import useAuth from '../../hooks/useAuth'

const MarkerCandidateExamList = () => {
    const [candidateExams, setCandidateExams] = useState([]);
    const { auth } = useAuth();


    useEffect(() => {
        const fetchData = async () => {
            const response = await axios.get(`https://localhost:7015/api/CandidateExams/ByMarker/${auth.userName}`);
            setCandidateExams(response.data);
        }

        fetchData();
    }, []);

    return (
        <Container>
            <Table>
                <thead>
                    <tr>
                        <th style={{ whiteSpace: "nowrap" }}>Candidate Exam ID</th>
                        <th style={{ whiteSpace: "nowrap" }}>Certificate Type</th>
                        <th style={{ whiteSpace: "nowrap" }}>Candidate First Name</th>
                        <th style={{ whiteSpace: "nowrap" }}>Candidate Last Name</th>
                        <th style={{ whiteSpace: "nowrap" }}>Exam Date</th>
                        <th style={{ whiteSpace: "nowrap" }}>Marked?</th>
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
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    )
}

export default MarkerCandidateExamList;