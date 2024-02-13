import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { LoginComponent } from './modules/login/login.component';
import { HomeComponent } from './modules/home/home.component';
import { RegisComponent } from './modules/regis/regis.component';
import { HrzComponent } from './modules/hrz/hrz.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'regis', component: RegisComponent },  
  { path: 'hrzone', component: HrzComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {  }
