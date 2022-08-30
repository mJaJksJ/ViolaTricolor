import React from 'react'
import { useAuthContext } from '../../../contexts/AuthContext';
import { AuthService } from '../../../services/auth.service';

export interface ILogOut {
    children: string | undefined;
    className: string;
}

const LogOut: React.FC<ILogOut> = (props) => {
    const authContext = useAuthContext();
    const authService = new AuthService();

    return <div className={props.className} onClick={() => { authService.logOut(authContext) }}>{props.children}</div>
}

export default LogOut;