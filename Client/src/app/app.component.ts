import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'CatMash';
  items: MenuItem[];

  ngOnInit(): void {
    this.items = [
      {
        label: 'Sondage',
        items: [{
          label: 'Meilleur chat',
          icon: 'pi pi-fw pi-star',
          items: [
            { label: 'Voter', icon: 'pi pi-fw pi-star', routerLink: ['/catvote'] },
            { label: 'Voir le classement', icon: 'pi pi-fw pi-sort-amount-down', routerLink: ['/catlist'] }
          ]
        }
        ]
      }
    ];
  }
}
