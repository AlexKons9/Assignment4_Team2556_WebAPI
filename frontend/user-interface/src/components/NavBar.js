import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from "react-router-dom";

function NavBar() {
    return (
        <div>
            <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark border-bottom box-shadow mb-3">
                <div className="container-fluid">
                    <a className="navbar-brand" >Assignment_4A_Team2556</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                        <ul className="navbar-nav flex-grow-1">
                            <li className="nav-item">
                                <Link className="nav-link text-light" to="Home" >Home</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link text-light" to="AdminUI" >Admin UI</Link>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link text-light">Candidate UI</a>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link text-light" to="Register" >Register</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

    );
}

export default NavBar;