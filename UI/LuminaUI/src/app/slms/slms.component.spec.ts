import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SLMSComponent } from './slms.component';

describe('SLMSComponent', () => {
  let component: SLMSComponent;
  let fixture: ComponentFixture<SLMSComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SLMSComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SLMSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
