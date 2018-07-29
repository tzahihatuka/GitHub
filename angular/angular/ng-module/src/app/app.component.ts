import { Component } from '@angular/core';
import { listVegtabels } from '../shared/models/vegetables-list';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public itIsMoreThan2:boolean;
  public lestThene1:boolean;
  public doNotDisplay:boolean;
public vagType:string;
public getListArray:Array<string>=[];

 public onestring(vagType:string):void{
  if(vagType.length==1){
    this.itIsMoreThan2=false;
    this.lestThene1=false;
    this.doNotDisplay=false
    }
  else if(vagType.length>1){
    this.itIsMoreThan2=true;
  this.doNotDisplay=true;
  }
  else{
    this.itIsMoreThan2=false;
    this.lestThene1=true;
  this.doNotDisplay=true;
  }
  this.getListArray=[];
}
public isInTheList(vagType:string):void{ 
if(vagType.length!=0)
  for(let felter in listVegtabels){
    if(vagType.charAt(0)==listVegtabels[felter].charAt(0)){
    this.getListArray.push(listVegtabels[felter]);
    }
  }

 }
}
