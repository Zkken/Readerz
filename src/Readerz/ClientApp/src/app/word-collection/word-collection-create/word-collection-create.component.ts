import { Component } from "@angular/core";
import { WordCollection } from "../word-collection";
import { Word } from "src/app/word/word";
import { WordCollectionService } from "../word-collection.service";
import { Router } from "@angular/router";
import { AuthorizeService } from "src/api-authorization/authorize.service";
import { User } from "oidc-client";
import { take } from "rxjs/operators";

@Component({
    templateUrl: './word-collection-create.component.html'
})
export class WordCollectionCreateComponent{
    wordCollection: WordCollection = new WordCollection();
    word: Word = new Word()

    constructor(
        private wordCollectionService: WordCollectionService,
        private router: Router,
        private authorizeService: AuthorizeService
        ) {
        this.wordCollection.words.push(new Word(undefined, "Учитель", "Teacher")); //delete
    }

    addWord() {
        this.wordCollection.words.push(this.word);
        this.word = new Word();
    }

    save() {
        this.authorizeService.getUser()
            .pipe(take(1))
            .subscribe(user => this.wordCollection.userName = user.name);
        this.wordCollectionService.createWordCollection(this.wordCollection)
            .subscribe(_ => this.router.navigateByUrl("/wordCollection"));
    }

    deleteWord(index: number) {
        this.wordCollection.words.splice(index, 1);
    }
}