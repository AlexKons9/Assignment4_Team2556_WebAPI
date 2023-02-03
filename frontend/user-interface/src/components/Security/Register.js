import React, { useState } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';
import { useForm } from "react-hook-form";


function Register() {
    const { register, handleSubmit } = useForm();

    const onSubmit = async (data, e) => {
        try {
            data.roles = ["Candidate"];
            console.log(data);
            await axios.post("https://localhost:7015/api/authentication", data);
            alert("User registered successfully!");
        } catch (error) {
            console.error(error);
            alert("Error registering user");
        }
    };

    return (
        <>
            <div className="container">
                <div className="row">
                    <div className="col-md-4 col-md-offset-4">
                        <form onSubmit={handleSubmit(onSubmit)} className="registrationForm">
                            <h2>Registration form</h2>
                            <div className="form-group">
                                <label htmlFor="firstname">First Name</label>
                                <input className="form-control" {...register("firstname")} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="lastname">Last Name</label>
                                <input className="form-control" {...register("lastname")} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="username">User Name</label>
                                <input className="form-control" {...register("username")} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="password">Password</label>
                                <input className="form-control" {...register("password")} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="email">Email</label>
                                <input className="form-control" {...register("email")} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="phonenumber">Phone Number</label>
                                <input className="form-control" {...register("phonenumber")} />
                            </div>
                            <input type="submit" className="btn btn-primary" />
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Register;
