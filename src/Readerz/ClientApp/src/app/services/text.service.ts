import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";

@Injectable()
export class TextService {
    constructor(@Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) {

    }

    getText(id: number) {
    
    }

    translateWord(translable: ITranslable) {
        let params = `?text=${translable.text}&to=${translable.to}&from=${translable.from}`;
        return this.http.get<ITranslationResult>(this.baseUrl + ApiUrl.Text.Translate + params);
    }
}

export interface ITranslable {
    text: string,
    from?: string,
    to: string
}

export interface ITranslationResult {
    translation: string
}