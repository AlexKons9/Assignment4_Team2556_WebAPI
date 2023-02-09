import { axiosPrivate } from "../api/axios";
import { useEffect } from "react";
import useRefreshToken from "./useRefreshToken";
import useAuth from "./useAuth";

//
// Summary: Custom hook (function) for sending http requests with authorization headers.  Also includes functionality for calling the 
//          refresh token in order to generate a new access token in case it has expired
const useAxiosPrivate = () => {
    const refresh = useRefreshToken();
    const { auth } = useAuth();

    useEffect(() => {
        //
        //Used for making the initial http request
        const requestIntercept = axiosPrivate.interceptors.request.use(
            config => {
                if (!config.headers['Authorization']) { //if authorization header does not exist (checks if it is the first attempt)
                    config.headers['Authorization'] = `Bearer ${auth?.accessToken}`; //set the initial request with the authorization header with the access token
                }
                return config;
            }, (error) => Promise.reject(error) //promise handles if there is an error with the above code
        );
        

        //
        //Handles the response.  If response is ok, then return response, if not, then generate new access token and try again.
        const responseIntercept = axiosPrivate.interceptors.response.use(
            response => response,  //if response is successful, then return the response
            async (error) => { //if response is an error (i.e the access token has expired)
                const prevRequest = error?.config;  //get previous request
                if (error?.response?.status === 401 && !prevRequest?.sent) {  //if error is to to 401(forbidden) and the previous request was not sent (we only want to retry once)
                    prevRequest.sent = true; // makes sure that the retry is only done once
                    const newAccessToken = await refresh();  // get new access token
                    prevRequest.headers['Authorization'] = `Bearer ${newAccessToken}`; //set authorization bearer token in the header
                    return axiosPrivate(prevRequest);
                }
                return Promise.reject(error);
            }
        );

        return () => { //clean up function for removing the interceptors
            axiosPrivate.interceptors.request.eject(requestIntercept);
            axiosPrivate.interceptors.response.eject(responseIntercept);
        }
    }, [auth, refresh])

    return axiosPrivate;
}

export default useAxiosPrivate;
