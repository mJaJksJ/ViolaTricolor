import React, { useEffect } from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import { LOCAL_STORAGE_TOKEN } from "../../constsAndDicts/localStorageConsts";
import { useAuthContext } from "../../contexts/AuthContext";
import { privateRoutes, publicRoutes } from "../../router";
import Header from "../Header/Header";

const AppRouter: React.FC = () => {
    const authContext = useAuthContext();

    useEffect(() => {
        const isAuth = !!localStorage.getItem(LOCAL_STORAGE_TOKEN);
        authContext.setIsAuthorized((prev: boolean) => isAuth);
        // eslint-disable-next-line 
    }, []);

    return (
        authContext.isAuthorized
            ? <>
                <Header />
                <Switch>
                    {privateRoutes.map(route =>
                        <Route
                            component={route.component}
                            path={route.path}
                            exact={route.exact}
                            key={route.path}
                        />
                    )}
                    <Redirect to='/' />
                </Switch>
            </>

            : <>
                <Switch>
                    {publicRoutes.map(route =>
                        <Route
                            component={route.component}
                            path={route.path}
                            exact={route.exact}
                            key={route.path}
                        />
                    )}
                    <Redirect to='/' />
                </Switch>
            </>
    );
};

export default AppRouter;