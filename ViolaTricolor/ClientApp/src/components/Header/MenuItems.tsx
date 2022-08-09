import { NavLink } from "react-router-dom";

interface IMenuItem {
    label: string;
    icon?: string;
    items?: Array<IMenuItem | IMenuItemSeparator>;
    command?: () => void;
    template?: any;
}

interface IMenuItemSeparator {
    separator: boolean;
}

export const MenuItems: IMenuItem[] = [
    {
        label: 'Лента',
        icon: 'pi pi-fw pi-home',
        command: () => { window.location.pathname = "/counter"; }
    }
];