import React, { useRef, useState } from 'react';
import { useForm, Controller } from 'react-hook-form';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Password } from 'primereact/password';
import { Divider } from 'primereact/divider';
import { classNames } from 'primereact/utils';
import './Auth.css';
import { ApiViolaTricolor, AuthRequest, IAuthRequest } from '../../../api';
import { LOCAL_STORAGE_ROLES, LOCAL_STORAGE_TOKEN, LOCAL_STORAGE_TOKEN_TYPE, LOCAL_STORAGE_USERNAME, LOCAL_STORAGE_VALIDITY_PERIOD, LOCAL_STORAGE_VK_USER_ID, LOCAL_STORAGE_VT_USER_ID } from '../../../constsAndDicts/localStorageConsts';
import { useAuthContext } from '../../../contexts/AuthContext';

const Auth: React.FC = () => {
    const requiredMessage: string = 'Обязательное поле';
    const defaultValues: IAuthRequest = {
        login: '',
        password: '',
    }
    const api = useRef(new ApiViolaTricolor());
    const { control, formState: { errors }, handleSubmit, reset } = useForm({ defaultValues });
    const [formDisabled, setFormDisabled] = useState<boolean>(false);
    const authContext = useAuthContext();

    const onSubmit = (data: IAuthRequest) => {
        setFormDisabled(true);

        api.current.authorize(data as AuthRequest)
            .then(response => {
                localStorage.setItem(LOCAL_STORAGE_ROLES, response.roles?.toString());
                localStorage.setItem(LOCAL_STORAGE_TOKEN, response.token);
                localStorage.setItem(LOCAL_STORAGE_TOKEN_TYPE, response.token_type);
                localStorage.setItem(LOCAL_STORAGE_USERNAME, response.username);
                localStorage.setItem(LOCAL_STORAGE_VALIDITY_PERIOD, response.validity_period.toISOString());
                localStorage.setItem(LOCAL_STORAGE_VK_USER_ID, response.vk_user_id);
                localStorage.setItem(LOCAL_STORAGE_VT_USER_ID, response.vt_user_id);
                authContext.setIsAuthorized(true)
            })
            .catch(error => {
                alert(error)
            })

        setFormDisabled(false);
        reset();
    };

    const getFormErrorMessage = (field: string) => {
        return (errors as any)[field] && <small className="p-error">{(errors as any)[field].message}</small>
    };

    const passwordHeader = <h6>Введите пароль</h6>;
    const passwordFooter = (
        <React.Fragment>
            <Divider />
            <p className="mt-2">Ограничения</p>
            <ul className="pl-2 ml-2 mt-0" style={{ lineHeight: '1.5' }}>
                <li>Символ в верхнем регистре</li>
                <li>Символ в нижнем регистре</li>
                <li>Цифра</li>
                <li>Минимум 8 символов</li>
            </ul>
        </React.Fragment>
    );

    return (
        <div className="form-demo">
            <div className="flex justify-content-center card-container">
                <div className="card">
                    <h5 className="text-center">Register</h5>
                    <form onSubmit={handleSubmit(onSubmit)} className="p-fluid">
                        <div className="field">
                            <span className="p-float-label">
                                <Controller name="login" control={control} rules={{ required: requiredMessage }} render={({ field, fieldState }) => (
                                    <InputText disabled={formDisabled} id={field.name} {...field} autoFocus className={classNames({ 'p-invalid': fieldState.invalid })} />
                                )} />
                                <label htmlFor="login" className={classNames({ 'p-error': errors.login })}>Логин*</label>
                            </span>
                            {getFormErrorMessage('login')}
                        </div>
                        <div className="field">
                            <span className="p-float-label">
                                <Controller name="password" control={control} rules={{ required: requiredMessage }} render={({ field, fieldState }) => (
                                    <Password disabled={formDisabled} id={field.name} {...field} toggleMask className={classNames({ 'p-invalid': fieldState.invalid })} header={passwordHeader} footer={passwordFooter} />
                                )} />
                                <label htmlFor="password" className={classNames({ 'p-error': errors.password })}>Пароль*</label>
                            </span>
                            {getFormErrorMessage('password')}
                        </div>

                        <Button type="submit" label="Submit" className="mt-2" />
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Auth;