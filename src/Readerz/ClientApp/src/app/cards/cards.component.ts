import { Component, OnInit, Inject } from '@angular/core';
import { CardSetService, GetCardSetCommand } from '../services/card-set.service';
import { CardSet } from '../models/card-set';
import { CurrentUserService } from '../services/current-user-service';
import { switchMap } from 'rxjs/operators';
import { of } from 'rxjs';
import { Card } from '../services/card.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./card.component.css']
})
export class CardsComponent implements OnInit {
  cardSets: CardSet[];

  constructor(
    private cardSetService: CardSetService,
    private currentUserService: CurrentUserService
  ) {
  }

  ngOnInit() {
    this.loadCardSets();
  }

  private loadCardSets() {
    this.currentUserService.getCardCreatorId().pipe(
      switchMap(val => {
        if(val === null) {
          return of({ cardSetDtos: []});
        }
        return this.cardSetService.getAllByCardCreatorId(val);
      })
    ).subscribe(val => {
      console.log(val.cardSetDtos);
      this.cardSets = val.cardSetDtos;
    }, err => console.log(err));
  }

  delete(id: number) {
    this.cardSetService.delete(id).subscribe(
      val => {
        console.log(val);
        this.cardSets = undefined;
        this.loadCardSets();
      },
      err => console.log(err)
    )
  }
}
