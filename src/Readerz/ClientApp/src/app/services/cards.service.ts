import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";
import { CardSet } from "../models/card-set";

@Injectable()
export class CardSetService {
    constructor(private client: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    getAllByCardCreatorId(id?: number) {
        return this.client.get<CardSet[]>(this.baseUrl + ApiUrl.CardSet.ByCreatorId + "/" + id);
    }
}