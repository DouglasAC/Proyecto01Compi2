import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MensajesComponent } from './mensajes/mensajes.component';
import { LogingComponent } from './loging/loging.component';
import { DataService } from './service/data.service';
import { OpcionesComponent } from './opciones/opciones.component';
import { TreeViewComponent } from './tree-view/tree-view.component';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModoPrincipianteComponent } from './modo-principiante/modo-principiante.component';
import { MatTabsModule } from '@angular/material/tabs';
import { ModoIntermedioComponent } from './modo_intermedio/modo_intermedio.component';
import { ModoAvanzadoComponent } from './modo-avanzado/modo-avanzado.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MensajesComponent,
    LogingComponent,
    OpcionesComponent,
    TreeViewComponent,
    ModoPrincipianteComponent,
    ModoIntermedioComponent,
    ModoAvanzadoComponent
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LogingComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'opciones', component: OpcionesComponent },
      { path: 'principiante', component: ModoPrincipianteComponent },
      { path: 'intermedio', component: ModoIntermedioComponent },
      { path: 'avanzado', component: ModoAvanzadoComponent }
    ]),
    TreeViewModule,
    BrowserAnimationsModule,
    MatTabsModule
   
  ],
  providers: [DataService],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }
