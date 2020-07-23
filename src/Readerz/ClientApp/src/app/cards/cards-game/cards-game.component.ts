import { Component, OnInit } from '@angular/core';
import { Card, CardService } from 'src/app/services/card.service';
import { CardSetService } from 'src/app/services/card-set.service';
import { Router, ActivatedRoute } from '@angular/router';
import { fromEvent, from, of, Subscription } from 'rxjs';
import { map, filter, delay, mergeMap } from 'rxjs/operators';
import { CardGameService, GameKey } from 'src/app/services/card-game.service';

@Component({
  selector: 'app-cards-game',
  templateUrl: './cards-game.component.html',
  styleUrls: ['./cards-game.component.css']
})
export class CardsGameComponent implements OnInit {
  cardSetId: number
  text: string
  private eventSubscription: Subscription

  constructor(
    private cardService: CardService,
    activedRoute: ActivatedRoute,
    private game: CardGameService
  ) {
    this.cardSetId = Number.parseInt(activedRoute.snapshot.params["id"]);
  }

  ngOnInit(): void {
    this.cardService.getByCardSet(this.cardSetId)
      .subscribe(
        val => { 
          this.game.cards = val.cards;
          this.game.randomize()
        },
        err => console.log(err),
        () => this.setHandler()
      );
  }

  setHandler() {
    this.eventSubscription = fromEvent(document, 'keypress').pipe(
      map((v: KeyboardEvent) => {
        return { key: v.key }
      }),
      filter(v => v.key === GameKey.Enter || v.key === GameKey.Spacebar),
    ).subscribe(v => {
      if (v.key === GameKey.Spacebar) {
        this.game.pushCurrentToEnd();
      }
      this.game.nextCard();
      if (this.game.end) {
        this.eventSubscription.unsubscribe();
      }
    })
  }

  myMouseClicked() {
    if (!this.game.end) {
      this.game.swapTextSides();
    }
  }

  //todo take and move a card with word to left or right
}

