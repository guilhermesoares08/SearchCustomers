import { UserRole } from './UserRole';

export class UserSys {
    id: number;
    login: string;
    email: string;
    password: string;
    userRole: UserRole;
}
