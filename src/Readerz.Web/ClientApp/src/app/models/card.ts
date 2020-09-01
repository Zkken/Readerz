export class Card {
    constructor (
        public id?: number,
        public front?: string,
        public  back?: string
        ) {

    }
}

export interface CardGetCommand {
    cards: Card[]
}

export interface CardCreateCommand {
    cardSetId: number,
    cards: Card[]
}