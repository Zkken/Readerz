import { Component, Input, OnInit } from "@angular/core";
import { WordCollectionService } from "../word-collection.service";
import { Word } from "src/app/word/word";
import { WordService } from "src/app/word/word.service";
import { WordCollection } from "../word-collection";
import { Router, ActivatedRoute } from "@angular/router";
import { fromEvent, from, Observable } from "rxjs";
import { map, switchMap, tap, filter, mergeMap, combineAll, concatMap } from "rxjs/operators";
import { fileURLToPath } from "url";
import { typeWithParameters } from "@angular/compiler/src/render3/util";

@Component({
    selector: 'word-game',
    templateUrl: './word-collection-game.component.html'
})
export class WordCollectionGameComponent implements OnInit {
    words: Word[]
    wordCollectionId: number
    word: Word = new Word()
    currentWord: number
    currentLength: number

    constructor(
        private wordCollectionService: WordCollectionService,
        private wordService: WordService,
        private router: Router,
        private activedRoute: ActivatedRoute
    ) {
        this.wordCollectionId = Number.parseInt(activedRoute.snapshot.params["id"]);
    }

    ngOnInit(): void {
        this.wordService.getWordsByWordCollectionId(this.wordCollectionId)
            .subscribe(
                (data: Word[]) => this.words = data,
                null,
                () => {
                    this.word = this.words[0];
                    this.currentLength = this.words.length;
                    this.currentWord = 0;
                    this.setHandler();
                }
            );
    }

    setHandler() {
        fromEvent(document, 'keypress').pipe(
            map((v: KeyboardEvent) => {
                return { key: v.key }
            }),
            filter(v => v.key === 'Enter' || v.key === ' '),
        )
            .subscribe(v => {
                if (v.key === ' ') {
                    this.words.push(this.words[this.currentWord]);
                }

                if (this.currentWord + 1 == this.currentLength) {
                    this.words.splice(0, this.currentLength);
                    this.currentLength = this.words.length;
                    this.currentWord = 0;
                } else {
                    this.currentWord++;
                }
                this.word = this.words[this.currentWord];
            },
                null,
                () => {
                    // ДОБАВИТЬ КОНЦОВКУ ИГРЫ 
                }
            )
    }




    //todo take and move a card with word to left or right
}