import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MovieCardComponent } from './movie/movie-card/movie-card.component';
import { MovieListComponent } from './movie/movie-list/movie-list.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MovieCardComponent, 
    MovieListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: MovieCardComponent,   pathMatch: 'full' },
   
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
