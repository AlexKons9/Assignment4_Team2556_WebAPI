// import logo from './logo.svg';
import { Routes, Route } from 'react-router-dom';
import RequireAuth from './components/RequireAuth';

//Public components
import './App.css';
import Home from './components/Home';
import Login from './components/Login'
import Layout from './components/Layout'
import Register from './components/Register'
import Unauthorized from './components/Unauthorized';

//Admin components
import CreateQuestionForm from './components/CreateQuestionForm';
import CreateOptionsForm from './components/CreateOptionsForm';
import AdminUI from './components/AdminUI';

//Candidate components


//TESTing components
import Users from './components/Users';


const ROLES = {
    'Admin': 'Admin',
    'Candidate': 'Candidate'
}

function App() {
    return (
        <Routes>
            <Route path="/" element={<Layout />}>

                {/* Public Routes */}
                <Route path="/" element={<Home />} />
                <Route path="Register" element={<Register />} />
                <Route path="Login" element={<Login />} />
                <Route path="unauthorized" element={<Unauthorized />} />


                {/* Admin Routes */}
                <Route element={<RequireAuth allowedRoles={[ROLES.Admin]}/>}>
                    <Route path="AdminUI" element={<AdminUI />} />
                    <Route path="AdminUI/CreateQuestionForm" element={<CreateQuestionForm />} />
                    <Route path="AdminUI/CreateOptionsForm" element={<CreateOptionsForm />} />
                    <Route path="Users" element={<Users />}/>
                    
                </Route>

                {/* Candidate Routes */}
                <Route element={<RequireAuth allowedRoles={[ROLES.Admin]}/>}>

                </Route>


                {/* Catch all */}


                {/* TESTING */}
                
            </Route>
        </Routes>
    );
}

export default App;
