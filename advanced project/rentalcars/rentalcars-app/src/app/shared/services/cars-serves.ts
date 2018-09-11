import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { carModel } from "../models/car-model";
import { carOrder } from "../models/carOrder-model";


@Injectable()
export class carsService {
    carInfo:any={a:""};
    carById:any={a:""};
    constructor(private myHttpClient: HttpClient) {}

    getGars(): void {
        let apiUrl:string=`http://localhost:55860/api/CarInventory?from=0&&to=52`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: carModel) => {this.carInfo.a=x});
    }

    getCarByNumber(carNumber:number): void {
        let apiUrl:string=`http://localhost:55860/api/CarInventory?carNumber=${carNumber}`;
        
        this.myHttpClient.get(apiUrl)
            .subscribe((x: carModel) => {this.carInfo.a=x,console.log(this.carInfo.a)});
    }

GetCarListByVehicleNumber1(orderlist:carOrder){
let a={orderlist}
    if(this.carById.length>0){return;}
    let apiUrl:string=`http://localhost:55860/api/CarInventory?orderlist=${JSON.stringify(a)}`;
this.myHttpClient.get(apiUrl,
{
    headers: new HttpHeaders().set('Authorization',  localStorage.getItem("username")+" "+localStorage.getItem("password"))
}).subscribe((res:any)=>{this.carById.a=res},err => {

});
}
}