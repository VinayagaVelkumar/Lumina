import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PAListComponent } from './palist.component';

describe('PAListComponent', () => {
  let component: PAListComponent;
  let fixture: ComponentFixture<PAListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PAListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PAListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
