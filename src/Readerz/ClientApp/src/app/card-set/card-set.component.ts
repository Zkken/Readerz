import { Component, OnInit } from "@angular/core";
import { WordCollectionService } from "./card-set.service";
import { AuthorizeService } from "src/api-authorization/authorize.service";
import { map, take } from "rxjs/operators";
import { Observable } from "rxjs";
import { WordCollection } from "./card-set";
import { Card } from "../card/card";

@Component({
    templateUrl: './word-collection.component.html'
})
export class WordCollectionComponent implements OnInit {
    wordCollections: WordCollection[];
    empty: boolean = false;

    constructor(
        private wordCollectionService: WordCollectionService,
        private authorizeService: AuthorizeService
    ) {

    }

    ngOnInit(): void {
        let userName: string = "";
        this.authorizeService.getUser().pipe(take(1))
            .subscribe(u => userName = u.name);

        this.wordCollectionService.getWordCollectionByUser(userName)
            .subscribe(
                (data: WordCollection[]) => {
                    this.wordCollections = data;
                },
                null,
                () => {
                    if (this.wordCollections.length == 0) {
                        this.empty = true;
                    }
                }
            );
    }
}