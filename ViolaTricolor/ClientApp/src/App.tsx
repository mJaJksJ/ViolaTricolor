import React, { useEffect, useRef } from "react"
import Header from "./components/Header/Header";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { BrowserRouter } from "react-router-dom";
import Body from "./components/Body/Body";
import { AuthContextProvider, useAuthContext } from "./contexts/AuthContext";
import { ApiViolaTricolor } from "./api";
import Auth from "./components/Body/Auth/Auth";

const App: React.FC = () => {
  const api = useRef(new ApiViolaTricolor());
  const authInfo = useRef(useAuthContext());

  useEffect(() => {
    api.current.getAuthInfo().then(i => {
      authInfo.current.setContract(i);
    })
  }, []);

  return (
    <BrowserRouter>
      <AuthContextProvider>
        {
          authInfo.current.contract.is_authorized
            ? <>
              <Header />
              <Body />
            </>
            : <>
              <Auth />
            </>
        }

      </AuthContextProvider>
    </BrowserRouter >
  );
}

export default App;