import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";

@Injectable()
export class CardService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string
        ) {

    }

    getByCardSet(id: number) {
        return this.http.get<CardGetCommand>(this.baseUrl + ApiUrl.Card.ByCardSetId + "/" + id);
    }

    deleteCard(id: number) {
        return this.http.delete(this.baseUrl + ApiUrl.Card.Delete + "/" + id);
    }

    updateCard(card: Card) {
        return this.http.put(this.baseUrl + ApiUrl.Card.Update, card);
    }
}

interface CardGetCommand {
    cards: Card[]
}

export class Card {
    constructor (
        public id?: number,
        public front?: string,
        public  back?: string
        ) {

    }
}