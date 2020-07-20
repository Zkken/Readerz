import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CardSetApiUrl } from "../app.constants";
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
        return this.client.get(CardSetApiUrl + "/All");
    }

    /**
     * getting all card sets by current user 
     * @param userName userName of user
     */
    getCardSetByUser(userName: string) {
        return this.client.get(CardSetApiUrl + '?userName=' + userName);
    }

    /**
     * updating existing card set
     * @param cardSet card set object that will be updated
     */
    update(cardSet: CardSet) {
        return this.client.put(CardSetApiUrl, cardSet);
    }

    /**
     * creating new card set
     * @param cardSet card set object that will be created
     */
    create(cardSet: CardSet) {
        return this.client.post(CardSetApiUrl, cardSet);
    }

    /**
     * deleting existing card set by id property
     * @param id id of card set that will be deleted
     */
    delete(id: number) {
        return this.client.delete(CardSetApiUrl + '/' + id);
    }

    /**
     * getting card set by id
     * @param id id of card set
     */
    getCardSetById(id: number) {
        return this.client.get(CardSetApiUrl + '/' + id);
    }

    getCardSetByCreatorId(id: Observable<number>) {
        return this.client.get(CardSetApiUrl + '/byCreator/' + id)
    }
}