// import logo from './logo.svg';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CreateQuestionForm from './components/CreateQuestionForm';

import './App.css';
import NavBar from './components/NavBar';
import AdminUI from './components/AdminUI';

function App() {
    return (
        <BrowserRouter>
            <main>
                <NavBar/>
                <Routes>                
                    <Route path="/" element={<AdminUI/>} />
                    <Route path="CreateQuestionForm" element={<CreateQuestionForm/>} />
                </Routes>
            </main>
        </BrowserRouter>
    );
}

export default App;
