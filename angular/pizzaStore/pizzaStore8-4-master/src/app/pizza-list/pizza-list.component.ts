import { Component, OnInit } from '@angular/core';
import { pizzaDetails } from '../shared/models/pizza';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';
@Component({
  selector: 'app-pizza-list',
  templateUrl: './pizza-list.component.html',
  styleUrls: ['./pizza-list.component.css']
})
export class PizzaListComponent implements OnInit {

  public  diameter:number;
  public  slices:number;
  public  toppings:number;
  public  price:number;
  public  outerAPizzaArr:Array<Array<number>>;


  constructor() { 
    this.getPizza();
    this.addAttribute();
    }



public  getPizza ():Array<Array<number>>{
  let innerAPizzaArr:Array<number>;
  this.outerAPizzaArr=[];
    for(let i=0;i<100;i++){
      innerAPizzaArr=[];

      innerAPizzaArr.push(this.diameter=this.random(50,10));
      innerAPizzaArr.push(this.slices=this.random(8,3));
      innerAPizzaArr.push(this.toppings=this.random(4,0));
      this.price=this.getPrice();
      innerAPizzaArr.push(this.price);
      
      this.outerAPizzaArr.push(innerAPizzaArr);
    }
  return this.outerAPizzaArr;
  }
  
  
  public random(x:number,y:number):number{
      return Math.floor(Math.random() * (x - y) + y);
  }

  public getPrice():number{
      return  this.diameter+(this.toppings*5);
  }

   
  


public addAttribute ():void{
   setTimeout(() => {
    for(let i=0;i<=100;i++){
      if(i!=0){
      if(i%2!=0){
    document.getElementsByTagName("tr")[i].setAttribute("class", "democlass");
      }
      else{
        document.getElementsByTagName("tr")[i].setAttribute("class", "democlass1");
      }
    }
    else{
    document.getElementsByTagName("tr")[i].setAttribute("style", "background-color: lightgray;");}
  }
},5);




}

  ngOnInit() {
  }

}
