import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TonyIsGayComponent } from './tony-is-gay.component';

describe('TonyIsGayComponent', () => {
  let component: TonyIsGayComponent;
  let fixture: ComponentFixture<TonyIsGayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TonyIsGayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TonyIsGayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
