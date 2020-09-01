import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CardService } from 'src/app/services/card.service';
import { Card } from 'src/app/models/card';
import { CardSetService } from 'src/app/services/card-set.service';

@Component({
  selector: 'app-cards-id',
  templateUrl: './cards-id.component.html',
  styleUrls: ['./cards-id.component.css']
})
export class CardsIdComponent implements OnInit {
  id: number
  cards: Card[]
  
  constructor(
    activatedRoute: ActivatedRoute,
    private cardService: CardService,
    private cardSetService: CardSetService
    ) { 
    this.id = Number.parseInt(activatedRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    this.cardSetService.getDetail(this.id).subscribe(result => {
      this.cards = result.cards;
    })
  }

  game() {
    //Todo game
  }

  delete(id: number) {
    this.cardService.deleteCard(id).subscribe(
      //Todo create alert for operation success
    );
  }
}
