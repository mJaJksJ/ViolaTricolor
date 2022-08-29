import Auth from "./components/Body/Auth/Auth"
import Home from "./components/Body/Home/Home"
import News from "./components/Body/News/News"

export const privateRoutes = [
    { path: '/', component: Home, exact: true },
    { path: '/news', component: News, exact: true },
]

export const publicRoutes = [
    { path: '/', component: Auth, exact: true },
]