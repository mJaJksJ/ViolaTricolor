//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

export class ApiViolaTricolor {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * Вход в учетную запись
     * @param body (optional) Запрос авторизации
     * @return Success
     */
    authorize(body: AuthRequest | undefined): Promise<AuthResponse> {
        let url_ = this.baseUrl + "/api/authorize/login";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json-patch+json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAuthorize(_response);
        });
    }

    protected processAuthorize(response: Response): Promise<AuthResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = AuthResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<AuthResponse>(null as any);
    }

    /**
     * Выход из учетной записи
     * @return Success
     */
    logOut(): Promise<OkResult> {
        let url_ = this.baseUrl + "/api/authorize/logout";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "POST",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processLogOut(_response);
        });
    }

    protected processLogOut(response: Response): Promise<OkResult> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = OkResult.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<OkResult>(null as any);
    }

    /**
     * Изменить пароль
     * @param body (optional) Контракт изменения пароля
     * @return Success
     */
    changePassword(body: ChangePasswordContract | undefined): Promise<OkResult> {
        let url_ = this.baseUrl + "/api/authorize/change-password";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json-patch+json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processChangePassword(_response);
        });
    }

    protected processChangePassword(response: Response): Promise<OkResult> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = OkResult.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<OkResult>(null as any);
    }

    /**
     * Получить авторизационную информацию
     * @return Success
     */
    getAuthInfo(): Promise<AuthInfoContract> {
        let url_ = this.baseUrl + "/api/authorize/info";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAuthInfo(_response);
        });
    }

    protected processGetAuthInfo(response: Response): Promise<AuthInfoContract> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = AuthInfoContract.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<AuthInfoContract>(null as any);
    }

    /**
     * Получить новости
     * @return Success
     */
    getNews(): Promise<NewsListContract> {
        let url_ = this.baseUrl + "/api/news";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetNews(_response);
        });
    }

    protected processGetNews(response: Response): Promise<NewsListContract> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = NewsListContract.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<NewsListContract>(null as any);
    }
}

/** Авторизационная информация */
export class AuthInfoContract implements IAuthInfoContract {
    /** Авторизирован ли пользователь */
    is_authorized?: boolean;

    constructor(data?: IAuthInfoContract) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.is_authorized = _data["is_authorized"];
        }
    }

    static fromJS(data: any): AuthInfoContract {
        data = typeof data === 'object' ? data : {};
        let result = new AuthInfoContract();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["is_authorized"] = this.is_authorized;
        return data;
    }
}

/** Авторизационная информация */
export interface IAuthInfoContract {
    /** Авторизирован ли пользователь */
    is_authorized?: boolean;
}

/** Запрос авторизации */
export class AuthRequest implements IAuthRequest {
    /** Логин */
    login!: string;
    /** Пароль */
    password!: string;

    constructor(data?: IAuthRequest) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.login = _data["login"];
            this.password = _data["password"];
        }
    }

    static fromJS(data: any): AuthRequest {
        data = typeof data === 'object' ? data : {};
        let result = new AuthRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["login"] = this.login;
        data["password"] = this.password;
        return data;
    }
}

/** Запрос авторизации */
export interface IAuthRequest {
    /** Логин */
    login: string;
    /** Пароль */
    password: string;
}

/** Ответ авторизации */
export class AuthResponse implements IAuthResponse {
    /** Id VT пользователя */
    vt_user_id?: string | undefined;
    /** Id Vk пользователя */
    vk_user_id?: string | undefined;
    /** Никнейм VT пользователя */
    username?: string | undefined;
    /** Токен */
    token?: string | undefined;
    /** Тип токена */
    token_type?: string | undefined;
    /** Срок действия токена */
    validity_period?: Date;
    /** Роль */
    roles?: string[] | undefined;

    constructor(data?: IAuthResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.vt_user_id = _data["vt_user_id"];
            this.vk_user_id = _data["vk_user_id"];
            this.username = _data["username"];
            this.token = _data["token"];
            this.token_type = _data["token_type"];
            this.validity_period = _data["validity_period"] ? new Date(_data["validity_period"].toString()) : <any>undefined;
            if (Array.isArray(_data["roles"])) {
                this.roles = [] as any;
                for (let item of _data["roles"])
                    this.roles!.push(item);
            }
        }
    }

    static fromJS(data: any): AuthResponse {
        data = typeof data === 'object' ? data : {};
        let result = new AuthResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vt_user_id"] = this.vt_user_id;
        data["vk_user_id"] = this.vk_user_id;
        data["username"] = this.username;
        data["token"] = this.token;
        data["token_type"] = this.token_type;
        data["validity_period"] = this.validity_period ? this.validity_period.toISOString() : <any>undefined;
        if (Array.isArray(this.roles)) {
            data["roles"] = [];
            for (let item of this.roles)
                data["roles"].push(item);
        }
        return data;
    }
}

/** Ответ авторизации */
export interface IAuthResponse {
    /** Id VT пользователя */
    vt_user_id?: string | undefined;
    /** Id Vk пользователя */
    vk_user_id?: string | undefined;
    /** Никнейм VT пользователя */
    username?: string | undefined;
    /** Токен */
    token?: string | undefined;
    /** Тип токена */
    token_type?: string | undefined;
    /** Срок действия токена */
    validity_period?: Date;
    /** Роль */
    roles?: string[] | undefined;
}

