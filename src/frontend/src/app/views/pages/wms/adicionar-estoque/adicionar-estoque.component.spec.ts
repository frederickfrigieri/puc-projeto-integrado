import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarEstoqueComponent } from './adicionar-estoque.component';

describe('AdicionarEstoqueComponent', () => {
  let component: AdicionarEstoqueComponent;
  let fixture: ComponentFixture<AdicionarEstoqueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdicionarEstoqueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarEstoqueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
