import React, { useState } from "react";
import "./GenerateExam.css";
import { useLocation, useNavigate } from "react-router-dom";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import SuccessModal from "../Modals/SuccessModal";

function GenerateExam() {
    const location = useLocation();
    // function that navigate to another js view (used in handleSubmit function)
    const navigate = useNavigate();
    const arrayABCD = ['A', 'B', 'C', 'D'];
    const [modalSuccess, setModalSuccess] = useState(false);
    const [examForm, setExamForm] = useState({
        candidateExamId: location.state.candidateExamId,
        questions: location.state.questionList,
        chosenOptionsId: []
    });
    const axiosPrivate = useAxiosPrivate();

    const handleOptionSelection = (i, optionId) => {
        //const { name, value } = event.target;
        const updatedChosenOptionsId = [...examForm.chosenOptionsId];
        updatedChosenOptionsId[i] = optionId;
        setExamForm({ ...examForm, chosenOptionsId: updatedChosenOptionsId });
    };

    const showModalHandler = () => {
        setModalSuccess(true);
    }

    const closeModalHandler = () => {
        setModalSuccess(false);
    }


    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            //await axios.post("https://localhost:7015/api/CandidateExams",examForm);
            await axiosPrivate.post("/api/CandidateExams", examForm)
            showModalHandler();
            //const response = await axios.get(`https://localhost:7015/api/CandidateExams/ExamResults/${examForm.candidateExamId}`)
            const response = await axiosPrivate.get(`/api/CandidateExams/ExamResults/${examForm.candidateExamId}`)
            const examResults = response.data;
            navigate('/CandidateUI/CandidateExamResults', { state: { results: examResults } });

        } catch (error) {
            console.error(error);
            alert("Error on Submit");
        }
    };

    return (
        <>
            <SuccessModal
                show={modalSuccess}
                body="Your answers submitted correctly!"
                closeModalHandler={closeModalHandler}
            ></SuccessModal>
            <h2>Exam Time</h2>
            <div className="container">
                <form onSubmit={handleSubmit} >
                    <div className="mt-4 ">
                        <input type="hidden" name="candidateExamId" value={examForm.candidateExamId} />
                        {examForm.questions.map((question, i) => (

                            <div className="mt-5"  key={question.questionId}>
                                <h5 id="questionDesc">{i + 1}. {question.descriptionStem}</h5>


                                <hr />
                                {question.options.map((option, j) => (
                                    <div>
                                        <table className="table table-striped">
                                            <tbody>
                                                <tr key={option.optionId} >
                                                    <td className="text-start" scope="row" >
                                                        <input
                                                            className="form-check-input"
                                                            type="radio"
                                                            name={`chosenOptionsId[${i}]`}
                                                            value={option.optionId}
                                                            onChange={() => handleOptionSelection(i, option.optionId)} //handleOptionSelection
                                                            />
                                                        {" "}
                                                        {/* <span>&nbsp;</span> */}
                                                        <span>{arrayABCD[j]}{") "} &nbsp;</span>
                                                        <span>{option.description}</span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>                                ))}
                                    <hr />
                            </div>
                        ))}
                        <input type="submit" value="Submit Exam" className="btn btn-primary" />
                    </div>
                </form>

            </div>
        </>
    );
};
export default GenerateExam;