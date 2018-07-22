import { Component } from '@angular/core';
import {categoryList} from "../shared/models/categoryList";
import {RootObject} from "../shared/models/interfaceCategory";
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  constructor(  public httpclient:HttpClient) {

  }


  public categorySelected:any;

  public categoryselected(category:string):void {
    let a:any=[];
    if(category==undefined){
      category="https://api.themoviedb.org/3/discover/movie?api_key=15d2ea6d0dc1d476efbca3eba2b9bbfb";
    }
     a= this.httpclient.get(category);
    a.subscribe(hostslist=>{
    this.categorySelected=hostslist.results;
    console.log(this.categorySelected);
    for(let pic in this.categorySelected){
      this.categorySelected[pic].poster_path="http://image.tmdb.org/t/p/w500"+this.categorySelected[pic].poster_path;
    }
    

  });
   }
   
  }

