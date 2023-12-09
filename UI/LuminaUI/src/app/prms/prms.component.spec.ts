import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PRMSComponent } from './prms.component';

describe('PRMSComponent', () => {
  let component: PRMSComponent;
  let fixture: ComponentFixture<PRMSComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PRMSComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PRMSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
