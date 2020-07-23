import { Component, OnInit } from '@angular/core';
import { Card, CardService } from 'src/app/services/card.service';
import { CardSetService } from 'src/app/services/card-set.service';
import { Router, ActivatedRoute } from '@angular/router';
import { fromEvent, from, of, Subscription } from 'rxjs';
import { map, filter, delay, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-cards-game',
  templateUrl: './cards-game.component.html',
  styleUrls: ['./cards-game.component.css']
})
export class CardsGameComponent implements OnInit {
  cardSetId: number
  text: string
  game: CardGameProvider
  private eventSubscription: Subscription

  constructor(
    private cardService: CardService,
    activedRoute: ActivatedRoute
  ) {
    this.cardSetId = Number.parseInt(activedRoute.snapshot.params["id"]);
  }

  ngOnInit(): void {
    this.cardService.getByCardSet(this.cardSetId)
      .subscribe(
        val => this.game = new CardGameProvider(val.cards),
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

class CardGameProvider {
  cards: Card[];
  currentCard: Card;
  currentLength: number;
  currentCardIndex: number;
  currentCardSide: CardSide;
  end: boolean = false;

  constructor(cards: Card[]) {
    this.cards = cards;
    this.currentCard = cards[0];
    this.currentLength = this.cards.length;
    this.currentCardIndex = 0;
    this.currentCardSide = CardSide.Front;
  }

  pushCurrentToEnd() {
    this.cards.push(this.cards[this.currentCardIndex]);
  }

  nextCard() {
    if (this.currentCardIndex + 1 == this.currentLength) {
      this.cards.splice(0, this.currentLength);
      this.currentLength = this.cards.length;
      this.currentCardIndex = 0;
    } else {
      this.currentCardIndex++;
    }

    if (this.currentLength === 0) {
      this.end = true;
    }

    this.currentCard = this.cards[this.currentCardIndex];
  }

  get text() {
    return this.currentCard[this.currentCardSide];
  }

  swapTextSides() {
    this.currentCardSide = this.currentCardSide === CardSide.Front ? CardSide.Back : CardSide.Front;
  }
}

enum CardSide {
  Front = "front", Back = "back"
}
enum GameKey {
  Enter = "Enter",
  Spacebar = " "
}

