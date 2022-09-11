import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemParceirosComponent } from './listagem-parceiros.component';

describe('ListagemParceirosComponent', () => {
  let component: ListagemParceirosComponent;
  let fixture: ComponentFixture<ListagemParceirosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListagemParceirosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListagemParceirosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
