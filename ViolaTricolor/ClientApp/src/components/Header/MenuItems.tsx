import { MenuItem } from "primereact/menuitem";
import { Link } from "react-router-dom";
export const MenuItems: MenuItem[] = [
    {
        label: 'Лента',
        icon: 'pi pi-fw pi-images',
        template: (item, options) => {
            return (
                <Link className={options.className} to={'/news'}>{item.label}</Link>
            )
        }
    },
    {
        label: 'Аккаунт',
        icon: 'pi pi-fw pi-user',
        items: [
            {
                label: 'Страница',
                icon: 'pi pi-fw pi-home',
                template: (item, options) => {
                    return (
                        <Link className={options.className} to={'/'}>{item.label}</Link>
                    )
                }
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