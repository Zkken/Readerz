import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Card } from "./card";
import { CardApiUrl } from "../app.constants";

@Injectable()
export class CardService {
    constructor(private client: HttpClient) {
    }

    getCards() {
        return this.client.get(CardApiUrl);
    }

    getCard(id: number) {
        return this.client.get(CardApiUrl + '/' + id);
    }

    createCard(card: Card) {
        return this.client.post(CardApiUrl, card);
    }

    updateCard(card: Card) {
        return this.client.put(CardApiUrl, card);
    }

    deleteCard(id: number) {
        return this.client.delete(CardApiUrl + '/' + id);
    }

    getCardsBySetId(id: number) {
        return this.client.get(CardApiUrl + '/byWordCollection/' + id);
    }
}