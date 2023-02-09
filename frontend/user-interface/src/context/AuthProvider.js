import { createContext, useState } from "react";

//
// Summary: Sets global state of the user credentials for authorization purposes.
//          This is imported in the index.js, so that the entire app has access to the user credentials.

const AuthContext = createContext({});
export const AuthProvider = ({ children}) => {
    const [auth, setAuth] = useState({});  //set state of the user for authorization

    //passes the state of the authcontext provider, and declares the children elements which are to be nested under the auth provider
    return (
        <AuthContext.Provider value={{ auth, setAuth }}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext;