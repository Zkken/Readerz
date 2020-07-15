export class Word {
    constructor(
        public id?: number, 
        public textTranslated?: string, 
        public textUntranslated?: string) {

    }

    copy(word: Word) {
        this.id = word.id;
        this.textTranslated = word.textTranslated;
        this.textUntranslated = word.textUntranslated;
    }
}