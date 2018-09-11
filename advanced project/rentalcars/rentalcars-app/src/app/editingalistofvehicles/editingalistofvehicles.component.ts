import { Component, OnInit } from '@angular/core';
import { CarOrderService } from '../shared/services/order-serves';
import { carOrder } from '../shared/models/carOrder-model';

@Component({
  selector: 'editingalistofvehicles',
  templateUrl: './editingalistofvehicles.component.html',
  styleUrls: ['./editingalistofvehicles.component.css']
})
export class EditingalistofvehiclesComponent implements OnInit {
  ngOnInit() {
  }
}
