import { Component, OnInit } from "@angular/core";
import { CardSetService } from "./card-set.service";
import { map, take, tap, mergeMap, switchMap } from "rxjs/operators";
import { Observable, pipe, observable } from "rxjs";
import { CardSet } from "./card-set";
import { Card } from "../card/card";
import { CardCreatorService } from "./card-creator.service";
import { ThrowStmt } from "@angular/compiler";
import { HttpClient } from "@angular/common/http";

@Component({
    templateUrl: './card-set.component.html'
})
export class CardSetComponent implements OnInit {
    cardSets: Observable<CardSet[]>;
    empty: boolean = false;
    cardCreatorId: Observable<number>;

    constructor( 
        private cardSetService: CardSetService,
        private cardCreatorService: CardCreatorService,
        // private auth: AuthorizeService,
        private client: HttpClient
    ) {
    }

    ngOnInit(): void {
        this.client.get('api/card/test2').subscribe(t => console.log(t));
        this.client.get('api/card/test1').subscribe(t => console.log(t));
        this.client.get('api/test').subscribe(t => console.log(t));
        this.cardSetService.getAll().subscribe(t => console.log(t));
        this.cardCreatorService.getCurrentCardCreatorId()
            .pipe(
                take(1),
                tap((val: Observable<number>) => {
                    this.cardCreatorId = val;
                }),
                switchMap((val) => {
                    return this.cardSetService.getCardSetByCreatorId(val);
                }),
            )
            .subscribe((val: Observable<CardSet[]>) => {
                this.cardSets = val;
            }, 
            error => {
                console.log(error);
            }, 
            () => {
                this.cardSets.subscribe((val: CardSet[]) => {
                    if(val.length == 0) {
                        this.empty = true;
                    }
                })
            });
    }
}