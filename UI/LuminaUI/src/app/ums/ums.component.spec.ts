import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UMSComponent } from './ums.component';

describe('UMSComponent', () => {
  let component: UMSComponent;
  let fixture: ComponentFixture<UMSComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UMSComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UMSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
