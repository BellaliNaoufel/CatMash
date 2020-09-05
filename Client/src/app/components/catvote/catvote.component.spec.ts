import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatvoteComponent } from './catvote.component';

describe('CatvoteComponent', () => {
  let component: CatvoteComponent;
  let fixture: ComponentFixture<CatvoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CatvoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatvoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
