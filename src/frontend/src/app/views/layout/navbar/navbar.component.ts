import { Component, OnInit, Inject, Renderer2 } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(
    @Inject(DOCUMENT) private document: Document, 
    private renderer: Renderer2,
    private router: Router,
    private sessionStorage: SessionStorageService
  ) { }

  ngOnInit(): void {
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
