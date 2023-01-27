// import logo from './logo.svg';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CreateQuestionForm from './components/CreateQuestionForm';

import './App.css';
import NavBar from './components/NavBar';
import Home from './components/Home';
import AdminUI from './components/AdminUI';


function App() {
    return (
        <BrowserRouter>
            <main>
                <NavBar/>
                <Routes>
                    <Route path="/" element={<Home/> } />
                    <Route path="Home" element={<Home/> } />
                    <Route exact path="AdminUI" element={<AdminUI/>} />
                    <Route exact path="AdminUI/CreateQuestionForm" element={<CreateQuestionForm/>} />
                </Routes>
            </main>
        </BrowserRouter>
    );
}

export default App;
