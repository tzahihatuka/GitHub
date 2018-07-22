import { Component, OnInit , Output,EventEmitter} from '@angular/core';
import { articales } from '../shared/data/json_list';
import { RootObject } from '../shared/data/interface_json_list';


@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  constructor(private articale:articales) { }
public listOfArticale:RootObject[];
public checked_article(index){
  this.articale.array;
  this.articale.array=this.listOfArticale[Number(index)];
  //console.log(this.articale.array);
}
  ngOnInit() {
    this.listOfArticale=this.articale.articale_List;
  }

}
