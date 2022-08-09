import React from "react"
import { Menubar } from 'primereact/menubar';
import { MenuItems } from "./MenuItems";

const Header: React.FC = () => {
    return (
        <Menubar model={MenuItems} />
    );
}

export default Header;