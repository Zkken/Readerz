import { Component, OnInit, Input } from '@angular/core';
import { CardService } from 'src/app/services/card.service';
import { Router } from '@angular/router';
import { CardSet } from 'src/app/models/card-set';
import { CardSetService } from 'src/app/services/card-set.service';
import { Card } from 'src/app/models/card';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-cards-create',
  templateUrl: './cards-create.component.html',
  styleUrls: ['./cards-create.component.css']
})
export class CardsCreateComponent implements OnInit {
  cards: Card[]
  card: Card
  cardSet: CardSet

  constructor(
    private cardSetService: CardSetService,
    private router: Router,
    private cardService: CardService
  ) {
    this.cards = [];
    this.cardSet = new CardSet();
    this.card = new Card();
  }

  ngOnInit() {
  }

  add() {
    this.cards.push(this.card);
    this.card = new Card();
  }

  delete(index: number) {
    this.cards.splice(index, 1);
  }

  save() {
    this.cardSetService.create({
      name: this.cardSet.name,
      status: this.cardSet.status,
    })
      .pipe(
        switchMap(result => {
          return this.cardService.createRange({
            cards: this.cards,
            cardSetId: result
          })
        })
      ).subscribe(() => this.router.navigateByUrl("/cards"));
  }
}
