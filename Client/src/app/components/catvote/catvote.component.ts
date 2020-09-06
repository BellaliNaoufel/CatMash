import { Component, OnInit } from '@angular/core';
import { CatService } from 'src/app/services/cat.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CatModel } from 'src/app/models/cat';

@Component({
  selector: 'app-catvote',
  templateUrl: './catvote.component.html',
  styleUrls: ['./catvote.component.css']
})
export class CatvoteComponent implements OnInit {

  constructor(private catService: CatService, 
    private route: ActivatedRoute,
    private router: Router) { }
    
    twoCats: CatModel[];

  ngOnInit(): void {
    this.getRandomTwoCats();
  }

  getRandomTwoCats(): void {
    this.catService.getRandomTwoCats()
      .subscribe(
        data => {
          this.twoCats = data
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  voteCat(cat: CatModel): void {
    cat.score++;
    this.catService.updateCat(cat)
    .subscribe(
      data => {
        this.router.navigate(['catlist']);
      },
      error => {
        console.log(error);
      });
  }

}
