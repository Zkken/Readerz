import { Component, OnInit, Input } from '@angular/core';
import { CardService, Card } from 'src/app/services/card.service';
import { Router } from '@angular/router';
import { CardSet } from 'src/app/models/card-set';
import { CardSetService } from 'src/app/services/card-set.service';
import { CurrentUserService } from 'src/app/services/current-user.service';

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
    private router: Router
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
    const command = {
      name: this.cardSet.name,
      status: this.cardSet.status,
      cards: this.cards
    }
    this.cardSetService.create(command)
      .subscribe(val => {
        this.router.navigateByUrl("/cards/" + val)
      });
  }

}
