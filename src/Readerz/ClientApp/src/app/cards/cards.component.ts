import { Component, OnInit, Inject } from '@angular/core';
import { CardSetService } from '../services/cards.service';
import { CardSet } from '../models/card-set';
import { CurrentUserService } from '../services/current-user-service';
import { switchMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  cardSets: CardSet[];

  constructor(
    private cardSetService: CardSetService,
    private currentUserService: CurrentUserService,
  ) {
  }

  ngOnInit() {
    this.loadCardSets();
  }

  private loadCardSets() {
    this.currentUserService.getCardCreatorId().pipe(
      switchMap(val => {
        return this.cardSetService.getAllByCardCreatorId(val);
      })
    ).subscribe(val => {
      this.cardSets = val;
    }, err => console.log(err));
  }
}
