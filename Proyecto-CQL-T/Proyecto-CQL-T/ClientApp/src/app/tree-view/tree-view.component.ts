import { Component } from '@angular/core';
import { DataService } from '../service/data.service';


@Component({
  selector: 'app-treeview',
  template: `
<h3>CQL-TEACHER</h3>
     <kendo-treeview
         [nodes]="data.data"
         kendoTreeViewExpandable

         kendoTreeViewHierarchyBinding
         childrenField="items">
       <ng-template kendoTreeViewNodeTemplate let-dataItem>
         <span [style.fontWeight]="dataItem.items ? 'bolder': 'normal' ">{{dataItem.text}}</span>
       </ng-template>
     </kendo-treeview>
   `

})
export class TreeViewComponent {

  constructor(public data: DataService) {

  }

  

}
