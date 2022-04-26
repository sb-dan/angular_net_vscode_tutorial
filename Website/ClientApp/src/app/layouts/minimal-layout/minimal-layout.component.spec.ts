import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MinimalLayoutComponent } from './minimal-layout.component';

describe('MinimalLayoutComponent', () => {
  let component: MinimalLayoutComponent;
  let fixture: ComponentFixture<MinimalLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MinimalLayoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MinimalLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
