import { Component, OnInit, Inject, Renderer2 } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  parceiroLogin = '';
  parceiroChave = '';

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    private router: Router,
    private tokenService: TokenService,
    private sessionStorage: SessionStorageService
  ) { }

  ngOnInit(): void {
    const token = this.sessionStorage.get(AuthService.chave);
    var usuario = this.tokenService.decrypt(token);
    this.parceiroLogin = usuario.login;
    this.parceiroChave = usuario.chaveUsuario;
  }

  /**
   * Sidebar toggle on hamburger button click
   */
  toggleSidebar(e: Event) {
    e.preventDefault();
    this.document.body.classList.toggle('sidebar-open');
  }

  /**
   * Logout
   */
  onLogout(e: Event) {
    e.preventDefault();
    this.sessionStorage.remove(AuthService.chave);
    this.router.navigateByUrl('/auth/login');
  }

}
