import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuredAddComponent } from './insured-add.component';

describe('InsuredAddComponent', () => {
  let component: InsuredAddComponent;
  let fixture: ComponentFixture<InsuredAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsuredAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsuredAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
