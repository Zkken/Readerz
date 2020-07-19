import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { WordCollectionApiUrl } from "../app.constants";
import { WordCollection } from "./word-collection";
import { Observable } from "rxjs";

@Injectable()
export class WordCollectionService {

    constructor(private client: HttpClient) {

    }

    getWordCollectionAll() {
        return this.client.get(WordCollectionApiUrl);
    }

    getWordCollectionByUser(userName: string) {
        return this.client.get(WordCollectionApiUrl + '?userName=' + userName);
    }

    updateWordCollection(wordCollection: WordCollection) {
        return this.client.put(WordCollectionApiUrl, wordCollection);
    }

    createWordCollection(wordCollection: WordCollection) {
        return this.client.post(WordCollectionApiUrl, wordCollection);
    }

    deleteWodCollection(id: number) {
        return this.client.delete(WordCollectionApiUrl + '/' + id);
    }

    getWordCollectionById(id: number) {
        return this.client.get(WordCollectionApiUrl + '/' + id);
    }
}