import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HrzComponent } from './hrz.component';

describe('HrzComponent', () => {
  let component: HrzComponent;
  let fixture: ComponentFixture<HrzComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HrzComponent]
    });
    fixture = TestBed.createComponent(HrzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
