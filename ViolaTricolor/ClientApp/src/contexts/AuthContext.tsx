import React, { useContext } from "react";
import { createContext, useState } from "react"
import { AuthInfoContract } from "../api"

interface IAuthInfoContent {
    contract: AuthInfoContract;
    setContract: (authInfoContract: AuthInfoContract) => void;
}

const defaultValue: IAuthInfoContent = {
    contract: { is_authorized: false, } as AuthInfoContract,
    setContract: () => { }
};

interface IAuthContext {
    children?: JSX.Element | JSX.Element[];
}

const AuthContext = createContext<IAuthInfoContent>(defaultValue);

export const AuthContextProvider: React.FC<IAuthContext> = (props) => {
    const [authInfo, setAuthInfo] = useState<AuthInfoContract>(defaultValue.contract);
    const contract: IAuthInfoContent = {
        contract: authInfo,
        setContract: (authInfoContract: AuthInfoContract) => { setAuthInfo(authInfoContract) }
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




/*export const AuthContext = createContext<[AuthInfoContract | undefined, () => void]>([{
    is_authorized: false,
} as AuthInfoContract, Dispatch<React.SetStateAction<AuthInfoContract | undefined>>])

export const AuthContextProvider = (children: React.FC) => {
    const authInfoState = useState<AuthInfoContract>();

    return (
        <AuthContext.Provider value={authInfoState}>
            {children}
        </AuthContext.Provider>
    )
}*/