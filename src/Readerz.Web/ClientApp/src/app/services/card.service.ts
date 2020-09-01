import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";
import { Card, CardCreateCommand } from "../models/card";

@Injectable()
export class CardService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string
        ) {

    }

    deleteCard(id: number) {
        return this.http.delete(this.baseUrl + ApiUrl.Card.Delete + "/" + id);
    }

    updateCard(card: Card) {
        return this.http.put(this.baseUrl + ApiUrl.Card.Update, card);
    }

    createRange(command: CardCreateCommand) {
        return this.http.post(this.baseUrl + ApiUrl.Card.CreateRange, command);
    }
}

