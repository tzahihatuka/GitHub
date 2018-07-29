import { Component, OnInit } from '@angular/core';
import { Datum } from '../shared/models/Datum.model';
import { UserService } from '../shared/services/users.service';
import { RootObject } from '../shared/models/root.model';

@Component({
  selector: 'app-mian',
  templateUrl: './mian.component.html',
  styleUrls: ['./mian.component.css']
})
export class MianComponent implements OnInit {
  public myUsers: Datum;
  constructor(public usersService:UserService) {
    this.myUsers=this.usersService.usersInfo;
   }

  ngOnInit() {
  }

}
