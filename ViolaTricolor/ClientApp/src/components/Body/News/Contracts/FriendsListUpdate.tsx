import React from "react"
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { IFriendsListUpdateNewContract } from "../../../../api";

const FriendsListUpdate: React.FC<IFriendsListUpdateNewContract> = (props) => {
    return (
        <>
            {props.who?.name} {props.who?.surname} {props.relation_status} {props.whom?.name} {props.whom?.surname}
        </>
    );
}

export default FriendsListUpdate;