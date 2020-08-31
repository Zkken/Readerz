import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { ApiUrl } from "../app.constants";
import { CardSet, CardSetStatus } from "../models/card-set";
import { Card } from "./card.service";

@Injectable()
export class CardSetService {
    constructor(private client: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    create(command: CreateCardSetCommand) {
        return this.client.post(this.baseUrl + ApiUrl.CardSet.Create, command);
    }

    delete(id: number) {
        return this.client.delete(this.baseUrl + ApiUrl.CardSet.Delete + "/" + id);
    }

    getCards(pageIndex: string, pageSize: string, byUser = false) {
        let params = new HttpParams()
        .set('pageIndex', pageIndex)
        .set('pageSize', pageSize);
        if(byUser) {
            params.set('byCurrentUser', 'true');
        }
        return this.client.get<CardSets>(this.baseUrl + ApiUrl.CardSet.Get, { params });
    }
}

export interface CardSets {
    data: CardSet[],
    pageIndex: number,
    pageSize: number,
    totalPages: number,
    hasPreviousPage: boolean,
    hasNextPage: boolean
}

interface CreateCardSetCommand {
    name: string,
    status: CardSetStatus,
    textId?: number,
    cards: Card[]
}