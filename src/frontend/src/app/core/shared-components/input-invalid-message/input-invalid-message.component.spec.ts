import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputInvalidMessageComponent } from './input-invalid-message.component';

describe('InputInvalidMessageComponent', () => {
  let component: InputInvalidMessageComponent;
  let fixture: ComponentFixture<InputInvalidMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputInvalidMessageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InputInvalidMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
