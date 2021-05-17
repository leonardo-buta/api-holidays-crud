import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HolidaysAddComponent } from './components/holidays-add/holidays-add.component';
import { HolidaysDetailsComponent } from './components/holidays-details/holidays-details.component';
import { HolidaysListComponent } from './components/holidays-list/holidays-list.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'holidays', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'holidays', component: HolidaysListComponent, canActivate: [AuthGuard] },
  { path: 'holidays/:id', component: HolidaysDetailsComponent, canActivate: [AuthGuard] },
  { path: 'add', component: HolidaysAddComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
