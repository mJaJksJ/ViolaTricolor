import React from "react"
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { INewsContract, NewsType } from "../../../../api";
import FriendsListUpdate from "./FriendsListUpdate";
import { Card } from 'primereact/card';
import { formatDateTime } from "../../../../formatters";

const NewsComponent: React.FC<INewsContract> = (props) => {
    const cardContent = (props: INewsContract): any => {
        switch (props.type) {
            case NewsType.FriendsListUpdate:
                return <FriendsListUpdate {...props.friend_list_update} />

            default:
                return <div></div>
        }
    }

    return (
        <>
            <Card title={props.type} subTitle={formatDateTime(props.datetime)} style={{ width: '50%' }}>
                {cardContent(props)}
            </Card>
            <br />
        </>
    );
}

export default NewsComponent;