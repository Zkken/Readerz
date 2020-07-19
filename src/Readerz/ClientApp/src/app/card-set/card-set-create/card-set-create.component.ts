import { Component } from "@angular/core";
import { WordCollection } from "../card-set";
import { Card } from "src/app/card/card";
import { WordCollectionService } from "../card-set.service";
import { Router } from "@angular/router";
import { AuthorizeService } from "src/api-authorization/authorize.service";
import { User } from "oidc-client";
import { take } from "rxjs/operators";

@Component({
    templateUrl: './word-collection-create.component.html'
})
export class WordCollectionCreateComponent{
    wordCollection: WordCollection = new WordCollection();
    word: Card = new Card()

    constructor(
        private wordCollectionService: WordCollectionService,
        private router: Router,
        private authorizeService: AuthorizeService
        ) {
        this.wordCollection.words.push(new Card(undefined, "Учитель", "Teacher")); //delete
    }

    addWord() {
        this.wordCollection.words.push(this.word);
        this.word = new Card();
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