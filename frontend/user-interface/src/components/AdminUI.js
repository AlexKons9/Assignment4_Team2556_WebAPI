import { useNavigate, Link } from 'react-router-dom';
import useLogout from "../hooks/useLogout"
import QuestionsList from './QuestionsList';

function AdminUI() {
    const navigate = useNavigate();
    const logout = useLogout();

    const signOut = async() => {
        await logout();
        navigate('/linkpage');
    }

    return (
        <div>
            <h2>Logged in as Admin</h2>
            <QuestionsList />
            <button onClick={signOut}>Sign Out</button>
        </div>);
};

export default AdminUI;