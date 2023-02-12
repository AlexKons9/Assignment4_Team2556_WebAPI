import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { Button, Container, Table } from 'react-bootstrap';
import useAuth from '../../hooks/useAuth'
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

const UnMarkedExamsList = () => {
    const [candidateExams, setCandidateExams] = useState([]); //set marked exam array state
    const { auth } = useAuth(); //retrieve logged in user's data
    const navigate = useNavigate(); //navigate function to automatically redirect page
    const axiosPrivate = useAxiosPrivate(); //custom axios function with user credentials in header


    //
    //Summary: Get and set state of all unmarked exams assigned to logged-in marker
    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axiosPrivate.get(`/api/CandidateExams/unmarkedexams/${auth.userName}`);
                setCandidateExams(response.data);
            } catch (error) {
                console.error(error);
            }
        }

        fetchData();
    }, []);


    //
    //Summary: Redirect to Candidate Exam Review page with chosen candidate exam
    const handleReview = async (candidateExamId) => {
        try {
            const response = await axiosPrivate.get(`/api/CandidateExams/${candidateExamId}`);
            const candidateExam = response.data;
            navigate("/MarkerUI/MarkerCandidateExamReview", { state: { candidateExam: candidateExam } });
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <div className="container-lg">
            <h2 className="mb-5">Unmarked Exams</h2>
            {candidateExams.length === 0 ? <div>There are no pending exams for marking.</div> :
                <table className="table">
                    <thead>
                        <tr>
                            <th>Candidate Exam ID</th>
                            <th>Certificate Type</th>
                            <th>Candidate First Name</th>
                            <th>Candidate Last Name</th>
                            <th>Exam Date</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {candidateExams.map(candidateExam => (
                            <tr key={candidateExam.candidateExamId}>
                                <td>{candidateExam.candidateExamId}</td>
                                <td>{candidateExam.exam.certificate.title}</td>
                                <td>{candidateExam.candidate.firstName}</td>
                                <td>{candidateExam.candidate.lastName}</td>
                                <td>{new Date(candidateExam.examDate).toDateString()}</td>
                                <td>{candidateExam.isMarked == true ? "Marked" : "Unmarked"}</td>
                                <td><button
                                    className="btn btn-outline-success"
                                    onClick={() => handleReview(candidateExam.candidateExamId)}>Review Exam</button></td>
                            </tr>
                        ))}
                    </tbody>
                </table>}
        </div>
    )
}

export default UnMarkedExamsList;