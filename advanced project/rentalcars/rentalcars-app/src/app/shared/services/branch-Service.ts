import { Injectable } from "../../../../node_modules/@angular/core";
import { HttpClient } from "../../../../node_modules/@angular/common/http";

@Injectable()
export class branchservice {
    branchList:any={a:""}
    constructor(private myHttpClient: HttpClient) {}
        getBraenchList(){
                let apiUrl:string=`http://localhost:55860/api/Branche`;
                this.myHttpClient.get(apiUrl)
                    .subscribe((x: any) => {this.branchList.a=x });
        }
    
}