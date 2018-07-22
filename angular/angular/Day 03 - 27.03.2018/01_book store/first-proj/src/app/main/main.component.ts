import { Component } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
 
})
export class MainComponent {
  shopImg:string="./assets/images/book_home_page.png";
  addressArray:string[]=["12  Hamasger st.","Tel-Aviv","Israel"];
}
