import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidaysAddComponent } from './holidays-add.component';

describe('HolidaysAddComponent', () => {
  let component: HolidaysAddComponent;
  let fixture: ComponentFixture<HolidaysAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HolidaysAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidaysAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
