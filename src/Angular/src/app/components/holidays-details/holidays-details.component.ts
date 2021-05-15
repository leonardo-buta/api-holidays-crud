import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Holiday } from 'src/app/models/holiday.model';
import { HolidayService } from 'src/app/services/holiday.service';

@Component({
  selector: 'app-holidays-details',
  templateUrl: './holidays-details.component.html',
  styleUrls: ['./holidays-details.component.css']
})
export class HolidaysDetailsComponent implements OnInit {

  @ViewChild('updatedModal', { read: TemplateRef }) updatedModal: TemplateRef<any> | undefined;
  currentHoliday: Holiday = new Holiday();
  message = '';

  constructor(
    private holidayService: HolidayService,
    private modalService: NgbModal,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getHoliday(this.route.snapshot.params.id);
  }

  getHoliday(id: string): void {
    this.holidayService.get(id)
      .subscribe(
        data => {
          this.currentHoliday = data;
        },
        error => {
          console.log(error);
        }
      );
  }

  updateHoliday(): void {
    this.holidayService.update(this.currentHoliday.id, this.currentHoliday)
      .subscribe(
        response => {
          this.message = 'Updated successfully';
        },
        error => {
          this.message = error.message;
          console.log(error);
        }).add(() => {
          this.modalService.open(this.updatedModal);
        });
  }

  deleteHoliday(): void {
    this.holidayService.delete(this.currentHoliday.id)
      .subscribe(
        () => {
          this.modalService.dismissAll();
          this.router.navigate(['/holidays']);
        },
        error => {
          console.log(error);
        }
      );
  }

  open(content: any) {
    this.modalService.open(content);
  }

}
