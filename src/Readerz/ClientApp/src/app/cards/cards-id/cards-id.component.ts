import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CardService, Card } from 'src/app/services/card.service';

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
    private cardService: CardService
    ) { 
    this.id = Number.parseInt(activatedRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    this.cardService.getByCardSet(this.id).subscribe(val => {
      console.log(val);
      this.cards = val.cards;
    });
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
