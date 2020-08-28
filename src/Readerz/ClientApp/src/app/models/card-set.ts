export class CardSet {
    constructor(
        public id?: number,
        public name?: string,
        public status?: CardSetStatus,
        public like?: number,
        public dislike?: number,
        public timesPlayed?: number 
        ) {

        }
}

export enum CardSetStatus {
    Private = "Private",
    Public = "Public"
}