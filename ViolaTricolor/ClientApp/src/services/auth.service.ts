import { ApiViolaTricolor, AuthResponse } from "../api";
import { LOCAL_STORAGE_ROLES, LOCAL_STORAGE_TOKEN, LOCAL_STORAGE_TOKEN_TYPE, LOCAL_STORAGE_USERNAME, LOCAL_STORAGE_VALIDITY_PERIOD, LOCAL_STORAGE_VK_USER_ID, LOCAL_STORAGE_VT_USER_ID } from "../constsAndDicts/localStorageConsts";
import { IAuthInfoContent } from "../contexts/AuthContext";

export class AuthService {
    api = new ApiViolaTricolor();

    public auth(response: AuthResponse, authContext: IAuthInfoContent) {
        this.SetLocalSotrageAuthItems(response);
        authContext.setIsAuthorized(true);
    }

    public logOut(authContext: IAuthInfoContent) {
        this.api.logOut()
            .then(() => {
                authContext.setIsAuthorized(false);
                this.RemoveLocalSotrageAuthItems();
            })
    }

    private SetLocalSotrageAuthItems(items: AuthResponse) {
        localStorage.setItem(LOCAL_STORAGE_ROLES, items.roles?.toString());
        localStorage.setItem(LOCAL_STORAGE_TOKEN, items.token);
        localStorage.setItem(LOCAL_STORAGE_TOKEN_TYPE, items.token_type);
        localStorage.setItem(LOCAL_STORAGE_USERNAME, items.username);
        localStorage.setItem(LOCAL_STORAGE_VALIDITY_PERIOD, items.validity_period.toISOString());
        localStorage.setItem(LOCAL_STORAGE_VK_USER_ID, items.vk_user_id);
        localStorage.setItem(LOCAL_STORAGE_VT_USER_ID, items.vt_user_id);
    }

    private RemoveLocalSotrageAuthItems() {
        localStorage.removeItem(LOCAL_STORAGE_ROLES);
        localStorage.removeItem(LOCAL_STORAGE_TOKEN);
        localStorage.removeItem(LOCAL_STORAGE_TOKEN_TYPE);
        localStorage.removeItem(LOCAL_STORAGE_USERNAME);
        localStorage.removeItem(LOCAL_STORAGE_VALIDITY_PERIOD);
        localStorage.removeItem(LOCAL_STORAGE_VK_USER_ID);
        localStorage.removeItem(LOCAL_STORAGE_VT_USER_ID);
    }
}
