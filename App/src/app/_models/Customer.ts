import { City } from './City';
import { Classification } from './Classification';
import { Gender } from './Gender';
import { Region } from './Region';
import { UserSys } from './UserSys';


export class Customer {

    id: number;
    name: string;
    phone: string;
    genderId: number;
    cityId: number;
    regionId: number;
    lastPurchase: Date;
    classificationId: number;
    userId: number;
    gender: Gender;
    city: City;
    region: Region;
    classification: Classification;
    user: UserSys;
}
