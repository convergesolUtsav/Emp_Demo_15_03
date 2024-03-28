import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupervisorEditComponent } from './supervisor-edit.component';

describe('SupervisorEditComponent', () => {
  let component: SupervisorEditComponent;
  let fixture: ComponentFixture<SupervisorEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SupervisorEditComponent]
    });
    fixture = TestBed.createComponent(SupervisorEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
