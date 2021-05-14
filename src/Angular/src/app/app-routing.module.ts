import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HolidaysAddComponent } from './components/holidays-add/holidays-add.component';
import { HolidaysDetailsComponent } from './components/holidays-details/holidays-details.component';
import { HolidaysListComponent } from './components/holidays-list/holidays-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'holidays', pathMatch: 'full' },
  { path: 'holidays', component: HolidaysListComponent },
  { path: 'holidays/:id', component: HolidaysDetailsComponent },
  { path: 'add', component: HolidaysAddComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
