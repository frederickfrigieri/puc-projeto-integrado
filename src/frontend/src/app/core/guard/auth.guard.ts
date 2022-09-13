import { Injectable } from '@angular/core';
import { CanActivate, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { SessionStorageService } from '../services/session-storage.service';
import { TokenService } from '../services/token.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private sessioStorage: SessionStorageService,
    private tokenService: TokenService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    var token = this.sessioStorage.get(AuthService.chave);
    var usuarioLogado = this.tokenService.decrypt(token);

    if (usuarioLogado && usuarioLogado.logado) {
      return true;
    } else {
      this.router.navigateByUrl('/auth/login');
    }
    return false;
  }
}