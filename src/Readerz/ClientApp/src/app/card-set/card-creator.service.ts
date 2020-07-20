import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CardCreatorApiUrl } from "../app.constants";

@Injectable()
export class CardCreatorService {
    constructor(private http: HttpClient) {

    }

    getCurrentCardCreatorId() {
        return this.http.get(CardCreatorApiUrl + '/GetCardSetIdByCurrentUserId')
    }
}