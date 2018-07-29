import { Component, OnInit ,Input} from '@angular/core';
import {RootObject} from "../../shared/models/movieInterface";

@Component({
  selector: 'app-child2',
  templateUrl: './child2.component.html',
  styleUrls: ['./child2.component.css']
})


export class Child2Component implements OnInit {

@Input() parentInput:RootObject;
@Input() clicked:boolean;

  constructor() {
  
   }

  
  ngOnInit() {
  }

}
