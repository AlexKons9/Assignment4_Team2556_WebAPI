import axios from "axios";
import { useRef, useState, useEffect } from "react";
import useAuth from "../../hooks/useAuth";
import "bootstrap/dist/css/bootstrap.min.css";
import { Link, useNavigate, useLocation } from "react-router-dom";
import jwt_decode from "jwt-decode";
import './Login.css';


//
// Summary: Log in Form for users
const Login = () => {
  const { setAuth } = useAuth(); // sets the user credentials in the state of the auth context
  const navigate = useNavigate();  //used to redirect user to another page
  const location = useLocation();  //used to determine the location of a user within the app
  const userNameRef = useRef();  //used to create reference point for the username input
  const errRef = useRef(); //used to create reference point for an error

  const [userName, setUserName] = useState("");
  const [pwd, setPwd] = useState("");
  const [errMsg, setErrMsg] = useState("");


  useEffect(() => {
    userNameRef.current.focus(); //sets the focus, i.e. that the username is ready to receive input and it is the currently active element
  }, []);


  useEffect(() => {
    setErrMsg("");  //empties out the error message if the user reenter a new username and password
  }, [userName, pwd]);


  //
  //submits username and password to backend for authentication
  const handleSubmit = async (e) => {
    e.preventDefault(); //stops page from refreshing upon clicking submit button

    try {
      //send form data to backend for validation
      const response = await axios.post(
        "https://localhost:7015/api/authentication/login",
        JSON.stringify({ username: userName, password: pwd }),
        {
          headers: { "Content-Type": "application/json" },
          withCredentials: true,
        }
      );

      const accessToken = response?.data;  // if the http request is successful, it will return a response that is comprised of the accesstoken
      var decoded = jwt_decode(accessToken); //decode access token
      const roles = []; // create an empty array which will hold the user roles
      roles.push(
        decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]  // add user roles to array
      );

      setAuth({ userName, pwd, roles, accessToken });  //set global state of user credentials
      setUserName("");  //empties out username in form on successful submission
      setPwd(""); //empties out password in form on successful submission
      navigate("/", { replace: true });  //redirects the user to the home page
    } catch (err) {
      if (!err?.response) {
        setErrMsg("No Server Response");
      } else if (err.response?.status === 400) {
        setErrMsg("Missing Username or Password");
      } else if (err.response?.status === 401) {
        setErrMsg("Unauthorized");
      } else {
        setErrMsg("Login Failed");
      }
      errRef.current.focus();  //set focus on error
    }
  };

  return (
    <section className="container">
    {/* sets the error message when it is in focus */}
      <p
        ref={errRef}
        className={errMsg ? "errmsg" : "offscreen"}
        aria-live="assertive"
      >
        {errMsg}
      </p>

      {/* Sign in Form */}
      <h1>Sign In</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="username">Username:</label>
          <input
            className="form-control"
            type="text"
            id="username"
            ref={userNameRef}
            autoComplete="off"
            onChange={(e) => setUserName(e.target.value)}
            value={userName}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="password">Password:</label>
          <input
            className="form-control"
            type="password"
            id="password"
            onChange={(e) => setPwd(e.target.value)}
            value={pwd}
            required
          />
        </div>
        <button className="btn btn-primary">Sign In</button>
      </form>
      <p>
        Need an Account?
        <br />
        <span className="line">
          <Link to="/Register">Sign Up</Link>
        </span>
      </p>
    </section>
  );
};

export default Login;
