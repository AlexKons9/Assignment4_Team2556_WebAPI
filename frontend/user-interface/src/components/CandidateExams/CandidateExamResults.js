import { useLocation, useNavigate, Link } from "react-router-dom";

function CandidateExamResults() {
  const location = useLocation();
  const navigate = useNavigate();

  const examResults = location.state.results;
  console.log(examResults);

  return (
    <div className="container col-10">
      <h1>Exam Results</h1>
      <hr />

      <div>
        <dl className="row">
          <dt className="col-sm-2">Marks per topic</dt>
          <dd className="col-sm-10">
            {examResults.resultsPerTopic.map((result, index) => (
              <div key={index}>
                <h6>{result[0]}</h6>
                <div>
                  {result[1]}/{result[2]} Correct Answers
                </div>
              </div>
            ))}
          </dd>

          <hr />

          <dt className="col-sm-2">Exam Score</dt>
          <dd className="col-sm-10">{examResults.examScore}</dd>

          <hr />

          <dt className="col-sm-2">Percentage Score</dt>
          <dd className="col-sm-10">{examResults.percentageScore}</dd>

          <hr />

          <dt className="col-sm-2">Test Result</dt>
          <dd className="col-sm-10">{examResults.testResult}</dd>

          <hr />

          <dt className="col-sm-2">Number Of Awarded Marks</dt>
          <dd className="col-sm-10">{examResults.numberOfAwardedMarks}</dd>

          <hr />

          <dt className="col-sm-2">Number Of Possible Marks</dt>
          <dd className="col-sm-10">{examResults.numberOfPossibleMakrs}</dd>

          <hr />

          <dt className="col-sm-2">Examination Date</dt>
          <dd className="col-sm-10">{examResults.examDate}</dd>
        </dl>
        <hr />
      </div>
      <div>
        <Link className="btn btn-secondary" to="/">Back to Home</Link>
      </div>
    </div>
  );
}

export default CandidateExamResults;
