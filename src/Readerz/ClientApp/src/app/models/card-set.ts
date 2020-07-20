export class CardSet {
    constructor(
        public id?: number,
        public name?: string,
        public status?: CardSetStatus 
        ) {

        }
}

enum CardSetStatus {
    Private = 0,
    Public = 1
}