import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";

@Injectable()
export class CurrentUserService {
    constructor(private client: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    }

    getCardCreatorId() {
        return this.client.get<number>(this.baseUrl + ApiUrl.CardCreator.GetId)
    }
}