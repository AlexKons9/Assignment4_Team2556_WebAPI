import { useLocation, useNavigate, Link } from "react-router-dom";

function SchedulerMenu() {
    return(
        <div>
            <h1>Exam Scheduler Menu</h1>
            <form>
                <div>
                    <label>Insert Voucher Code</label>
                    <input type="text" id="voucher" name="voucher"></input>
                </div>
                <div>
                    <label>Select Date</label>
                    <input type="date" id="date" name="date"></input>
                </div>
                <button>Submit</button>
            </form>
        </div>
    );
}

export default SchedulerMenu;