import { Component, OnInit } from "@angular/core";
import { CardSetService } from "./card-set.service";
import { AuthorizeService } from "src/api-authorization/authorize.service";
import { map, take } from "rxjs/operators";
import { Observable } from "rxjs";
import { CardSet } from "./card-set";
import { Card } from "../card/card";

@Component({
    templateUrl: './card-set.component.html'
})
export class CardSetComponent implements OnInit {
    cardSets: CardSet[];
    empty: boolean = false;

    constructor(
        private cardSetService: CardSetService,
        private authorizeService: AuthorizeService
    ) {

    }

    ngOnInit(): void {
        let userName: string = "";
        this.authorizeService.getUser().pipe(take(1))
            .subscribe(u => userName = u.name);

        this.cardSetService.getCardSetByUser(userName)
            .subscribe(
                (data: CardSet[]) => {
                    this.cardSets = data;
                },
                null,
                () => {
                    if (this.cardSets.length == 0) {
                        this.empty = true;
                    }
                }
            );
    }
}