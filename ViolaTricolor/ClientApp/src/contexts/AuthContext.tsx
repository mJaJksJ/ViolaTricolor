import React, { useContext } from "react";
import { createContext, useState } from "react"

interface IAuthInfoContent {
    isAuthorized: boolean;
    setIsAuthorized: (isAuthorized: boolean | ((isAuthorized: boolean) => boolean)) => void;
}

const defaultValue: IAuthInfoContent = {
    isAuthorized: false,
    setIsAuthorized: () => { }
};

interface IAuthContext {
    children?: JSX.Element | JSX.Element[];
}

const AuthContext = createContext<IAuthInfoContent>(defaultValue);

export const AuthContextProvider: React.FC<IAuthContext> = (props) => {
    const [isAuth, setIsAuth] = useState<boolean>(defaultValue.isAuthorized);
    const contract: IAuthInfoContent = {
        isAuthorized: isAuth,
        setIsAuthorized: (isAuth: boolean | ((isAuth: boolean) => boolean)) => { setIsAuth(isAuth) }
    }

    return (
        <AuthContext.Provider value={contract}>
            {props.children}
        </AuthContext.Provider>
    )
}

export const useAuthContext = () => {
    return useContext(AuthContext);
}