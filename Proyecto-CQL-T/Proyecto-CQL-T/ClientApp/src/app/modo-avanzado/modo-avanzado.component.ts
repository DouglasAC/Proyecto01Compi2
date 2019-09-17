import { Component, ViewChild, ElementRef } from '@angular/core';
import { DataService } from '../service/data.service';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import * as $ from 'jquery';
import * as ace from 'ace-builds';
import 'ace-builds/src-noconflict/mode-javascript';
import 'ace-builds/src-noconflict/theme-github';

const THEME = 'ace/theme/github';
const LANG = 'ace/mode/javascript';

declare var gramaticaLUP: any;

@Component({
  selector: 'app-avanzado',
  templateUrl: './modo-avanzado.component.html'
})
export class ModoAvanzadoComponent {


  constructor(public data: DataService, private router: Router) {

  }

  ngOnInit() {

  }



  consultar(paquete: string) {
    alert(paquete);
    let datos = null;
    let respuesta = $.ajax({
      contentType: 'application/json;  charset=utf-8',
      type: "POST",
      url: "api/PaquetesLUP",
      data: JSON.stringify({
        paquete: paquete
      }),
      success: function (data, textStatus, jqXHR) {
        //alert(data.paquete);
        datos = data;
      },
      error: function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR.statusText);
        datos = null;
      }, async: false
    });

    if (datos != null) {
      this.data.tresivido += datos.paquete;
      let par = gramaticaLUP.parse(datos.paquete);

      for (let nodo of par) {
        if (nodo.tipo == "DATA") {
          this.addTab(true, nodo.data);
        } else if (nodo.tipo == "MESSAGE") {
          this.addConsola(nodo.data);
        } else if (nodo.tipo == "ERROR") {
          console.log(nodo.data);
        } else if (nodo.tipo == "BASES") {
          this.data.data = nodo.data;
        } else if (nodo.tipo == "LOGOUT") {
          if (nodo.data == true) {
            this.data.usuario = "";
            this.data.tenviado = "";
            this.data.tresivido = "";
            this.router.navigate(['/']);
          } else {
            alert("No se pudo terminar la seccion");
          }
        }
      }

    }
  }

  generarStruct() {
    let struct = "[+STRUCT][+USER]" + this.data.usuario + "[-USER][-STRUCT]";
    this.data.tenviado += struct;
    this.consultar(struct);
  }


  public salir() {

    let logout = "[+LOGOUT][+USER]" + this.data.usuario + "[-USER][-LOGOUT]";
    this.data.tenviado += logout;
    this.consultar(logout);
  }

  limpiarenvios() {
    this.data.tenviado = "";
  }

  limpiarrespuestas() {
    this.data.tresivido = "";
  }


  public generarPaqueteConsultaLup() {
    let envio = "[+QUERY]\n[+USER]" + this.data.usuario + "\n[-USER]\n[+DATA]\n" + "\n[-DATA]\n[-QUERY]\n";
    this.data.tenviado += envio;
    return envio;
  }

  tabs = [];
  consola = [];
  tabscontent = [];
  selected = new FormControl(0);


  //----- agrega la tab de consulta
  addTab(selectAfterAdding: boolean, contenido: string) {
    this.tabs.push('Consulta');
    this.tabscontent.push(contenido);
    if (selectAfterAdding) {
      this.selected.setValue(this.tabs.length - 1);
    }
  }

  //-------- quita el tab
  removeTab(index: number) {
    this.tabs.splice(index, 1);
  }

  //---- agrega texto al arreglo de consola
  addConsola(contenido: string) {
    this.consola.push(contenido);
  }

  //---- contenido deve ser html
  addConsulta(contenido) {
    this.tabscontent.push(contenido);

  }

  /// Poner html
  addHTML(inde) {
    let txt = document.getElementById("con" + inde);
    txt.innerHTML = this.tabscontent[inde];
    console.log(txt.innerHTML);
  }

  ///----------------avvee
  tabspanel = [];
  selectedpanel = new FormControl(0);
  tabspanelcontenido = [];
  textopanel = [];

  addTabPanel(nombre) {
    this.tabspanel.push(nombre);
    this.selectedpanel.setValue(this.tabspanel.length - 1);
    
  }

  addTabPanel2() {
    this.addTabPanel('nuevo');
    this.textopanel.push("");
  }

  vereditor(inde) {
    const element = document.getElementById("conde" + inde);
    const editorOptions: Partial<ace.Ace.EditorOptions> = {
      highlightActiveLine: true,
      minLines: 10,
      maxLines: 25,
      autoScrollEditorIntoView: true,

    };

    const codeEditor = ace.edit(element, editorOptions);
    codeEditor.setTheme(THEME);
    codeEditor.getSession().setMode(LANG);
    codeEditor.setShowFoldWidgets(true);

    codeEditor.setValue(this.textopanel[inde]);
    this.tabspanelcontenido.push(codeEditor);

    //document.getElementById("bot" + inde).disabled = true;
    
  }

  removeTabpanel(index: number) {
    this.tabspanel.splice(index, 1);
  }



  funGuradar(inde) {

  }

  funEjecutar(inde) {
    let code = this.tabspanelcontenido[inde];
    let texto = code.getValue();
    let envio = "[+QUERY][+USER]" + this.data.usuario + "[-USER][+DATA]\n" + texto+ "[-DATA][-QUERY]";
    this.data.tenviado += envio;
    this.consultar(envio);
    //alert(texto);
  }

  funEjecutarSeleccion(inde) {
    let code = this.tabspanelcontenido[inde];
    let texto = code.getSelectedText();
    let envio = "[+QUERY]\n[+USER]" + this.data.usuario + "\n[-USER]\n[+DATA]\n" + texto + "\n[-DATA]\n[-QUERY]\n";
    this.data.tenviado += envio;
    this.consultar(envio);
    //alert(texto);
  }

  ponertexto(inde) {
    let code = this.tabspanelcontenido[inde];
    let cont = this.textopanel[inde];
    code.setValue(cont);

  }
  file: any;
 

  funAbrir(e) {
    this.file = e.target.files[0];
    let texto;
    let fileReader = new FileReader();
    fileReader.readAsText(this.file);
    fileReader.onload = (e) => {
      this.textopanel.push(fileReader.result);
    }
    texto = fileReader.result;
    let nombre = this.file.name;
    this.addTabPanel(nombre);
  }
}


