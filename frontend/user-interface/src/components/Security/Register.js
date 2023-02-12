import React, { useState } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import useAuth from "../../hooks/useAuth";

//
// Summary: sends data from the form to the backend for Candidate registration only
function Register() {
    const { register, handleSubmit } = useForm();  //react library that collects the inputs from the form and calls the submit function
    const { auth } = useAuth();
    
    //handles the submit trigger by passing in the candidate data and sends it to the backend for processing
    const onSubmit = async (data, e) => {
        try {
            data.roles = ["Candidate"];  //assigns the Candidate role to all users registering with this form
            await axios.post("https://localhost:7015/api/authentication", data);
            alert("User registered successfully!");
        } catch (error) {
            console.error(error);
        }
    };

    return (
            <div className="container">
                <div>
                    <div>
                        <form onSubmit={handleSubmit(onSubmit)} className="registrationForm">
                            <h2>Registration form</h2>
                            {auth?.roles == "Admin" ? <p></p> : <p>Sign up Today and get 100 credits FREE!</p>}
                            <div className="form-group mt-3">
                                <label className="pb-2" htmlFor="firstname">First Name</label>
                                <input className="form-control" {...register("firstname")} />
                            </div>
                            <div className="form-group mt-3">
                                <label className="pb-2" htmlFor="lastname">Last Name</label>
                                <input className="form-control" {...register("lastname")} />
                            </div>
                            <div className="form-group mt-3">
                                <label className="pb-2" htmlFor="username">User Name</label>
                                <input className="form-control" {...register("username")} />
                            </div>
                            <div className="form-group mt-3">
                                <label className="pb-2" htmlFor="password">Password</label>
                                <input className="form-control" {...register("password")} />
                            </div>
                            <div className="form-group mt-3">
                                <label className="pb-2" htmlFor="email">Email</label>
                                <input className=" form-control" {...register("email")} />
                            </div>
                            <div className="form-group mt-3">
                                <label className="pb-2" htmlFor="phonenumber">Phone Number</label>
                                <input className="form-control" {...register("phonenumber")} />
                            </div>
                            <div>
                            <input type="submit" className="btn btn-primary" />
                            {auth?.roles == "Admin" ? <Link id="backButton" className='btn btn-secondary align-self-start'  to={"../AdminUI/Candidates"}>Back to List</Link> : <Link></Link>}
                            </div>
                        </form>
                    </div>
                </div>
            </div>
    );
}

export default Register;
