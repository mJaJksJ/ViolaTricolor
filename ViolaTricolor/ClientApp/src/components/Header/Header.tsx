import React from "react"
import { Menubar } from 'primereact/menubar';
import { MenuItems } from "./MenuItems";
import { Button } from 'primereact/button';

const Header: React.FC = () => {
    const start =
        <>
            <Button icon='pi pi-fw pi-play' style={{ 'position': 'fixed', 'left': '10px' }} />
            <Button icon='' style={{ 'opacity': '0' }} disabled />
        </>


    return (
        <Menubar model={MenuItems} style={{ justifyContent: 'flex-end', position: 'sticky', 'top': '0', width: '100%' }} start={start} />
    );
}

export default Header;