import useAuth from "../hooks/useAuth";
import useAxiosPrivate from "../hooks/useAxiosPrivate";

function SchedulerMenu() {
    const { auth } = useAuth();
    const userName = auth.userName;
    const axiosPrivate = useAxiosPrivate();

    const [examDetailsDTO, setExamDetailsDTO] = useState(
        {
            certificateId: "",
            userName: "",
            examDate: ""
        }
    );

    // const onChangeHandler = (event) => {
    //     const { name, value } = event.target;
    //     setExamDetailsDTO({ ...examDetailsDTO, [name]: value });
    //   };


    // const handleSubmit = async (event) => {
    //     event.preventDefault();
    //     try {
    //       //console.log(voucherDescription.voucher);
    //       const answer = await axiosPrivate.get(`/api/Vouchers/GetVoucher/${voucherDescription.voucher}`);
    //       const voucher = answer.data;
    //       //console.log(JSON.stringify(voucher));
    //       const response = await axiosPrivate.post(`/api/CandidateExams/InsertVoucher/${userName}`, voucher);
    //       // console.log(response.data);
    
    //       const candidateExamId = response.data.candidateExamId;
    //       const questionsList = response.data.questions;
    
    //       voucher.isClaimed = true;
    //       await axiosPrivate.put(`/api/Vouchers/${voucher.voucherId}`, voucher);
          
          
    //       navigate("/CandidateUI/GenerateExam", {
    //         state: {
    //           candidateExamId: candidateExamId,
    //           questionList: questionsList,
    //         },
    //       });
    //     } catch (error) {
    //       console.error(error);
    //       alert("Error creating Exam");
    //     }
    //   };


    return(
        <div className="container">
            <h1>Exam Scheduler Menu</h1>
            <form onSubmit={handleSubmit}>

                <div className="form-group ">
                    <label>Insert Voucher Code</label>
                    <input onChange={onChangeHandler} type="text" id="voucher" name="voucher"></input>
                </div>

                <div className="form-group ">
                    <label>Select Date</label>
                    <input type="date" id="date" name="date"></input>
                </div>

                <button type="submit" className="btn btn-primary">
                    Submit
                </button>

            </form>
        </div>
    );
}

export default SchedulerMenu;