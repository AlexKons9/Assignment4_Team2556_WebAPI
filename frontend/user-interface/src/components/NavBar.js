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
                                <Link className="nav-link text-light" to="AdminUI" >Admin UI</Link>
                                </li>
                                <li className="nav-item">
                                <Link className="nav-link text-light" to="AdminUI/Candidates" >Candidates</Link>
                                </li>                                
                                <li className="nav-item">
                                <Link className="nav-link text-light" to="AdminUI/Exams" >Exams</Link>
                                </li>
                            </ul>
                            : <li></li>
                        }

                        {/* CANDIDATE NAVBAR TABS*/}
                        {auth?.roles?.find(roles => roles?.includes("Candidate"))
                            ? <div className='navbar-collapse collapse w-100 order-3 dual-collapse2'>
                                <ul className="navbar-nav ms-auto">
                                    <li  className="nav-item">
                                    <Link className="nav-link" to="EShopList" >E-Shop</Link>
                                    </li>
                                    {/* <li  className="nav-item">
                                    <Link className="nav-link text-light" to="CandidateUI" >Exams</Link>
                                    </li> */}
                                    <NavDropdown title="Exams" id="navbarScrollingDropdown">
                                        <Link className="nav-link text-light" to="CandidateUI" >
                                            <div className='dropdown-item' >Oncoming Exams</div>
                                        </Link>
                                        <Link className="nav-link text-light" to="" >
                                            <div className='dropdown-item'>Schedule your next exam!</div>
                                        </Link>
                                        <NavDropdown.Divider />
                                        <Link className="nav-link text-light" to="Exams/VouchersList" >
                                            <div className='dropdown-item'>Vouchers</div>
                                        </Link>
                                    </NavDropdown>
                                    <li  className="nav-item">
                                    <Link className="nav-link " to="MyCertificatesList" >My Certificates</Link>
                                    </li>
                                </ul>  
                              </div>
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




