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

declare var Blockly: any;
declare var gramaticaLUP: any;


@Component({
  selector: 'app-intermedio',
  templateUrl: './modo_intermedio.component.html',
  styleUrls: ['./modo_intermedio.component.css']
})
export class ModoIntermedioComponent {


  workspace: any;

  @ViewChild('codeEditor', { static: true }) codeEditorElmRef: ElementRef;
  private codeEditor: ace.Ace.Editor;
  constructor(public data: DataService, private router: Router) {

  }

  ngOnInit() {

    this.workspace = Blockly.inject('blocklyDiv', {
      toolbox: document.getElementById('toolbox'),
      scrollbars: true

    });

    //------ ace editor-----
    const element = this.codeEditorElmRef.nativeElement;
    const editorOptions: Partial<ace.Ace.EditorOptions> = {
      highlightActiveLine: true,
      minLines: 10,
      maxLines: 30,
      autoScrollEditorIntoView: true,

    };

    this.codeEditor = ace.edit(element, editorOptions);
    this.codeEditor.setTheme(THEME);
    this.codeEditor.getSession().setMode(LANG);
    this.codeEditor.setShowFoldWidgets(true); // for the scope fold feature


  }

  // vista previa del codigo
  cambio() {
    var code = Blockly.JavaScript.workspaceToCode(this.workspace);
    this.codeEditor.setValue(code);
  }

  public generarcodigo() {

    let code = this.generarPaqueteConsultaLup();
    this.consultar(code);
  }


  /* this.addTab(true, "<table ><tr><th>Hoy </th><th> Mañana </th> <th> Lunes </th> </tr><tr> <td>Soleado </td><td> Mayormente soleado </td> <td> Parcialmente nublado </td></tr> <tr> <td>19°C </td><td> 17°C </td><td> 12°C </td> </tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr><tr><td>E 13 km / h </td><td> E 11 km / h </td><td> S 16 km / h </td></tr></table>");
   this.addConsola(code);
     this.xml = Blockly.Xml.domToText(
     Blockly.Xml.workspaceToDom(this.workspace)
   );
   alert(this.xml);*/


  consultar(paquete: string) {
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
    let envio = "[+QUERY]\n[+USER]" + this.data.usuario + "\n[-USER]\n[+DATA]\n" + Blockly.JavaScript.workspaceToCode(this.workspace) + "\n[-DATA]\n[-QUERY]\n";
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



}


