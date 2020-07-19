import { Component, OnInit } from '@angular/core';
import { CardService } from './card.service';
import { Card } from './card';

@Component({
    selector: 'cards',
    templateUrl: './card-list.component.html',
    providers: [CardService]
})
export class CardListComponent implements OnInit {
    cards: Card[];

    constructor(private cardService: CardService) {

    }

    ngOnInit(): void {
        this.loadCards();
    }

    loadCards() {
        this.cardService.getCards().subscribe((data: Card[]) => this.cards = data);
    }

    delete(id: number) {
        this.cardService.deleteCard(id).subscribe(_ => this.loadCards());
    }
}