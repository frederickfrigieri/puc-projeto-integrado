import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class HttpCustomInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    
    var http = '';
    
    if (request.url.includes("parceiro")) {
      http = environment.urlOms;
    }
    
    const requestNew = request.clone({
      url: http + request.url
    });
    
    return next.handle(requestNew);
  }
}
