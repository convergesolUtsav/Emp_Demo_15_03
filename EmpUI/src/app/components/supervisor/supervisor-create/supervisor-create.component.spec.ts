import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupervisorCreateComponent } from './supervisor-create.component';

describe('SupervisorCreateComponent', () => {
  let component: SupervisorCreateComponent;
  let fixture: ComponentFixture<SupervisorCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SupervisorCreateComponent]
    });
    fixture = TestBed.createComponent(SupervisorCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
