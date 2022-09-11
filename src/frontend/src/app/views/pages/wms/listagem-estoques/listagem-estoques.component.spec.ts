import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemEstoquesComponent } from './listagem-estoques.component';

describe('ListagemEstoquesComponent', () => {
  let component: ListagemEstoquesComponent;
  let fixture: ComponentFixture<ListagemEstoquesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListagemEstoquesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListagemEstoquesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
