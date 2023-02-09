// import logo from './logo.svg';
//import { Routes, Route } from 'react-router-dom';
import RequireAuth from './components/Security/RequireAuth';

//Public components
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CreateQuestionForm from './components/Question/CreateQuestionForm';
import EditQuestionForm from './components/Question/EditQuestionForm';
import DetailsQuestion from './components/Question/DetailsQuestion';
import CreateOptionsForm from './components/Option/CreateOptionsForm';
import EditOptionsForm from './components/Option/EditOptionsForm';
import GenerateExam from './components/CandidateExams/GenerateExam';
import MyCertificatesList from './components/CandidateCertificates/MyCertificatesList';
import CertificateDetails from './components/CandidateCertificates/CertificateDetails';
import EShopList from './components/EShop/EShopList';
import VouchersList from './components/Exams/VouchersList';
import SchedulerMenu from "./components/Exams/SchedulerMenu";
import UpcomingExams from "./components/Exams/UpcomingExams";
import './App.css';
import Home from './components/Home';
import Login from './components/Security/Login'
import Layout from './components/Layout'
import Register from './components/Security/Register'
import Unauthorized from './components/Security/Unauthorized';
import PersistLogin from './components/Security/PersistLogin';

//Admin components
//import CreateQuestionForm from './components/CreateQuestionForm';
//import CreateOptionsForm from './components/CreateOptionsForm';
import AdminUI from './components/AdminUI';

//Candidate components
import CandidateUI from './components/CandidateUI';
import CandidateExamResults from './components/CandidateExams/CandidateExamResults';


//TESTing components
import Users from './components/Security/Users';


const ROLES = {
    'Admin': 'Admin',
    'Candidate': 'Candidate',
    'Marker': 'Marker',
    'QualityControl': 'QualityControl'
}

function App() {
    return (
        <Routes>
            <Route path="/" element={<Layout />}>

                {/* Public Routes */}
                <Route path="Register" element={<Register />} />
                <Route path="Home" element={<Home />} />

                {/* PROTECTED Routes */}
                <Route element={<PersistLogin />}>
                    <Route path="/" element={<Home />} />
                    <Route path="Login" element={<Login />} />
                    <Route path="unauthorized" element={<Unauthorized />} />

                    {/* ONLY Admin Routes */}
                    <Route element={<RequireAuth allowedRoles={[ROLES.Admin]} />}>
                        <Route exact path="AdminUI" element={<AdminUI />} />
                        <Route exact path="AdminUI/CreateQuestionForm" element={<CreateQuestionForm />} />
                        <Route exact path="AdminUI/EditQuestionForm" element={<EditQuestionForm />} />
                        <Route exact path="AdminUI/DetailsQuestion" element={<DetailsQuestion />} />
                        <Route exact path="AdminUI/CreateOptionsForm" element={<CreateOptionsForm />} />
                        <Route exact path="AdminUI/EditOptionsForm" element={<EditOptionsForm />} />
                    </Route>

                    {/* Marker Routes */}
                    <Route element={<RequireAuth allowedRoles={[ROLES.Marker, ROLES.Admin]} />}>

                    </Route>

                    {/* QualityControl Routes */}
                    <Route element={<RequireAuth allowedRoles={[ROLES.QualityControl, ROLES.Admin]} />}>

                    </Route>         

                    {/* Candidate Routes */}
                    <Route element={<RequireAuth allowedRoles={[ROLES.Candidate]} />}>
                        <Route exact path="CandidateUI" element={<CandidateUI />} />
                        <Route exact path="CandidateUI/GenerateExam" element={<GenerateExam />} />
                        <Route exact path="CandidateUI/CandidateExamResults" element={<CandidateExamResults />}/>
                        <Route exact path="MyCertificatesList" element={<MyCertificatesList/>}/>
                        <Route exact path="MyCertificatesList/CertificateDetails" element={<CertificateDetails/>}/>
                        <Route exact path="EShopList" element={<EShopList/>}/>
                        <Route exact path="Exams/VouchersList" element={<VouchersList/>}/>
                        <Route exact path="Exams/SchedulerMenu" element={<SchedulerMenu/>}/>
                        <Route exact path="Exams/UpcomingExams" element={<UpcomingExams/>}/>

                    </Route>           

                </Route>


                {/* Catch all */}


                {/* TESTING */}
                <Route path="/" element={<Home />} />



            </Route>
        </Routes>




    );
}

export default App;
