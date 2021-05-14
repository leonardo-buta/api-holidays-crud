import { Component, OnInit } from '@angular/core';
import { Holiday } from 'src/app/models/holiday.model';
import { HolidayService } from 'src/app/services/holiday.service';

@Component({
  selector: 'app-holidays-list',
  templateUrl: './holidays-list.component.html',
  styleUrls: ['./holidays-list.component.css']
})
export class HolidaysListComponent implements OnInit {

  holidays?: Holiday[];
  currentHoliday?: Holiday = undefined;
  currentIndex = -1;
  totalHolidays = 0;
  titleSearch = '';
  dateSearch = '';

  constructor(private holidayService: HolidayService) { }

  ngOnInit(): void {
    this.getholidays();
  }

  getholidays(): void {
    this.holidayService.getAll()
      .subscribe(data => {
        this.holidays = data;
        this.totalHolidays = data.length;
      },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.getholidays();
    this.currentHoliday = undefined;
    this.currentIndex = -1;
    this.titleSearch = '';
    this.dateSearch = '';
  }

  setActiveHoliday(holiday: Holiday, index: number): void {
    this.currentHoliday = holiday;
    this.currentIndex = index;
  }

  searchHoliday(): void {
    this.holidayService.getWithFilter(this.titleSearch, this.dateSearch)
      .subscribe(data => {
        this.holidays = data;
        this.totalHolidays = data.length;
        this.currentHoliday = undefined;
        this.currentIndex = -1;
      },
        error => {
          console.log(error);
        });
  }

}
