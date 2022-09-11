import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseComponent } from './views/layout/base/base.component';
import { AuthGuard } from './core/guard/auth.guard';
import { ErrorPageComponent } from './views/pages/error-page/error-page.component';
import { BrowserModule } from '@angular/platform-browser';


const routes: Routes = [
  { path: 'auth', loadChildren: () => import('./views/pages/auth/auth.module').then(m => m.AuthModule) },
  {
    path: '',
    component: BaseComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: '/auth', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadChildren: () => import('./views/pages/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'oms',
        loadChildren: () => import('./views/pages/oms/oms.module').then(m => m.OmsModule)
      },
      {
        path: 'wms',
        loadChildren: () => import('./views/pages/wms/wms.module').then(m => m.WmsModule)
      },
    ]
  },
  {
    path: 'error',
    component: ErrorPageComponent,
    data: {
      'type': 404,
      'title': 'Page Not Found',
      'desc': 'Oopps!! The page you were looking for doesn\'t exist.'
    }
  },
  {
    path: 'error/:type',
    component: ErrorPageComponent
  },
  { path: '**', redirectTo: 'error', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { scrollPositionRestoration: 'top' }),
    BrowserModule
  ],
  exports: [RouterModule, BrowserModule]
})
export class AppRoutingModule { }
