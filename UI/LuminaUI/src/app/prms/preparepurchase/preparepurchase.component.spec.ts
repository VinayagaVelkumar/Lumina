import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreparepurchaseComponent } from './preparepurchase.component';

describe('PreparepurchaseComponent', () => {
  let component: PreparepurchaseComponent;
  let fixture: ComponentFixture<PreparepurchaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PreparepurchaseComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PreparepurchaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
