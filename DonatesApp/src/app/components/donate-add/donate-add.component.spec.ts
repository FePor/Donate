import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonateAddComponent } from './donate-add.component';

describe('DonateAddComponent', () => {
  let component: DonateAddComponent;
  let fixture: ComponentFixture<DonateAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DonateAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DonateAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
