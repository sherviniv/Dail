import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeScheduleFormComponent } from './time-schedule-form.component';

describe('TimeScheduleFormComponent', () => {
  let component: TimeScheduleFormComponent;
  let fixture: ComponentFixture<TimeScheduleFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeScheduleFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeScheduleFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
