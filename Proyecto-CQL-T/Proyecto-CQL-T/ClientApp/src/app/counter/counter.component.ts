import { Component } from '@angular/core';
import { DataService } from '../service/data.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  constructor(public data: DataService) {

  }
  public incrementCounter() {
    this.currentCount++;
  }

  public chagedata() {
    this.data.data = [
      {
        text: "Cambio",
        items: [{ text: "Read Mail Cambio" }]
      },
      {
        text: "Drafts",
        items: [{text: "item change"}]
      },
      {
        text: "Search Folders",
        items: [
          { text: "Categorized Mail" },
          { text: "Large Mail" },
          { text: "Unread Mail" }
        ]
      },
      { text: "Settings" }
    ];

  }
}
