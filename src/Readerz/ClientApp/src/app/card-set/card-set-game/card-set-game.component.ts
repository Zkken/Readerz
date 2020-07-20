import { Component, Input, OnInit } from "@angular/core";
import { CardSetService } from "../card-set.service";
import { Card } from "../../card/card";
import { CardService } from "src/app/card/card.service";
import { CardSet } from "../card-set";
import { Router, ActivatedRoute } from "@angular/router";
import { fromEvent, from, Observable } from "rxjs";
import { map, tap, filter, mergeMap, combineAll, concatMap } from "rxjs/operators";

@Component({
    selector: 'card-game',
    templateUrl: './card-set-game.component.html'
})
export class CardSetGameComponent implements OnInit {
    cards: Card[]
    cardSetId: number
    card: Card = new Card()
    currentCard: number
    currentLength: number

    constructor(
        private cardSetService: CardSetService,
        private cardService: CardService,
        private router: Router,
        private activedRoute: ActivatedRoute
    ) {
        this.cardSetId = Number.parseInt(activedRoute.snapshot.params["id"]);
    }

    ngOnInit(): void {
        this.cardService.getCardsBySetId(this.cardSetId)
            .subscribe(
                (data: Card[]) => this.cards = data,
                null,
                () => {
                    this.card = this.cards[0];
                    this.currentLength = this.cards.length;
                    this.currentCard = 0;
                    this.setHandler();
                }
            );
    }

    setHandler() {
        fromEvent(document, 'keypress').pipe(
            map((v: KeyboardEvent) => {
                return { key: v.key }
            }),
            filter(v => v.key === 'Enter' || v.key === ' '),
        )
            .subscribe(v => {
                if (v.key === ' ') {
                    this.cards.push(this.cards[this.currentCard]);
                }

                if (this.currentCard + 1 == this.currentLength) {
                    this.cards.splice(0, this.currentLength);
                    this.currentLength = this.cards.length;
                    this.currentCard = 0;
                } else {
                    this.currentCard++;
                }
                this.card = this.cards[this.currentCard];
            },
                null,
                () => {
                    // ДОБАВИТЬ КОНЦОВКУ ИГРЫ 
                }
            )
    }




    //todo take and move a card with word to left or right
}