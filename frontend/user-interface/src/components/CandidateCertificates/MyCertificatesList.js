import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";


function MyCertificatesList() {
  //const [candidateExams, setCandidateExams] = useState([]);
  const [candidateCertificates, setCandidateCertificates] = useState([]);
  const axiosPrivate = useAxiosPrivate();
  const navigate = useNavigate();
  const { auth } = useAuth();
  const userName = auth.userName

  useEffect(() => {
    const fetchData = async () => {
      try {
        //const response = await axiosPrivate.get(`/api/CandidateExams/Certificates?userName=${userName}`);
        const response = await axiosPrivate.get(`/api/CandidateCertificates/ByUsername/${userName}`);
        console.log(response.data);
        setCandidateCertificates(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);


  const handleDetails = async (examId, certificateTitle) => {
    try {
        console.log(examId);
        //const response = await axiosPrivate.get(`/api/CandidateExams/ExamResults/${examId}`)
        const response = await axiosPrivate.get(`/api/CandidateExams/ExamResults/${examId}`)
        const examResults = response.data;
        navigate('/MyCertificatesList/CertificateDetails', { state: { results: examResults, certificateTitle: certificateTitle } });
    } catch (error) {
      console.error(error);
      alert("Error the Certificate requested doesn't exist.");
    }
  };

  // Gets the date in D/M/YYYY
  function getDate(dateTime){
	return `${dateTime.getDate()}-${dateTime.getMonth() + 1}-${dateTime.getFullYear()}`;
  };


  return (
    <div className="container-lg">
      <h1>My Certificates</h1>

      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">Certificate In</th>
            <th scope="col">Assessment Test Code</th>
            <th scope="col">Examination Date</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          {candidateCertificates.map((candidateCertificate) => (
            <tr key={candidateCertificate.candidateCertificateId}>
              <td scope="row"><h6>{candidateCertificate.candidateExam.exam.certificate.title}</h6></td>
              <td scope="row"><h6>{candidateCertificate.candidateExam.assessmentTestCode}</h6></td>
              <td scope="row"><h6>{new Date(candidateCertificate.candidateExam.examDate).toDateString()}</h6></td>
              <td>
                <button
                  className="btn btn-outline-success"
                  onClick={() => handleDetails(candidateCertificate.candidateExam.candidateExamId, candidateCertificate.candidateExam.exam.certificate.title)}
                >
                  Details
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default MyCertificatesList;
