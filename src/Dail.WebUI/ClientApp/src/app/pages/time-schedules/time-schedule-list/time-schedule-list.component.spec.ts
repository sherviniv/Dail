import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeScheduleListComponent } from './time-schedule-list.component';

describe('TimeScheduleListComponent', () => {
  let component: TimeScheduleListComponent;
  let fixture: ComponentFixture<TimeScheduleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeScheduleListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeScheduleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
