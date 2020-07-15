import { Component, OnInit } from '@angular/core';
import { WordService } from './word.service';
import { Word } from './word';

@Component({
    selector: 'words',
    templateUrl: './word-list.component.html',
    providers: [WordService]
})
export class WordListComponent implements OnInit {
    words: Word[];

    constructor(private wordService: WordService) {

    }

    ngOnInit(): void {
        this.loadWords();
    }

    loadWords() {
        this.wordService.getWords().subscribe((data: Word[]) => this.words = data);
    }

    delete(id: number) {
        this.wordService.deleteWord(id).subscribe(_ => this.loadWords());
    }
}