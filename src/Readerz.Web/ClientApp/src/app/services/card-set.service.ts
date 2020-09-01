import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { ApiUrl } from "../app.constants";
import { CardSets, CreateCardSetCommand, UpdateCardSetCommand, CardSetDetail } from "../models/card-set";

@Injectable()
export class CardSetService {
    constructor(private client: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    create(command: CreateCardSetCommand) {
        return this.client.post<number>(this.baseUrl + ApiUrl.CardSet.Create, command);
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

    getDetail(id: number) {
        return this.client.get<CardSetDetail>(this.baseUrl + ApiUrl.CardSet.GetDetail + "/" + id);
    }

    update(command: UpdateCardSetCommand) {
        return this.client.put(this.baseUrl + ApiUrl.CardSet.Update, command);
    }
}