import useAuth from "../../hooks/useAuth";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import React, { useState, useEffect, useNavigate } from "react";
import SuccessModal from "../Modals/SuccessModal"


function SchedulerMenu() {
    const { auth } = useAuth();
    const userName = auth.userName;
    const axiosPrivate = useAxiosPrivate();
    const [modalSuccess, setModalSuccess] = useState(false);

    const [examDate, setExamDate] = useState();
    const [voucherDescription, setVoucherDescription] = useState();

    const onChangeHandlerDate = (event) => {
        const { name, value } = event.target;
        setExamDate({ ...examDate, [name]: value });
    };
    const onChangeHandlerVoucher = (event) => {
        const { name, value } = event.target;
        setVoucherDescription({ ...voucherDescription, [name]: value });
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
            console.log(voucherDescription.voucher);

          const answer = await axiosPrivate.get(`/api/Vouchers/GetVoucher/${voucherDescription.voucher}`);
          const voucher = answer.data;
          console.log(JSON.stringify(voucher));
          const response = await axiosPrivate.post(`/api/CandidateExams/InsertVoucher/${userName}?examDate=${examDate.date}`, voucher);
          console.log(response.data);
    
          const candidateExamId = response.data.candidateExamId;
          const questionsList = response.data.questions;
    
          voucher.isClaimed = true;
          await axiosPrivate.put(`/api/Vouchers/${voucher.voucherId}`, voucher);
          showModalHandler();

        } catch (error) {
          console.error(error);
          alert("Date or Voucher are incorrect!");
        }
      };


    return (
        <div className="">
            <h1>Exam Scheduler Menu</h1>
            <SuccessModal
            show={modalSuccess}
            body={`You have scheduled the exam successfully!! 
                  Go to "Exams/Upcoming Exams" to view your booked examinations!`}
            closeModalHandler={closeModalHandler}
            ></SuccessModal>
            <form onSubmit={handleSubmit}>

                <div className="form-group ">
                    <label>Insert Voucher Code</label>
                    <input onChange={onChangeHandlerVoucher} type="text" id="voucher" name="voucher"></input>
                </div>

                <div className="form-group ">
                    <label>Select Date</label>
                    <input onChange={onChangeHandlerDate} type="date" id="date" name="date"></input>
                </div>

                <button type="submit" className="btn btn-primary">
                    Submit
                </button>

            </form>
        </div>
    );
}

export default SchedulerMenu;