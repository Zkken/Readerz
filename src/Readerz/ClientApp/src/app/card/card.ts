export class Card {
    constructor(
        public id?: number, 
        public front?: string, 
        public back?: string) {

    }

    copy(card: Card) {
        this.id = card.id;
        this.front = card.front;
        this.back = card.back;
    }
}