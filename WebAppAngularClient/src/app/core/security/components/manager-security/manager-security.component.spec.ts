import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerSecurityComponent } from './manager-security.component';

describe('ManagerSecurityComponent', () => {
  let component: ManagerSecurityComponent;
  let fixture: ComponentFixture<ManagerSecurityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ManagerSecurityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagerSecurityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
