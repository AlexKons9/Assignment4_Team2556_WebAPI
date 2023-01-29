import { useLocation, useNavigate } from "react-router-dom";

function DetailsQuestion() {
  var count = 1;
  const location = useLocation();
  const question = location.state.questionDetails;
  const correctAnswerIndex = question.options.findIndex((option) => option.isCorrect === true);
//   console.log(question);

  return (
    <div>
      <h1>Details</h1>

      <div>
        <h4>Question</h4>
        <hr />
        <dl className="row">
          <dt className="col-sm-2">Description Stem</dt>
          <dd className="col-sm-10">{question.descriptionStem}</dd>
          <dt className="col-sm-2">Topic</dt>
          <dd className="col-sm-10">{question.topic.topicDescription}</dd>
        </dl>

        <hr />

        {question.options.map((option) => (
            <div key={option.optionId}>
              <dt>Option {count++}</dt>
              <dd>{option.description}</dd>
            </div>
        ))}

          <div>
            <dt>Correct Answer</dt>
            <dd>
                Option {correctAnswerIndex + 1}
            </dd>
          </div>

      </div>
    </div>
  );
}

export default DetailsQuestion;
