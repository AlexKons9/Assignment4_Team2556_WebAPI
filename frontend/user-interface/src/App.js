// import logo from './logo.svg';
import { Routes, Route } from 'react-router-dom';
import RequireAuth from './components/RequireAuth';

//Public components
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CreateQuestionForm from './components/Question/CreateQuestionForm';
import EditQuestionForm from './components/Question/EditQuestionForm';
import DetailsQuestion from './components/Question/DetailsQuestion';
import CreateOptionsForm from './components/Option/CreateOptionsForm';
import EditOptionsForm from './components/Option/EditOptionsForm';
import GenerateExam from './components/CandidateExams/GenerateExam';
import './App.css';
import Home from './components/Home';
import Login from './components/Login'
import Layout from './components/Layout'
import Register from './components/Register'
import Unauthorized from './components/Unauthorized';
import PersistLogin from './components/PersistLogin';

//Admin components
import CreateQuestionForm from './components/CreateQuestionForm';
import CreateOptionsForm from './components/CreateOptionsForm';
import AdminUI from './components/AdminUI';

//Candidate components
import CandidateUI from './components/CandidateUI';
import CandidateExamResults from './components/CandidateExams/CandidateExamResults';


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
                <Route path="Register" element={<Register />} />


                {/* PROTECTED Routes */}
                <Route element={<PersistLogin />}>
                    <Route path="/" element={<Home />} />
                    <Route path="Login" element={<Login />} />
                    <Route path="unauthorized" element={<Unauthorized />} />

                    {/* Admin Routes */}
                    <Route element={<RequireAuth allowedRoles={[ROLES.Admin]} />}>
                        <Route path="AdminUI" element={<AdminUI />} />
                        <Route path="AdminUI/CreateQuestionForm" element={<CreateQuestionForm />} />
                        <Route path="AdminUI/CreateOptionsForm" element={<CreateOptionsForm />} />
                        

                    </Route>

                    {/* Candidate Routes */}
                    <Route element={<RequireAuth allowedRoles={[ROLES.Candidate]} />}>
                        <Route path="Users" element={<Users />} />
                    </Route>
                    
                </Route>


                {/* Catch all */}


                {/* TESTING */}

            </Route>
        </Routes>
        <BrowserRouter>
            <main>
                <NavBar/>
                <Routes>
                    <Route path="/" element={<Home/> } />
                    <Route path="Home" element={<Home/> } />
                    <Route exact path="CandidateUI" element={<CandidateUI />} />
                    <Route exact path="CandidateUI/GenerateExam" element={<GenerateExam />} />
                    <Route exact path="CandidateUI/CandidateExamResults" element={<CandidateExamResults />} />
                    <Route exact path="AdminUI" element={<AdminUI/>} />
                    <Route exact path="AdminUI/CreateQuestionForm" element={<CreateQuestionForm/>} />
                    <Route exact path="AdminUI/EditQuestionForm" element={<EditQuestionForm/>} />
                    <Route exact path="AdminUI/DetailsQuestion" element={<DetailsQuestion/>} />
                    <Route exact path="AdminUI/CreateOptionsForm" element={<CreateOptionsForm/>} />
                    <Route exact path="AdminUI/EditOptionsForm" element={<EditOptionsForm/>} />
                </Routes>
            </main>
        </BrowserRouter>
    );
}

export default App;
