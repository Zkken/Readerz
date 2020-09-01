import { Card } from "../models/card";

export class CardGame {
    private _cards: Card[];
    private _currentCard: Card;
    private _currentCardSide: CardSide;
    end: boolean = false;
    currentLength: number;
    currentCardIndex: number;

    constructor(value: Card[]) {
        this._cards = value;
        this._currentCard = value[0];
        this._currentCardSide = CardSide.Front;
        this.currentLength = value.length;
        this.currentCardIndex = 0;
    }

    get text() {
        if(!this._currentCard) {
            return "Loading";
        }
        return this._currentCard[this._currentCardSide];
    }

    pushCurrentToEnd() {
        this._cards.push(this._cards[this.currentCardIndex]);
    }

    nextCard() {
        if (this.currentCardIndex + 1 == this.currentLength) {
            this._cards.splice(0, this.currentLength);
            this.currentLength = this._cards.length;
            this.currentCardIndex = 0;
        } else {
            this.currentCardIndex++;
        }

        if (this.currentLength === 0) {
            this.end = true;
        }

        this._currentCard = this._cards[this.currentCardIndex];
    }

    swapTextSides() {
        this._currentCardSide = this._currentCardSide === CardSide.Front ? CardSide.Back : CardSide.Front;
    }

    randomize() {
        let c: number = this._cards.length;

        while(c > 0) {
            let index = Math.floor(Math.random() * c);
            c--;
            [this._cards[c], this._cards[index]] = [this._cards[index], this._cards[c]];
        }
    }
}

export enum CardSide {
    Front = "front", Back = "back"
}

export enum GameKey {
    Enter = "Enter",
    Spacebar = " "
}