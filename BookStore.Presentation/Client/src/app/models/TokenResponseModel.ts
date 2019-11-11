import { UserModel } from 'app/models/UserModel';

export class TokenResponseModel {
    public  accessToken: string;
    public  refreshToken: string;
    public role: string;
    public id: number;
}
