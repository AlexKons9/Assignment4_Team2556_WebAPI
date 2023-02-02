import axios from '../api/axios';
import useAuth from './useAuth';
import jwt_decode from "jwt-decode";

const useRefreshToken = () => {
    const { auth, setAuth } = useAuth();

    try {
        const refresh = async () => {
            const credentials = JSON.stringify(auth.accessToken);
            console.log(credentials);
            
            const response = await axios.get('/api/token/refresh', {
                headers: { 'Content-Type': 'application/json' },
                withCredentials: true
            });
    
            setAuth(prev => {
                console.log(response.data);
                var decoded = jwt_decode(response.data);
                const roles = [];
                roles.push(decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
                return {
                    ...prev,
                    roles: roles,
                    accessToken: response.data,
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