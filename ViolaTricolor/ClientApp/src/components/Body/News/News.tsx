import React, { useEffect, useRef, useState } from "react"
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { NewsContract, ApiViolaTricolor } from "../../../api";
import NewsComponent from "./Contracts/NewsComponent";

const News: React.FC = () => {
    const api = useRef(new ApiViolaTricolor());
    const [news, setNews] = useState<NewsContract[]>([]);

    useEffect(() => {
        api.current.getNews()
            .then(n => {
                setNews((prev) => n.news ?? prev)
            })
            .catch(e => {
                console.log(e)
            })
    }, []);

    return (
        <>
            {news.map((n, i, arr) => {
                return <NewsComponent {...arr[arr.length - 1 - i]} key={i} />
            })}
        </>
    );
}

export default News;