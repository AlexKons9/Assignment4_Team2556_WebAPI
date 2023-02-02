import RequireAuth from './components/RequireAuth';

//Public components
import './App.css';
import Home from './components/Home';
import Login from './components/Security/Login'
import Layout from './components/Layout'
import Register from './components/Register'
import Unauthorized from './components/Security/Unauthorized';
import PersistLogin from './components/Security/PersistLogin';

import AdminUI from './components/AdminUI';

//Candidate components


//TESTing components
import Users from './components/Security/Users';


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
    );
}

export default App;
