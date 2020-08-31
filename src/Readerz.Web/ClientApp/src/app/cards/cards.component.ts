import { Component, OnInit} from '@angular/core';
import { CardSetService } from '../services/card-set.service';
import { CardSet } from '../models/card-set';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./card.component.css']
})
export class CardsComponent implements OnInit {
  cardSets: CardSet[];

  constructor(
    private cardSetService: CardSetService
  ) {
  }

  ngOnInit() {
    this.loadCardSets();
  }

  private loadCardSets() {
    this.cardSetService.getCards('0', '10', true).subscribe(result => {
      this.cardSets = result.data;
    }, err => console.log(err));
  } 

  delete(id: number) {
    this.cardSetService.delete(id).subscribe(
      () => this.loadCardSets(), 
      err => console.log(err));
  }
}

//TODO add mat-table
