import { Component } from "@angular/core";
import { CardSet } from "../card-set";
import { Card } from "src/app/card/card";
import { CardSetService } from "../card-set.service";
import { Router } from "@angular/router";
import { User } from "oidc-client";
import { take } from "rxjs/operators";

@Component({
    templateUrl: './card-set-create.component.html'
})
export class CardSetCreateComponent{
    cardSet: CardSet = new CardSet();
    card: Card = new Card()

    constructor(
        private wordCollectionService: CardSetService,
        private router: Router
        ) {
    }

    // addCard() {
    //     this.cardSet.words.push(this.card);
    //     this.card = new Card();
    // }

    // save() {
    //     this.authorizeService.getUser()
    //         .pipe(take(1))
    //         .subscribe(user => this.cardSet.userName = user.name);
    //     this.wordCollectionService.createWordCollection(this.cardSet)
    //         .subscribe(_ => this.router.navigateByUrl("/wordCollection"));
    // }

    // deleteCard(index: number) {
    //     this.cardSet.words.splice(index, 1);
    // }
}