import 'bootstrap/dist/css/bootstrap.min.css';
import './NavBar.css';
import { Link } from "react-router-dom";
import useLogout from "../hooks/useLogout"
import useRefreshToken from '../hooks/useRefreshToken';
import useAuth from '../hooks/useAuth';
import NavDropdown from 'react-bootstrap/NavDropdown';

function NavBar() {

    /*    const { loginWithRedirect, isAuthenticated } = useAuth0();*/
    const logout = useLogout();
    const { auth } = useAuth();


    return (

        <div id='main-nav'>
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <div className="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                    <ul className="navbar-nav me-auto">
                        <li className="nav-item">
                            <Link className="nav-link" to="Home" >Home</Link>
                        </li>

                        {/* ADMIN NAVBAR TABS*/}
                        {auth?.roles?.find(roles => roles.includes("Admin"))
                            ?
                            <ul className="navbar-nav ms-auto">
                                <li className="nav-item">
                                    <Link className="nav-link text-light" to="AdminUI/QuestionList" >Questions</Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link text-light" to="AdminUI/Exams" >Exams</Link>
                                </li>    
                                <li className="nav-item">
                                    <Link className="nav-link text-light" to="AdminUI/Candidates" >Candidates</Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link text-light" to="AdminUI/Certificates" >Certificates</Link>
                                </li>
                                <li className="nav-item"><Link className="nav-link text-light" to="AdminUI/AssignMarkers" >Assign Markers</Link></li>
                            </ul>
                            : <li></li>
                        }

                        {/* CANDIDATE NAVBAR TABS*/}
                        {auth?.roles?.find(roles => roles?.includes("Candidate"))
                            ? <div className='navbar-collapse collapse w-100 order-3 dual-collapse2'>
                                <ul className="navbar-nav ms-auto">
                                    <li className="nav-item">
                                        <Link className="nav-link" to="EShopList" >E-Shop</Link>
                                    </li>
                                    {/* <li  className="nav-item">
                                    <Link className="nav-link text-light" to="CandidateUI" >Exams</Link>
                                    </li> */}
                                    <NavDropdown title="Exams" id="navbarScrollingDropdown">
                                        <Link className="nav-link text-light" to="/Exams/UpcomingExams" >
                                            <div className='dropdown-item' >Upcoming Exams</div>
                                        </Link>
                                        <Link className="nav-link text-light" to="CandidateUI" >
                                            <div className='dropdown-item'>Take your Exam Now!</div>
                                        </Link>
                                        <Link className="nav-link text-light" to="/Exams/SchedulerMenu" >
                                            <div className='dropdown-item'>Schedule your Next Exam!</div>
                                        </Link>
                                        <NavDropdown.Divider />
                                        <Link className="nav-link text-light" to="/Exams/VouchersList" >
                                            <div className='dropdown-item'>Vouchers</div>
                                        </Link>
                                    </NavDropdown>
                                    <li className="nav-item">
                                        <Link className="nav-link " to="MyCertificatesList" >My Certificates</Link>
                                    </li>
                                </ul>
                            </div>
                            : <li></li>
                        }

                        {/* MARKER NAVBAR TABS*/}
                        {auth?.roles?.find(roles => roles?.includes("Marker"))
                            ? <>
                                <li className="nav-item"><Link className="nav-link text-light" to="MarkerUI/UnmarkedExamList" >View Unmarked Exams</Link></li>
                                <li className="nav-item"><Link className="nav-link text-light" to="MarkerUI/MarkedExamsList" >View Marked Exams</Link></li>
                            </>
                            : <li></li>
                        }

                        {/* QualityControl NAVBAR TABS*/}
                        {auth?.roles?.find(roles => roles?.includes("QualityControl"))
                            ? <>
                                <li className="nav-item"><Link className="nav-link text-light" to="QualityControlUI/CandidateList" >View Candidate List</Link></li>
                                <li className="nav-item"><Link className="nav-link text-light" to="QualityControlUI/ExamList" >View Exam List</Link></li>
                                <li className="nav-item"><Link className="nav-link text-light" to="QualityControlUI/CandidateList" >View Candidates</Link></li>
                                <li className="nav-item"><Link className="nav-link text-light" to="QualityControlUI/CertificateList" >View Certificates</Link></li>
                              </>
                            : <li></li>
                        }
                    </ul>
                </div>
                <div className="mx-auto order-0">
                    <a className="navbar-brand mx-auto">Assignment_4A_Team2556</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".dual-collapse2">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                </div>

                {/* LOGIN - LOGOUT TOGGLE NAVBAR*/}
                {auth?.userName ? (
                    <div className="navbar-collapse collapse w-100 order-3 dual-collapse2">
                        <ul className="navbar-nav ms-auto">
                            <li className="nav-item">
                                <p className="nav-link text-light">Welcome {auth.userName} (role:{auth.roles})</p>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link text-light" onClick={() => logout()}>Logout</Link>
                            </li>
                        </ul>
                    </div>

                ) : (

                    <div className="navbar-collapse collapse w-100 order-3 dual-collapse2">
                        <ul className="navbar-nav ms-auto">
                            <li className="nav-item">
                                <Link className="nav-link text-light" to="Register" >Register</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link text-light" to="Login" >Login</Link>
                            </li>
                        </ul>
                    </div>

                )}
            </nav>
        </div>

    );
}

export default NavBar;




