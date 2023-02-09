import axios from '../api/axios';
import useAuth from './useAuth';
import jwt_decode from "jwt-decode";

//
// Summary: Returns a new user access token by sending the refresh token to the backend via a cookie
const useRefreshToken = () => {
    const { auth, setAuth } = useAuth(); 

    try {
        const refresh = async () => {     //returns a new access token if successful        
            const response = await axios.get('/api/token/refresh', {
                headers: { 'Content-Type': 'application/json' },
                withCredentials: true // allows cookies to be sent with request
            });
    
            setAuth(prev => {  // prev is the previous state of the auth
                var decoded = jwt_decode(response.data);  //decode new access token
                var userName = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']
                const roles = []; //create empty array which will hold the decoded user roles
                roles.push(decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']); //add decoded user roles to the array
                return {  //set the auth based on the new access token
                    ...prev,
                    roles: roles,
                    accessToken: response.data,
                    userName: userName,
                }
            });
            
            return response.data;
        }
        return refresh;
    } catch (error) {
        console.error(error);
    }   
    
};

export default useRefreshToken;