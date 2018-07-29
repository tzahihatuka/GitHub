import { Component, OnInit } from '@angular/core';
import { articales } from '../shared/data/json_list';
import { RootObject } from '../shared/data/interface_json_list';

@Component({
  selector: 'app-article-info',
  templateUrl: './article-info.component.html',
  styleUrls: ['./article-info.component.css']
})
export class ArticleInfoComponent implements OnInit {

  constructor(private articale:articales) { }
public change:RootObject;
ngDoCheck() {this.change=this.articale.array;}

  ngOnInit() {
  }

}
