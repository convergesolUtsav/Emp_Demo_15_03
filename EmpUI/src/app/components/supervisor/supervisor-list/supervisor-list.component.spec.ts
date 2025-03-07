import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupervisorListComponent } from './supervisor-list.component';

describe('SupervisorListComponent', () => {
  let component: SupervisorListComponent;
  let fixture: ComponentFixture<SupervisorListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SupervisorListComponent]
    });
    fixture = TestBed.createComponent(SupervisorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
