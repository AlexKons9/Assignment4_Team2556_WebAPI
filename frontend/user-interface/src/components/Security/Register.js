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
                            <div>
                                <label htmlFor="firstname">First Name</label>
                                <input {...register("firstname")} />
                            </div>
                            <div>
                                <label htmlFor="lastname">Last Name</label>
                                <input {...register("lastname")} />
                            </div>
                            <div>
                                <label htmlFor="username">User Name</label>
                                <input {...register("username")} />
                            </div>
                            <div>
                                <label htmlFor="password">Password</label>
                                <input {...register("password")} />
                            </div>
                            <div>
                                <label htmlFor="email">Email</label>
                                <input {...register("email")} />
                            </div>
                            <div>
                                <label htmlFor="phonenumber">Phone Number</label>
                                <input {...register("phonenumber")} />
                            </div>
                            <input type="submit" />
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Register;
