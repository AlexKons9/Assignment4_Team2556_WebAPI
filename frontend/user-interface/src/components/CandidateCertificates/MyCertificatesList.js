import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";


function MyCertificatesList() {
  const [candidateExams, setCandidateExams] = useState([]);
  const axiosPrivate = useAxiosPrivate();
  const navigate = useNavigate();
  const { auth } = useAuth();
  const userName = auth.userName

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axiosPrivate.get(
          `/api/CandidateExams/Certificates?userName=${userName}` 
        );
        console.log(response.data);
        setCandidateExams(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);


  const handleDetails = async (examId) => {
    try {
        console.log(examId);
        const response = await axiosPrivate.get(`/api/CandidateExams/ExamResults/${examId}`)
        const examResults = response.data;
        navigate('/MyCertificatesList/CertificateDetails', { state: { results: examResults } });
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
    <div className="container col-12">
      <h1>My Certificates</h1>
      <hr />

      <table>
        <thead>
          <tr>
            <th className="col-sm-2">Certificate In</th>
            <th className="col-sm-2">Assessment Test Code</th>
            <th className="col-sm-2">Examination Date</th>
            <th className="col-sm-2"></th>
          </tr>
        </thead>
        <tbody>
          {candidateExams.map((exam) => (
            <tr key={exam.candidateExamId}>
              <td>{}</td> {/* here we have to insert name of certificate after the marker approve the exam  */}
              <td>{exam.assessmentTestCode}</td>
              <td>{getDate(new Date(exam.examDate))}</td>
              <td>
                <button
                  className="btn btn-success"
                  onClick={() => handleDetails(exam.candidateExamId)}
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
