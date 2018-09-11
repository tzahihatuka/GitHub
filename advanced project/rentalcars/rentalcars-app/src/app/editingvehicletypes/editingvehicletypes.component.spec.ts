import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditingvehicletypesComponent } from './editingvehicletypes.component';

describe('EditingvehicletypesComponent', () => {
  let component: EditingvehicletypesComponent;
  let fixture: ComponentFixture<EditingvehicletypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditingvehicletypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditingvehicletypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
