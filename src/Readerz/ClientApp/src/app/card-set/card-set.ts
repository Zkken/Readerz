import { Word } from "../word/word";

export class WordCollection {
    constructor (
        public id?: number,
        public name?: string,
        public words?: Word[],
        public userName?: string
    ) {
        this.words = [];
    }
}