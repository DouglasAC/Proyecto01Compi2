import { Component } from '@angular/core';
import { DataService } from '../service/data.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import * as $ from 'jquery';

declare var gramaticaLUP: any;

@Component({
  selector: 'app-loging',
  templateUrl: './loging.component.html',
  styleUrls: ['./loging.component.css']
})
export class LogingComponent {

 

  constructor(public data: DataService, private router: Router, private http: HttpClient) {
    
  }

  public enviar(usuario: string, clave: string) {
    let envio = this.generarEnvio(usuario, clave);
    this.data.tenviado += envio;

    let datos = null;
    let respuesta = $.ajax({
      contentType: 'application/json;  charset=utf-8',
      type: "POST",
      url: "api/Inicio",
      data: JSON.stringify({
        respuesta: envio
      }),
      success: function (data, textStatus, jqXHR) {
        ///alert(data.respuesta);
        datos = data;
      },
      error: function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR.statusText);
        datos = null;
      }, async: false
    });
    if (datos != null) {
      this.data.tresivido += datos.respuesta;
      let par = gramaticaLUP.parse(datos.respuesta);
      if (par[0].tipo == 'LOG') {
        if (par[0].data == true) {
          this.data.usuario = usuario;
          this.cambiar();
        } else {
          alert("Usuario o contraseña incorrecta")
        }
      } else {
        console.log("No era tipo log revisar respuesta")
        console.log(par);
      }
    }
    console.log(datos);

   
  }

  public generarEnvio(usuario: string, clave: string) {
    return "[+LOGIN]\n  [+USER]\n   " + usuario + "\n  [-USER]\n  [+PASS]\n   " + clave +"\n  [-PASS]\n[-LOGIN]\n";
  }

  public cambiar() {
    this.router.navigate(['opciones/']);
  }
}
