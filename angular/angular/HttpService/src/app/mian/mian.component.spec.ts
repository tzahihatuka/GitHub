import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MianComponent } from './mian.component';

describe('MianComponent', () => {
  let component: MianComponent;
  let fixture: ComponentFixture<MianComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MianComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MianComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
