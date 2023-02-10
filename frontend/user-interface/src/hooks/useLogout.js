import axios from "axios";
import useAuth from "./useAuth";

//
// Summary: custom hook (function) for logging out the user.  Used in the navbar
const useLogout = () => {
    const { setAuth } = useAuth();

    const logout = async () => {
        setAuth({});  //removes the access token from the user info being stored in the state of the app

        try {
            const response = await axios.get('https://localhost:7015/api/authentication/logout', {
                withCredentials: true //necessary for sending cookies
            });
        } catch (err) {
            console.error(err);
        }
    }

    return logout;
}

export default useLogout;