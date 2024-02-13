import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//import { LoginModule } from './modules/login/login.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { LoginComponent } from './modules/login/login.component';
import { RegisComponent } from './modules/regis/regis.component';
import { HrzComponent } from './modules/hrz/hrz.component';

@NgModule({
  declarations: [    
    AppComponent,
    HomeComponent,    
    LoginComponent,
    RegisComponent,
    HrzComponent
  ],
  imports: [
    BrowserModule,        
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
