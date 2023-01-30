import { useLocation, useNavigate, Link } from "react-router-dom";
import React from 'react';

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
          <dd className="col-sm-10"><React.Fragment>{question.descriptionStem}</React.Fragment></dd>
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

          <div>
            <Link className='btn btn-secondary' to="../AdminUI">Back to List</Link>
          </div>

      </div>
    </div>
  );
}

export default DetailsQuestion;
