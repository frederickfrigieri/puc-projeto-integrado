import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';

import { LayoutModule } from './views/layout/layout.module';
import { AuthGuard } from './core/guard/auth.guard';

import { AppComponent } from './app.component';
import { ErrorPageComponent } from './views/pages/error-page/error-page.component';

import { HIGHLIGHT_OPTIONS } from 'ngx-highlightjs';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpCustomInterceptor } from './http-custom.interceptor';

import { ToastrModule } from 'ngx-toastr';

import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LOADING_BAR_CONFIG } from '@ngx-loading-bar/core';

@NgModule({
  declarations: [
    AppComponent,
    ErrorPageComponent,
  ],
  imports: [
    BrowserModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    HttpClientModule,
    LoadingBarHttpClientModule
  ],
  providers: [
    AuthGuard,
    {
      provide: HIGHLIGHT_OPTIONS, // https://www.npmjs.com/package/ngx-highlightjs
      useValue: {
        coreLibraryLoader: () => import('highlight.js/lib/core'),
        languages: {
          xml: () => import('highlight.js/lib/languages/xml'),
          typescript: () => import('highlight.js/lib/languages/typescript'),
          scss: () => import('highlight.js/lib/languages/scss'),
        }
      }
    },
    { provide: HTTP_INTERCEPTORS, useClass: HttpCustomInterceptor, multi: true },
    { provide: LOADING_BAR_CONFIG, useValue: { latencyThreshold: 100 } }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
