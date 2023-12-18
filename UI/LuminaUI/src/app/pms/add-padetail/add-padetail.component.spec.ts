import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPADetailComponent } from './add-padetail.component';

describe('AddPADetailComponent', () => {
  let component: AddPADetailComponent;
  let fixture: ComponentFixture<AddPADetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddPADetailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddPADetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
