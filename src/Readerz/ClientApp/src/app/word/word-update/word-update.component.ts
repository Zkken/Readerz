import { Component, OnInit } from "@angular/core";
import { WordService } from "../word.service";
import { Word } from "../word";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    templateUrl: './word-update.component.html'
})
export class WordUpdateComponent implements OnInit {
    word: Word;
    id: number;
    loaded: boolean = false;

    constructor (
        private wordService: WordService, 
        private router: Router, 
        public activeRoute: ActivatedRoute) {
            this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    ngOnInit(): void {
        if(this.id) {
            this.wordService.getWord(this.id)
                .subscribe((data: Word) => {
                    this.word = data;
                    if (this.word != null) {
                        this.loaded = true;
                    }
                })
        }
    }

    save() {
        this.wordService.updateWord(this.word)
            .subscribe(data => this.router.navigateByUrl("/word"));
    }
}