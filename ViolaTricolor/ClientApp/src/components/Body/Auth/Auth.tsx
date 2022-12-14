import React, { useRef, useState } from 'react';
import { useForm, Controller } from 'react-hook-form';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Password } from 'primereact/password';
import { Divider } from 'primereact/divider';
import { classNames } from 'primereact/utils';
import './Auth.css';
import { ApiViolaTricolor, AuthRequest, IAuthRequest } from '../../../api';
import { useAuthContext } from '../../../contexts/AuthContext';
import { AuthService } from '../../../services/auth.service';

const Auth: React.FC = () => {
    const requiredMessage: string = 'Обязательное поле';
    const defaultValues: IAuthRequest = {
        login: '',
        password: '',
    }
    const api = useRef(new ApiViolaTricolor());
    const authContext = useAuthContext();
    const authService = new AuthService();
    const { control, formState: { errors }, handleSubmit, reset } = useForm({ defaultValues });
    const [formDisabled, setFormDisabled] = useState<boolean>(false);

    const onSubmit = (data: IAuthRequest) => {
        setFormDisabled(true);

        api.current.authorize(data as AuthRequest)
            .then(response => authService.auth(response, authContext))
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