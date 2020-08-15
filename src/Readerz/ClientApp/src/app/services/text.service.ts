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

export interface Languages {
    languages: Language[]
}

export interface Language {
    iso: string,
    name: string
}

export interface Translable {
    text: string,
    from?: string,
    to: string
}

export interface TranslationResult {
    translations: string[]
}

export interface TextProcessingResult {
    text: TextItem[]
}

export interface TextItem {
    isWord: boolean,
    value: string
}