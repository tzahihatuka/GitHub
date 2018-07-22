import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import{RootObject} from '../models/root.model'
import{Datum} from '../models/Datum.model'
@Injectable()
export class UserService {
usersInfo:Datum={};
    constructor(private myHttpClient: HttpClient) {
        let apiUrl:string=`https://reqres.in/api/users`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x:RootObject) => {this.usersInfo[0]=x.data});
           
    
    }

}


