import React from "react"
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { Route } from "react-router-dom";
import News from "./News/News";
import Home from "./Home/Home";

const Body: React.FC = () => {
    return (
        <>
            <Route exact path='/' component={Home} />
            <Route path='/news' component={News} />
        </>
    );
}

export default Body;