import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HolidaysListComponent } from './components/holidays-list/holidays-list.component';
import { HolidaysAddComponent } from './components/holidays-add/holidays-add.component';
import { HolidaysDetailsComponent } from './components/holidays-details/holidays-details.component';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';
import { UnauthorizedInterceptor } from './interceptors/unauthorized.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { AuthService } from './services/auth-service.service';
import { appInitializer } from './services/app-initializer';

@NgModule({
  declarations: [
    AppComponent,
    HolidaysListComponent,
    HolidaysAddComponent,
    HolidaysDetailsComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    NgbActiveModal,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializer,
      multi: true,
      deps: [AuthService],
    },
    {
      provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UnauthorizedInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
