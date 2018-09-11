import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { carModel } from "../models/car-model";


//מאפשר לשירות הנוכחי להשתמש בתוכו בשירותים אחרים
@Injectable()
export class carsModel {
    TypeName:any={a:""};
    TypsModel:any={a:""};
    TypsGetGear:any={a:""};
    TypsGetYear:any={a:Date};
    constructor(private myHttpClient: HttpClient) {
        this.getCarTyps();
        this.getCarTypsGetGear();
        this.getCarTypsGetYear();
    }

    getCarTyps(): void {
        let apiUrl:string=`http://localhost:55860/api/TypeName`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypeName.a=x });
    }

    getCarTypsModel(CompanynName:String): void {
        let apiUrl:string=`http://localhost:55860/api/TypeName?id=${CompanynName}`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypsModel.a=x });
    }

    getCarTypsGetGear(): void {
        let apiUrl:string=`http://localhost:55860/api/GetGear`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypsGetGear.a=x });
    }
    getCarTypsGetYear(): void {
        let apiUrl:string=`http://localhost:55860/api/GetYear`;
        this.myHttpClient.get(apiUrl)
            .subscribe((x: any) => {this.TypsGetYear.a=x});
    }
}