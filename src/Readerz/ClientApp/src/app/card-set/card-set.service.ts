import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { WordCollectionApiUrl } from "../app.constants";
import { CardSet } from "./card-set";
import { Observable } from "rxjs";

@Injectable()
export class CardSetService {

    constructor(private client: HttpClient) {

    }

    /**
     * getting all card sets from server
     */
    getAll() {
        return this.client.get(WordCollectionApiUrl);
    }

    /**
     * getting all card sets by current user 
     * @param userName userName of user
     */
    getCardSetByUser(userName: string) {
        return this.client.get(WordCollectionApiUrl + '?userName=' + userName);
    }

    /**
     * updating existing card set
     * @param cardSet card set object that will be updated
     */
    update(cardSet: CardSet) {
        return this.client.put(WordCollectionApiUrl, cardSet);
    }

    /**
     * creating new card set
     * @param cardSet card set object that will be created
     */
    create(cardSet: CardSet) {
        return this.client.post(WordCollectionApiUrl, cardSet);
    }

    /**
     * deleting existing card set by id property
     * @param id id of card set that will be deleted
     */
    delete(id: number) {
        return this.client.delete(WordCollectionApiUrl + '/' + id);
    }

    /**
     * getting card set by id
     * @param id id of card set
     */
    getWordCollectionById(id: number) {
        return this.client.get(WordCollectionApiUrl + '/' + id);
    }
}