import { Component, OnInit, Input } from '@angular/core';
import { CarOrderService } from '../shared/services/order-serves';
import { carsService } from '../shared/services/cars-serves';
import { carOrder } from '../shared/models/carOrder-model';
import { ActivatedRoute } from '../../../node_modules/@angular/router';
import { carModel } from '../shared/models/car-model';

@Component({
  selector: 'order-preview',
  templateUrl: './order-preview.component.html',
  styleUrls: ['./order-preview.component.css']
})
export class OrderPreviewComponent implements OnInit {

  @Input() order;
  constructor(private myCarOrders:CarOrderService) {
    
    if(!myCarOrders.gutOrder){
      window.location.href="/MyOrders";
    }
  }
  ngOnInit() {
    
  }
}

