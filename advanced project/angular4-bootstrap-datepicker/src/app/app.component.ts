//Import core modules
import {Component} from '@angular/core';
import { NgbCalendar, NgbDateStruct, NgbDate} from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 
  hoveredDate: NgbDate;

  fromDate: NgbDate;
  toDate: NgbDate;
  public minDate: NgbDateStruct ; 

  constructor(calendar: NgbCalendar) {
    this.minDate = {
      "year": 1958,
      "month": 8,
      "day": 25
    };

    this.fromDate = calendar.getToday();
    this.toDate = calendar.getNext(calendar.getToday(), 'd', 10);
  }
showcalender:boolean=false;
toggle(){
  if(this.showcalender){
    this.showcalender=false;
  }
  else{
    this.showcalender=true;
  }
 
}
  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date.after(this.fromDate)) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }
  }

  isHovered = (date: NgbDate) => this.fromDate && !this.toDate && this.hoveredDate && date.after(this.fromDate) && date.before(this.hoveredDate);
  isInside = (date: NgbDate) => date.after(this.fromDate) && date.before(this.toDate);
  isRange = (date: NgbDate) => date.equals(this.fromDate) || date.equals(this.toDate) || this.isInside(date) || this.isHovered(date)
}