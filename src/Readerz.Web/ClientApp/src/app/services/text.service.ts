import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "../app.constants";
import { Translable, TranslationResult, Languages, TextProcessingResult } from "../models/text";

@Injectable()
export class TextService {
    constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient) {
    }

    getTranslatedWord(translable: Translable) {
        let params = `?text=${translable.text}&to=${translable.to}&from=${translable.from}`;
        return this.http.get<TranslationResult>(this.baseUrl + ApiUrl.Text.Translate + params);
    }

    getSupportedLanguages() {
        return this.http.get<Languages>(this.baseUrl + ApiUrl.Text.SupportedLanguages);
    }

    getProcessed(text: string) {
        let params: string = `?text=${text}`;
        return this.http.get<TextProcessingResult>(this.baseUrl + ApiUrl.Text.Process + params);
    }
}