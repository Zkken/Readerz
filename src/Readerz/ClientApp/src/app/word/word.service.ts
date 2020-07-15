import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Word } from "./word";
import { WordApiUrl } from "../app.constants";

@Injectable()
export class WordService {
    constructor(private client: HttpClient) {
    }

    getWords() {
        return this.client.get(WordApiUrl);
    }

    getWord(id: number) {
        return this.client.get(WordApiUrl + '/' + id);
    }

    createWord(word: Word) {
        return this.client.post(WordApiUrl, word);
    }

    updateWord(word: Word) {
        return this.client.put(WordApiUrl, word);
    }

    deleteWord(id: number) {
        return this.client.delete(WordApiUrl + '/' + id);
    }

    getWordsByWordCollectionId(id: number) {
        return this.client.get(WordApiUrl + '/byWordCollection/' + id);
    }
}