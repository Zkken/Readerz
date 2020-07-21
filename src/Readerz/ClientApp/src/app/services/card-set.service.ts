import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";
import { CardSet } from "../models/card-set";
import { Card } from "./card.service";

@Injectable()
export class CardSetService {
    constructor(private client: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    getAllByCardCreatorId(id?: number) {
        return this.client.get<GetCardSetCommand>(this.baseUrl + ApiUrl.CardSet.ByCreatorId + "/" + id);
    }

    create(command: CreateCardSetCommand) {
        return this.client.post(this.baseUrl + ApiUrl.CardSet.Create, command);
    }
}
interface GetCardSetCommand {
    cardSetDtos: CardSet[]
}

interface CreateCardSetCommand {
    cardCreatorId: number,
    name: string,
    status: CardSetStatus,
    textId?: number,
    cards: Card[]
}

enum CardSetStatus {
    Private = 0,
    Public = 1
}