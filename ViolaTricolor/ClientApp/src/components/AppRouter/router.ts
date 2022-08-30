import Auth from "../Body/Auth/Auth"
import Home from "../Body/Home/Home"
import News from "../Body/News/News"

export const privateRoutes = [
    { path: '/', component: Home, exact: true, },
    { path: '/news', component: News, exact: true },
]

export const publicRoutes = [
    { path: '/', component: Auth, exact: true },
]