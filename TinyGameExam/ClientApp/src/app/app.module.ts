import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TinyGameComponent } from './tinyGame/tinyGame.component';
import { CommonModule } from '@angular/common';
import { DndModule } from 'ngx-drag-drop';


@NgModule({
  declarations: [
    AppComponent,   
    TinyGameComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
   
      { path: '', component: TinyGameComponent },
    ]),
    DndModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
