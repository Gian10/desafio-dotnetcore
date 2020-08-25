import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {FormsModule} from '@angular/forms'
import {ReactiveFormsModule} from '@angular/forms'

// injetar pipe de dinheiro em campo preço
import {CurrencyMaskModule} from 'ng2-currency-mask'

// injetar paginação
import {NgxPaginationModule} from 'ngx-pagination'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListParticipantsComponent } from './list-participants/list-participants.component';


import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router'
import {ROUTES} from './app-routes';


import { HomeComponent } from './home/home.component';
import { ViewMainComponent } from './view-main/view-main.component';
import { ListGuestComponent } from './list-guest/list-guest.component';
import { CreateParticipantComponent } from './create-participant/create-participant.component'

@NgModule({
  declarations: [
    AppComponent,
    ListParticipantsComponent,
    HomeComponent,
    ViewMainComponent,
    ListGuestComponent,
    CreateParticipantComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(ROUTES),
    CurrencyMaskModule,
    NgxPaginationModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
