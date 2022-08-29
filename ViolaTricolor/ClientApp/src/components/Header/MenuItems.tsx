import { MenuItem } from "primereact/menuitem";

export const MenuItems: MenuItem[] = [
    {
        label: 'Лента',
        icon: 'pi pi-fw pi-images',
        command: () => { window.location.href = "/news"; }
    },
    {
        label: 'Аккаунт',
        icon: 'pi pi-fw pi-user',
        items: [
            {
                label: 'Страница',
                icon: 'pi pi-fw pi-home',
                command: () => { window.location.href = "/"; }
            },
            {
                separator: true
            },
            {
                label: 'Выход',
                icon: 'pi pi-fw pi-sign-out',
            },
        ]
    }
];