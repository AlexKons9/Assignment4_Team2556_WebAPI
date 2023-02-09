import { useLocation, Navigate, Outlet } from "react-router-dom";
import useAuth from "../../hooks/useAuth";

//
// Summary: Evaluates whether a logged in user is able to access a protected route based on their roles
//          This component is used to implement Role-based Protected Routes in App.js.
const RequireAuth = ({ allowedRoles }) => {
    const { auth } = useAuth();
    const location = useLocation();

    return (   
        auth?.roles?.find(role => allowedRoles?.includes(role)) // if the user has the correct role, then return Outlet ( which is any child component which requires role authorization)
            ? <Outlet />  
            : auth?.accessToken   
                ? <Navigate to="/unauthorized" state={{ from: location }} replace /> // otherwise, if the user has an access token, display the authorized page
                : <Navigate to="/login" state={{ from: location }} replace /> // otherwise, send user to login page
    );
}

export default RequireAuth;