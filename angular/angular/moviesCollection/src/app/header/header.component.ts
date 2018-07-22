import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import {categoryList} from "../../shared/models/categoryList";
import {RootObject} from "../../shared/models/interfaceCategory";
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public categorylist: Array<RootObject> = [];

  @Output() categorySelected: EventEmitter<string>=new EventEmitter<string>();

  constructor() { 
    this.categorylist=categoryList;
  }

 public categoryChoosing(checkcat:string):void{
    this.categorySelected.emit(checkcat);
  }
 ngOnInit() {
  }

}
