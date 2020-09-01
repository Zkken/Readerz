import { Component, OnInit } from '@angular/core';
import { CardSetService } from 'src/app/services/card-set.service';
import { ActivatedRoute } from '@angular/router';
import { fromEvent, Subscription } from 'rxjs';
import { map, filter} from 'rxjs/operators';
import { CardGameService, GameKey } from 'src/app/services/card-game.service';

@Component({
  selector: 'app-cards-game',
  templateUrl: './cards-game.component.html',
  styleUrls: ['./cards-game.component.css']
})
export class CardsGameComponent implements OnInit {
  cardSetId: number
  text: string
  private eventSubscription: Subscription

  constructor(
    activedRoute: ActivatedRoute,
    private cardGameService: CardGameService,
    private cardSetService: CardSetService
  ) {
    this.cardSetId = Number.parseInt(activedRoute.snapshot.params["id"]);
  }

  ngOnInit(): void {
    this.cardSetService.getDetail(this.cardSetId)
      .subscribe(result => { 
          this.cardGameService.cards = result.cards;
          this.cardGameService.randomize()
        }, err => console.log(err), () => this.setHandler());
  }

  setHandler() {
    this.eventSubscription = fromEvent(document, 'keypress').pipe(
      map((keyEvent: KeyboardEvent) => {
        return { key: keyEvent.key }
      }),
      filter(keyEvent => keyEvent.key === GameKey.Enter || keyEvent.key === GameKey.Spacebar),
    ).subscribe(keyEvent => {
      if (keyEvent.key === GameKey.Spacebar) {
        this.cardGameService.pushCurrentToEnd();
      }
      this.cardGameService.nextCard();
      if (this.cardGameService.end) {
        this.eventSubscription.unsubscribe();
      }
    })
  }

  myMouseClicked() {
    if (!this.cardGameService.end) {
      this.cardGameService.swapTextSides();
    }
  }
}

