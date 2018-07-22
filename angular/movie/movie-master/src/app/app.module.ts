import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { RootComponent } from './root Component/root.component';
import { Child1Component } from './root Component/child1/child1.component';
import { Child2Component } from './root Component/child2/child2.component';


@NgModule({
  declarations: [
    AppComponent,
    RootComponent,
    Child1Component,
    Child2Component
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
