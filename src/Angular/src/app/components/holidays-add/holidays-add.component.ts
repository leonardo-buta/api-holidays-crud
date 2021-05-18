import { Component, OnInit } from '@angular/core';
import { HolidayVariableDate } from 'src/app/models/holiday-variable-date.model';
import { Holiday } from 'src/app/models/holiday.model';
import { HolidayService } from 'src/app/services/holiday.service';

@Component({
  selector: 'app-holidays-add',
  templateUrl: './holidays-add.component.html',
  styleUrls: ['./holidays-add.component.css']
})
export class HolidaysAddComponent implements OnInit {

  holiday: Holiday = Object.assign(new Holiday(), { variableDates: [] });
  submitted = false;

  constructor(private holidayService: HolidayService) { }

  ngOnInit(): void {
  }

  saveHoliday(): void {
    this.holidayService.create(this.holiday)
      .subscribe(response => {
        console.log(response);
        this.submitted = true;
      },
        error => {
          console.log(error);
        });
  }

  newHoliday(): void {
    this.submitted = false;
    this.holiday = Object.assign(new Holiday(), { variableDates: [] });
  }

  addHolidayVariableDate(): void {
    this.holiday.variableDates.push(new HolidayVariableDate());
  }

  deleteHolidayVariableDate(index: number): void {
    this.holiday.variableDates.splice(index, 1);
  }
}