/** Контракт изменения пароля */
export class ChangePasswordContract implements IChangePasswordContract {
    /** Логин */
    login?: string | undefined;
    /** Старый пароль */
    password?: string | undefined;
    /** Новый пароль */
    new_password?: string | undefined;

    constructor(data?: IChangePasswordContract) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.login = _data["login"];
            this.password = _data["password"];
            this.new_password = _data["new_password"];
        }
    }

    static fromJS(data: any): ChangePasswordContract {
        data = typeof data === 'object' ? data : {};
        let result = new ChangePasswordContract();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["login"] = this.login;
        data["password"] = this.password;
        data["new_password"] = this.new_password;
        return data;
    }
}

/** Контракт изменения пароля */
export interface IChangePasswordContract {
    /** Логин */
    login?: string | undefined;
    /** Старый пароль */
    password?: string | undefined;
    /** Новый пароль */
    new_password?: string | undefined;
}

/** Новость обновления списков друзей */
export class FriendsListUpdateNewContract implements IFriendsListUpdateNewContract {
    who?: VkUserContract;
    whom?: VkUserContract;
    relation_status?: VkUserRelationsStatus;

    constructor(data?: IFriendsListUpdateNewContract) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.who = _data["who"] ? VkUserContract.fromJS(_data["who"]) : <any>undefined;
            this.whom = _data["whom"] ? VkUserContract.fromJS(_data["whom"]) : <any>undefined;
            this.relation_status = _data["relation_status"];
        }
    }

    static fromJS(data: any): FriendsListUpdateNewContract {
        data = typeof data === 'object' ? data : {};
        let result = new FriendsListUpdateNewContract();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["who"] = this.who ? this.who.toJSON() : <any>undefined;
        data["whom"] = this.whom ? this.whom.toJSON() : <any>undefined;
        data["relation_status"] = this.relation_status;
        return data;
    }
}

/** Новость обновления списков друзей */
export interface IFriendsListUpdateNewContract {
    who?: VkUserContract;
    whom?: VkUserContract;
    relation_status?: VkUserRelationsStatus;
}

/** Контракт новости */
export class NewsContract implements INewsContract {
    type?: NewsType;
    friend_list_update?: FriendsListUpdateNewContract;
    /** Дата и время фиксации */
    datetime?: Date;

    constructor(data?: INewsContract) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.type = _data["type"];
            this.friend_list_update = _data["friend_list_update"] ? FriendsListUpdateNewContract.fromJS(_data["friend_list_update"]) : <any>undefined;
            this.datetime = _data["datetime"] ? new Date(_data["datetime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): NewsContract {
        data = typeof data === 'object' ? data : {};
        let result = new NewsContract();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["friend_list_update"] = this.friend_list_update ? this.friend_list_update.toJSON() : <any>undefined;
        data["datetime"] = this.datetime ? this.datetime.toISOString() : <any>undefined;
        return data;
    }
}

/** Контракт новости */
export interface INewsContract {
    type?: NewsType;
    friend_list_update?: FriendsListUpdateNewContract;
    /** Дата и время фиксации */
    datetime?: Date;
}

/** Список контрактов новостей */
export class NewsListContract implements INewsListContract {
    /** Список контрактов новостей */
    news?: NewsContract[] | undefined;

    constructor(data?: INewsListContract) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["news"])) {
                this.news = [] as any;
                for (let item of _data["news"])
                    this.news!.push(NewsContract.fromJS(item));
            }
        }
    }

    static fromJS(data: any): NewsListContract {
        data = typeof data === 'object' ? data : {};
        let result = new NewsListContract();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.news)) {
            data["news"] = [];
            for (let item of this.news)
                data["news"].push(item.toJSON());
        }
        return data;
    }
}

/** Список контрактов новостей */
export interface INewsListContract {
    /** Список контрактов новостей */
    news?: NewsContract[] | undefined;
}

/** Типы новостей<p>Значения:</p><ul><li><i>FriendsListUpdate</i> - Обновление списка друзей</li></ul> */
export enum NewsType {
    FriendsListUpdate = "FriendsListUpdate",
}

export class OkResult implements IOkResult {
    statusCode?: number;

    constructor(data?: IOkResult) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.statusCode = _data["statusCode"];
        }
    }

    static fromJS(data: any): OkResult {
        data = typeof data === 'object' ? data : {};
        let result = new OkResult();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["statusCode"] = this.statusCode;
        return data;
    }
}

export interface IOkResult {
    statusCode?: number;
}

/** Контракт Вк пользователя */
export class VkUserContract implements IVkUserContract {
    /** Имя */
    name?: string | undefined;
    /** Фамилия */
    surname?: string | undefined;
    /** Вк Id */
    id?: string | undefined;

    constructor(data?: IVkUserContract) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.surname = _data["surname"];
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): VkUserContract {
        data = typeof data === 'object' ? data : {};
        let result = new VkUserContract();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["surname"] = this.surname;
        data["id"] = this.id;
        return data;
    }
}

/** Контракт Вк пользователя */
export interface IVkUserContract {
    /** Имя */
    name?: string | undefined;
    /** Фамилия */
    surname?: string | undefined;
    /** Вк Id */
    id?: string | undefined;
}

/** Отношение между вк пользователями<p>Значения:</p><ul><li><i>Add</i> - Добавил</li><li><i>Delete</i> - Удалил</li></ul> */
export enum VkUserRelationsStatus {
    Add = "Add",
    Delete = "Delete",
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}