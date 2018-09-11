import { Component} from '@angular/core';
import { carOrder } from '../shared/models/carOrder-model';
import { CarOrderService } from '../shared/services/order-serves';

@Component({
  selector: 'edit-orders',
  templateUrl: './edit-orders.component.html',
  styleUrls: ['./edit-orders.component.css']
})
export class EditOrdersComponent {
  model: any = {};
  wrongDateInput:boolean=false;
  wrongmindate:boolean=false;
  wrongCarinput:boolean=false;
  orderlist:any;
  constructor(private myCarOrders:CarOrderService) {
   }
   search(){
    this.myCarOrders.getUserOrdersByIdNamber(this.model.IdNamber);
    setTimeout(() => {
      this.orderlist=this.myCarOrders.orderlist;
      console.log(this.myCarOrders.orderlist)
      this.model.UserName=this.orderlist[0].UserName
    },30);
   }
   getdetels:any={};
  onSubmit(order)
  {
    if( this.model.VehicleNumber==null){
    this.model.VehicleNumber=0;
  }
   let mindate:Date=new Date();
   let StartDate:Date=new Date(this.model.Start);
   mindate=new Date(mindate.getFullYear(),mindate.getMonth(),mindate.getDate());
   this.wrongDateInput=false;
    this.wrongmindate=false;
    if(StartDate<=mindate){
      this.wrongmindate=true;
    }
    else{
      this.wrongmindate=false;
    }
    if(this.model.Start<this.model.Return)
    {
     this.wrongDateInput=false;
    }
    else {
      this.wrongDateInput=true;
    }
 
    if(!this.wrongDateInput&&!this.wrongmindate){
    switch (order){
      case "Add":this.add();break;
      case "Update":console.log("Update");break;
      case "Delete":console.log("Delete");break;
      default:break;
    }
    } 
    }
    
 add(){
   if( this.model.VehicleNumber!=0){
    this.wrongCarinput=false;
    this.myCarOrders.sendNewOrder(this.model); 
   }
   if( this.model.VehicleNumber==0){
    this.wrongCarinput=true; 
   }

 }
    setItem(str){
      this.model.StartDate=str.StartDate;
      this.model.ReturnDate=str.ReturnDate;
      this.model.VehicleNumber=str.VehicleNumber;
      this.model.UserName=str.UserName;
      this.model.ActualReturnDate=str.ActualReturnDate;
      this.orderlist={a:""};
      this.orderlist=[this.model];
     
  }

}
