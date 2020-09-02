import { Component, OnInit } from '@angular/core';
import { CardService } from 'src/app/services/card.service';
import { Router } from '@angular/router';
import { CardSet } from 'src/app/models/card-set';
import { CardSetService } from 'src/app/services/card-set.service';
import { Card } from 'src/app/models/card';
import { switchMap } from 'rxjs/operators';
import { FormBuilder, Validators } from '@angular/forms';
import { fromEvent } from 'rxjs';
import { filter } from 'rxjs/operators';
import { GameKey } from 'src/app/services/card-game.service';

@Component({
  selector: 'app-cards-create',
  templateUrl: './cards-create.component.html',
  styleUrls: ['./cards-create.component.css']
})
export class CardsCreateComponent implements OnInit {
  cards: Card[];
  card: Card;
  cardSet: CardSet;

  cardSetForm = this.formBuilder.group({
    select: ['', [Validators.required]],
    cardSetName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
    front: ['', [Validators.required, Validators.maxLength(50)]],
    back: ['', [Validators.required, Validators.maxLength(50)]]
  })

  constructor(
    private cardSetService: CardSetService,
    private router: Router,
    private cardService: CardService,
    public formBuilder: FormBuilder
  ) {
    this.cards = [];
    this.cardSet = new CardSet();
    this.card = new Card();
  }

  get select() {
    return this.cardSetForm.get('select');
  }

  get cardSetName() {
    return this.cardSetForm.get('cardSetName');
  }

  get back() {
    return this.cardSetForm.get('back');
  }

  get front() {
    return this.cardSetForm.get('front');
  }

  ngOnInit() {
    fromEvent(document, 'keypress').pipe(
      filter((keyEvent: KeyboardEvent) => keyEvent.key === GameKey.Enter)
    )
    .subscribe(() => {
      this.add();
    })
  }

  add() {
    if(this.front.invalid || this.back.invalid) {
      return;
    }
    this.front.setValue('');
    this.front.markAsUntouched();
    this.back.setValue('');
    this.back.markAsUntouched();
    this.cards.push(this.card);
    this.card = new Card();
  }

  delete(index: number) {
    this.cards.splice(index, 1);
  }

  save() {
    this.cardSetService.create({
      name: this.cardSet.name,
      status: this.cardSet.status,
    })
      .pipe(
        switchMap(result => {
          return this.cardService.createRange({
            cards: this.cards,
            cardSetId: result
          })
        })
      ).subscribe(() => this.router.navigateByUrl("/cards"));
  }
}
