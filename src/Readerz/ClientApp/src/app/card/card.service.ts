import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Card } from "./card";
import { WordApiUrl } from "../app.constants";

@Injectable()
export class CardService {
    constructor(private client: HttpClient) {
    }

    getCards() {
        return this.client.get(WordApiUrl);
    }

    getCard(id: number) {
        return this.client.get(WordApiUrl + '/' + id);
    }

    createCard(card: Card) {
        return this.client.post(WordApiUrl, card);
    }

    updateCard(card: Card) {
        return this.client.put(WordApiUrl, card);
    }

    deleteCard(id: number) {
        return this.client.delete(WordApiUrl + '/' + id);
    }

    getCardsBySetId(id: number) {
        return this.client.get(WordApiUrl + '/byWordCollection/' + id);
    }
}