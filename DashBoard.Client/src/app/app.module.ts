import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { UserComponent } from './User/User.Component';


@NgModule({
  declarations: [
    AppComponent,   
    UserComponent
],
  imports: [
    BrowserModule,
    HttpClientModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
