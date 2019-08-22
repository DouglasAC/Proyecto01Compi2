import { Component } from '@angular/core';
import { DataService } from '../service/data.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-opciones',
  templateUrl: './opciones.component.html',
  styleUrls: ['./opciones.component.css']
})
export class OpcionesComponent {



  constructor(public data: DataService, private router: Router) {

  }

  public principiante() {
    this.router.navigate(['principiante/']);
  }

  public intermedio() {
    this.router.navigate(['intermedio/']);
  }

  public avanzado() {
    this.router.navigate(['avanzado/']);
  }


}
