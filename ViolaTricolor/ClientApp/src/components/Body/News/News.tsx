import React, { useEffect, useRef, useState } from "react"
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { NewsContract, ApiViolaTricolor } from "../../../api";

const News: React.FC = () => {
    const api = useRef(new ApiViolaTricolor());
    const [news, setNews] = useState<NewsContract[]>([]);

    useEffect(() => {
        api.current.getNews()
            .then(n => {
                console.log('nn')
                setNews(() => n.news ?? [])
            })
            .catch(e => {
                console.log('err')
                setNews(() => [new NewsContract(), new NewsContract(),])
            })
    }, [])

    return (
        <>
            {news.map(_ => <div key={new Date().getTime()}>q</div>)}
        </>
    );
}

export default News;