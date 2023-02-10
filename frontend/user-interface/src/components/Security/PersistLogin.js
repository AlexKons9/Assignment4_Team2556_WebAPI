import { Outlet } from "react-router-dom";
import { useState, useEffect } from "react";
import useRefreshToken from '../../hooks/useRefreshToken';
import useAuth from '../../hooks/useAuth';

//
// Summary: Allows a user to remain logged in after refreshing or changing pages.
const PersistLogin = () => {
    const [isLoading, setIsLoading] = useState(true);
    const refresh = useRefreshToken();
    const { auth } = useAuth();

    useEffect(() => {
        //let isMounted = true;

        const verifyRefreshToken = async () => {
            try {
                await refresh();
            }
            catch (err) {
                console.error(err);
            }
            finally {
                //isMounted && setIsLoading(false);
                setIsLoading(false);
            }
        }

        //this ternary ensures that the verifyRefreshToken will only be called in case the user does not have an access token
        !auth?.accessToken ? verifyRefreshToken() : setIsLoading(false);  
    }, [])

    useEffect(() => {
        console.log(`isLoading: ${isLoading}`)
        console.log(`accessToken: ${JSON.stringify(auth?.accessToken)}`)
    }, [isLoading])

    return (
        <>
            {/* Outlet represents all of the child components that exist under Persist Login */}
            {isLoading
                    ? <p>Loading...</p>
                    : <Outlet /> 
            }
        </>
    )
}

export default PersistLogin