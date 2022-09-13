import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class MessageAlertService {

  constructor(private toastr: ToastrService) { }

  success(message: string, title?: string): void {
    this.toastr.success(message, title);
  }

  erroFormulario(): void {
    this.toastr.info('Preencha os campos obrigatórios!');
  }

  error(message: string, title?: string): void {
    this.toastr.error(message, title);
  }

  aviso(message: string, title?: string): void {
    this.toastr.info(message, title);
  }
}
