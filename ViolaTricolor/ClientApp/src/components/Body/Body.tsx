import React from "react"
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { Route } from "react-router-dom";
import { Home } from "../Home";
import { Counter } from "../Counter";
import { FetchData } from "../FetchData";
import News from "./News/News";


const Body: React.FC = () => {
    return (
        <>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/news' component={News} />
        </>
    );
}

export default Body;