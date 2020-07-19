import { Component, OnInit } from "@angular/core";
import { CardService } from "../card.service";
import { Card } from "../card";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    templateUrl: './card-update.component.html'
})
export class CardUpdateComponent implements OnInit {
    card: Card;
    id: number;
    loaded: boolean = false;

    constructor (
        private cardService: CardService, 
        private router: Router, 
        public activeRoute: ActivatedRoute) {
            this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    ngOnInit(): void {
        if(this.id) {
            this.cardService.getCard(this.id)
                .subscribe((data: Card) => {
                    this.card = data;
                    if (this.card != null) {
                        this.loaded = true;
                    }
                })
        }
    }

    save() {
        this.cardService.updateCard(this.card)
            .subscribe(data => this.router.navigateByUrl("/word"));
    }
}