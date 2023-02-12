import { useLocation, useNavigate, Link } from "react-router-dom";


function CertificateDetails() {
  const location = useLocation();
  const navigate = useNavigate();

  const examResults = location.state.results;
  const certificateTitle = location.state.certificateTitle;
  console.log(examResults);

  return (
    <div className="container col-10">
      <h1>{certificateTitle} Certificate</h1>


      <table className="table table-bordered ">
        <tbody>

          <tr>
            <th className="align-middle col-6">Marks per topic</th>
            <td className="col-6">
              {examResults.resultsPerTopic.map((result, index) => (
                
                <div className="align-middle" key={index}>
                  <h6 >{result[0]}</h6>
                  <div>
                    {result[1]}/{result[2]} Correct Answers
                  </div>
                </div>
              ))}
            </td>
          </tr>

          <tr>
            <th className="col-6">Exam Score</th>
            <td className="col-6">{examResults.examScore}</td>
          </tr>

          <tr>
            <th className="col-6">Percentage Score</th>
            <td className="col-6">{examResults.percentageScore}</td>
          </tr>

          <tr>
            <th className="col-6">Test Result</th>
            <td className="col-6">{examResults.testResult}</td>
          </tr>

          <tr>
            <th className="col-6">Number Of Awarded Marks</th>
            <td className="col-6">{examResults.numberOfAwardedMarks}</td>
          </tr>


          <tr>
            <th className="col-6">Number Of Possible Marks</th>
            <td className="col-6">{examResults.numberOfPossibleMakrs}</td>
          </tr>

          <tr>
            <th className="col-6">Examination Date</th>
            <td className="col-6">{new Date(examResults.examDate).toDateString()}</td>
          </tr>

        </tbody>
      </table>
      <div>
        <Link className="btn btn-secondary" to="/MyCertificatesList">Back</Link>
      </div>
    </div>
  );
}

export default CertificateDetails;
