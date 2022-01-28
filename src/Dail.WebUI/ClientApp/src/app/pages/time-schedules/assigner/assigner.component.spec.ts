import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignerComponent } from './assigner.component';

describe('AssignerComponent', () => {
  let component: AssignerComponent;
  let fixture: ComponentFixture<AssignerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
