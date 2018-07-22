import { Component, OnInit,Input,Output ,EventEmitter} from '@angular/core';
import {RootObject} from "../shared/models/movieInterface";
import {jsonmove} from "../shared/models/novieJson";

@Component({
  selector: 'app-root1',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css']
})
export class RootComponent implements OnInit {
public id:number;
public clicked:boolean=false;

  constructor() { }

  public onmovieSelected(id:number){
    this.id=id;
  }
  public selectMovie: RootObject;
 
  public selectedMovie(id:number):void {
    this.clicked=true;
    for (let obj of jsonmove) {
      if (id == obj.id) {
        this.selectMovie = obj;
      }
    }
  }

  ngOnInit() {
  }

}
