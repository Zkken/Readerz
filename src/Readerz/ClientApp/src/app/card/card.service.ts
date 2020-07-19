import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Card } from "./card";
import { WordApiUrl } from "../app.constants";

@Injectable()
export class CardService {
    constructor(private client: HttpClient) {
    }

    getWords() {
        return this.client.get(WordApiUrl);
    }

    getWord(id: number) {
        return this.client.get(WordApiUrl + '/' + id);
    }

    createWord(card: Card) {
        return this.client.post(WordApiUrl, card);
    }

    updateWord(card: Card) {
        return this.client.put(WordApiUrl, card);
    }

    deleteWord(id: number) {
        return this.client.delete(WordApiUrl + '/' + id);
    }

    getWordsByWordCollectionId(id: number) {
        return this.client.get(WordApiUrl + '/byWordCollection/' + id);
    }
}