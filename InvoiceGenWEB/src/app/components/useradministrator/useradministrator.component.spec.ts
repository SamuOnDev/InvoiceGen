import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UseradministratorComponent } from './useradministrator.component';

describe('UseradministratorComponent', () => {
  let component: UseradministratorComponent;
  let fixture: ComponentFixture<UseradministratorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UseradministratorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UseradministratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
