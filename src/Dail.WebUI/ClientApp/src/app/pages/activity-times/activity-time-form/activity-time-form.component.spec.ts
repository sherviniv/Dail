import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityTimeFormComponent } from './activity-time-form.component';

describe('ActivityTimeFormComponent', () => {
  let component: ActivityTimeFormComponent;
  let fixture: ComponentFixture<ActivityTimeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActivityTimeFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityTimeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
