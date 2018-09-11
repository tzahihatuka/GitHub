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
  orderlist:any;
  constructor(private myCarOrders:CarOrderService) {
   }
   search(){
    this.myCarOrders.getUserOrdersByIdNamber(this.model.IdNamber);
    setTimeout(() => {
      this.orderlist=this.myCarOrders.orderlist;
      console.log(this.myCarOrders.orderlist)
    },30);
   }

  onSubmit(order:string)
  {
   let mindate:Date=new Date();
   let start:Date=new Date(this.model.Start);
   mindate=new Date(mindate.getFullYear(),mindate.getMonth(),mindate.getDate());
  
    if(start<=mindate){
      this.wrongmindate=true;
    }
    else{
      this.wrongmindate=false;
    }
    if(this.model.Start<this.model.End&&start>=mindate)
    {
     this.wrongDateInput=false;
    }
    else{
      this.wrongDateInput=true;
    }
    switch (order){
      case "Add":console.log("add");break;
      case "Update":console.log("Update");break;
      case "Delete":console.log("Delete");break;
    }
    }
 
    setItem(str){
      this.model.StartDate=str.StartDate;
      this.model.ReturnDate=str.ReturnDate;
      this.model.VehicleNumber=str.VehicleNumber;
      this.model.ActualReturnDate=str.ActualReturnDate;
      this.orderlist={a:""};
      this.orderlist=[this.model];
  }
 
}
