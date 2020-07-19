export class Card {
    constructor(
        public id?: number, 
        public textTranslated?: string, 
        public textUntranslated?: string) {

    }

    copy(card: Card) {
        this.id = card.id;
        this.textTranslated = card.textTranslated;
        this.textUntranslated = card.textUntranslated;
    }
}