export class UnknownText {
    constructor(
        public innerText?: string, 
        public id?: number,
        public name?: string 
        ) {

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