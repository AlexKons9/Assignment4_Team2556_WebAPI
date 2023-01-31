import axios from '../api/axios';
import useAuth from './useAuth';
import jwt_decode from "jwt-decode";

const useRefreshToken = () => {
    const { auth, setAuth } = useAuth();

    const refresh = async () => {
        //var accessToken = auth.accessToken
        //console.log(auth.accessToken);
        //console.log(auth.refreshToken);
        const credentials = JSON.stringify(auth.accessToken)
        console.log(credentials);
        
        const response = await axios.post('/api/token/refresh', credentials, {
            headers: { 'Content-Type': 'application/json' },
            withCredentials: true
        });
        setAuth(prev => {
            console.log(JSON.stringify(prev));
            console.log(response.data.accessToken);
            var decoded = jwt_decode(response.data.accessToken);
            const roles = []
            roles.push(decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
            return {
                ...prev,
                roles: roles,
                accessToken: response.data.accessToken,
                // refreshToken: response.data.refreshToken
            }
        });
        return response.data;
    }
    return refresh;
};

export default useRefreshToken;