import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MessageAlertService } from './core/services/message-alert.service';
import { Router } from '@angular/router';
import { SessionStorageService } from './core/services/session-storage.service';
import { AuthService } from './core/services/auth.service';
import { TokenService } from './core/services/token.service';

@Injectable()
export class HttpCustomInterceptor implements HttpInterceptor {

  constructor(
    private messageAlert: MessageAlertService,
    private router: Router,
    private sessionStorage: SessionStorageService,
    private token: TokenService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    var http = '';
    let requestNew: any;

    if (request.url.includes("produtos")) {
      http = 'https://ds-wms-api.azurewebsites.net/api';
    } else if (request.url.includes("autenticacao")) {
      http = 'https://ds-identidade-api.azurewebsites.net/api';
    } else if (request.url.includes("parceiro")) {
      http = 'https://ds-oms-api.azurewebsites.net/api';
    }

    requestNew = request.clone({
      url: http + request.url,
    });

    const token = this.sessionStorage.get(AuthService.chave);
    if (token) {
      requestNew = requestNew.clone({ headers: request.headers.set('Authorization', `Bearer ${token}`) });
    }

    return next.handle(requestNew).pipe(catchError((error: HttpErrorResponse) => {

      const messageDefault = 'Algo inesperado aconteceu antes de completar a solicitação!'
      let errorMessage = messageDefault;

      if (error.error instanceof ErrorEvent) {
        errorMessage = `Error: ${error.error}`;
      } else {
        switch (error.status) {
          case 400:
            errorMessage = error.error ?
              error.error.mensagem ?
                error.error.mensagem :
                messageDefault :
              messageDefault;
            break;
          case 401:
            {
              this.messageAlert.aviso('Acesso negado! Efetue login novamente.');
              this.sessionStorage.remove(AuthService.chave);
              this.router.navigate(['auth/login'], { queryParams: {}, });
              break;
            }
          case 403:
            errorMessage = 'O servidor não autorizou o acesso ao recurso solicitado!';
            break;
          case 404: {
            errorMessage = error.error ? error.error : 'Recurso solicitado não encontrado!';
            break;
          }
          case 500:
            errorMessage = 'Ops, não foi possível realizar essa ação no momento.';
            break;
          default:
            errorMessage = 'Algo inesperado aconteceu.';
            break;
        }
      }

      if (errorMessage) {
        this.messageAlert.error(errorMessage);
        return throwError(() => new Error(errorMessage));
      } else {
        return throwError(() => new Error('Erro inesperado!'));
      }
    }));
  }
}
