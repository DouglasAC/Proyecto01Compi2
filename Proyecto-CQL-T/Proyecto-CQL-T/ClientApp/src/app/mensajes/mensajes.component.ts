import { Component } from '@angular/core';
import { DataService } from '../service/data.service';


@Component({
  selector: 'app-mensajes',
  templateUrl: './mensajes.component.html',
  styleUrls: ['./mensajes.component.css']
})
export class MensajesComponent {



  constructor(public data: DataService) {
    
  }



}
