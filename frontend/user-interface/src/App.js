// import logo from './logo.svg';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CreateQuestionForm from './components/Question/CreateQuestionForm';
import EditQuestionForm from './components/Question/EditQuestionForm';
import DetailsQuestion from './components/Question/DetailsQuestion';
import CreateOptionsForm from './components/Option/CreateOptionsForm';
import EditOptionsForm from './components/Option/EditOptionsForm';
import GenerateExam from './components/CandidateExams/GenerateExam';
import './App.css';
import NavBar from './components/NavBar';
import Home from './components/Home';
import AdminUI from './components/AdminUI';
import CandidateUI from './components/CandidateUI';
import CandidateExamResults from './components/CandidateExams/CandidateExamResults';

function App() {
    return (
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
