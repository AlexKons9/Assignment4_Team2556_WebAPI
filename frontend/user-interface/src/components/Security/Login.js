import axios from "axios";
import { useRef, useState, useEffect } from "react";
import useAuth from "../../hooks/useAuth";
import "bootstrap/dist/css/bootstrap.min.css";
import { Link, useNavigate, useLocation } from "react-router-dom";
import jwt_decode from "jwt-decode";
import './Login.css';

const Login = () => {
  const { setAuth } = useAuth();

  const navigate = useNavigate();
  const location = useLocation();
  const from = location.state?.from?.pathname || "/";

  const userNameRef = useRef();
  const errRef = useRef();

  const [userName, setUserName] = useState("");
  const [pwd, setPwd] = useState("");
  const [errMsg, setErrMsg] = useState("");

  useEffect(() => {
    userNameRef.current.focus();
  }, []);

  useEffect(() => {
    setErrMsg("");
  }, [userName, pwd]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post(
        "https://localhost:7015/api/authentication/login",
        JSON.stringify({ username: userName, password: pwd }),
        {
          headers: { "Content-Type": "application/json" },
          withCredentials: true,
        }
      );
      console.log(JSON.stringify(response?.data));
      const accessToken = response?.data;
      // const refreshToken = response?.data?.refreshToken;
      var decoded = jwt_decode(accessToken);
      const roles = [];
      roles.push(
        decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
      );
      console.log(roles);

      setAuth({ userName, pwd, roles, accessToken }); //, refreshToken
      setUserName("");
      setPwd("");
      navigate(from, { replace: true });
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
      errRef.current.focus();
    }
  };

  return (
    <section className="container">
      <p
        ref={errRef}
        className={errMsg ? "errmsg" : "offscreen"}
        aria-live="assertive"
      >
        {errMsg}
      </p>
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
          {/*put router link here*/}
          <Link to="/Register">Sign Up</Link>
        </span>
      </p>
    </section>
  );
};

export default Login;
