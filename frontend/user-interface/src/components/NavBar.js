﻿import 'bootstrap/dist/css/bootstrap.min.css';
import './NavBar.css';
import { Link } from "react-router-dom";
import useLogout from "../hooks/useLogout"
import useRefreshToken from '../hooks/useRefreshToken';
import useAuth from '../hooks/useAuth';

function NavBar() {

    /*    const { loginWithRedirect, isAuthenticated } = useAuth0();*/
    const logout = useLogout();
    const { auth } = useAuth();

    return (

        <div id='main-nav'>
            {/*<nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark border-bottom box-shadow mb-3">*/}
            {/*    <div className="container-fluid">*/}
            {/*        <a className="navbar-brand" >Assignment_4A_Team2556</a>*/}
            {/*        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"*/}
            {/*            aria-expanded="false" aria-label="Toggle navigation">*/}
            {/*            <span className="navbar-toggler-icon"></span>*/}
            {/*        </button>*/}
            {/*        <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">*/}
            {/*            <ul className="navbar-nav flex-grow-1">*/}
            {/*                <li className="nav-item">*/}
            {/*                    <Link className="nav-link text-light" to="Home" >Home</Link>*/}
            {/*                </li>*/}
            {/*                <li className="nav-item">*/}
            {/*                    <Link className="nav-link text-light" to="AdminUI" >Admin UI</Link>*/}
            {/*                </li>*/}
            {/*                <li className="nav-item">*/}
            {/*                    <a className="nav-link text-light">Candidate UI</a>*/}
            {/*                </li>*/}
            {/*                <li className="nav-item">*/}
            {/*                    <Link className="nav-link text-light" to="Register" >Register</Link>*/}
            {/*                </li>*/}
            {/*                <li className="nav-item">*/}
            {/*                    <Link className="nav-link text-light" to="Login" >Login</Link>*/}
            {/*                </li>*/}
            {/*            </ul>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</nav>*/}
            <nav className="navbar navbar-expand-md navbar-dark bg-dark">
                <div className="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                    <ul className="navbar-nav me-auto">
                        <li className="nav-item">
                            <Link className="nav-link text-light" to="Home" >Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link text-light" to="AdminUI" >Admin UI</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link text-light" to="CandidateUI" >Candidate UI</Link>
                        </li>
                    </ul>
                </div>
                <div className="mx-auto order-0">
                    <a className="navbar-brand mx-auto">Assignment_4A_Team2556</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".dual-collapse2">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                </div>
                {auth?.user ? (
                    <div className="navbar-collapse collapse w-100 order-3 dual-collapse2">
                        <ul className="navbar-nav ms-auto">
                            <li className="nav-item">
                                <p className="nav-link text-light">Welcome {auth.user} (role:{auth.roles})</p>
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