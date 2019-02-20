import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { productlistComponent } from './productlist/productlist.component';
import { productComponent } from './product/product.component';
import { SecurityService } from './security/security.service';
import { loginComponent } from './security/login.component';
import { AuthGuard } from './security/auth.guard';
import { HttpInterceptorModule } from './security/http-interceptor.module';
import { HasClaimDirective } from './security/has-claim.directive';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    productlistComponent,
    productComponent,
    loginComponent,
    HasClaimDirective
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'productlist', canActivate: [AuthGuard], component: productlistComponent, data: { claimType: 'canAccessProducts' } },
      { path: 'product/:id', canActivate: [AuthGuard], component: productComponent, data: { claimType: 'canAccessProducts' } },
      { path: 'login', component: loginComponent },

      
    ]),
    HttpInterceptorModule
  ],
  providers: [SecurityService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
