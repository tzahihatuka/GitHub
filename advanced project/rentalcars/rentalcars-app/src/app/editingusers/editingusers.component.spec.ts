import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditingusersComponent } from './editingusers.component';

describe('EditingusersComponent', () => {
  let component: EditingusersComponent;
  let fixture: ComponentFixture<EditingusersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditingusersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditingusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
