import { CatService } from './../../services/cat.service';
import { Component, OnInit } from '@angular/core';
import { CatModel } from 'src/app/models/cat';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-catlist',
  templateUrl: './catlist.component.html',
  styleUrls: ['./catlist.component.css']
})
export class CatlistComponent implements OnInit {

  constructor(private catService: CatService, 
    private route: ActivatedRoute,
    private router: Router) { }

  cats: CatModel[];

  ngOnInit(): void {
    this.getAllCats();
  }

  getAllCats(): void {
    this.catService.getAllCats()
      .subscribe(
        data => {
          this.cats = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
