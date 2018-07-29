import { Component, OnInit,Output,EventEmitter } from '@angular/core';
import {RootObject} from "../../shared/models/movieInterface";
import {jsonmove} from "../../shared/models/novieJson";

@Component({
  selector: 'app-child1',
  templateUrl: './child1.component.html',
  styleUrls: ['./child1.component.css']
})


export class Child1Component implements OnInit {

    @Output() movieSelected: EventEmitter<number>=new EventEmitter<number>();

  public jMovie: Array<RootObject> = [];


  constructor() { 
    this.jMovie = jsonmove;
  }

  public onmovieSelected(selectedMovie:number): void {

    //emit הפונקציה 
    //היא פונקציה שמעוררת את האירוע בבן, ומאפשרת לאב להאזין לאירוע
    //כיוון שהגדרנו את הטיפוס - כמעביר מחרוזת כפרמטר באירוע
    //ניתן לפונקציה את המחרוזת שאנו רוצים להעביר לאב
    //$event הפרמטר ששלחנו יוכל להיות נגיש באב באמצעות המילה השמורה 
    this.movieSelected.emit(selectedMovie);
}

  ngOnInit() {
  }

}
