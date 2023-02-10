import { useContext, useDebugValue } from "react";
import AuthContext from "../context/AuthProvider";

//
// Summary: Custom hook (function) which fetches the user credentials from the global auth context
//          Eliminates the need to import useContext and set useContext to auth context in every component that requires the user credentials
const useAuth = () => {
    const { auth } = useContext(AuthContext);
    useDebugValue(auth, auth => auth?.userName ? "Logged In" : "Logged Out");
    return useContext(AuthContext);
}

export default useAuth;