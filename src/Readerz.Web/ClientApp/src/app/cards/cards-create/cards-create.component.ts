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
import { BaseFormComponent } from 'src/app/models/base.form.component';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-cards-create',
  templateUrl: './cards-create.component.html',
  styleUrls: ['./cards-create.component.css']
})
export class CardsCreateComponent extends BaseFormComponent implements OnInit {
  cards: Card[];

  faTrash = faTrash;

  form = this.formBuilder.group({
    cardSetStatus: ['', [Validators.required]],
    cardSetName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
    front: ['', [Validators.required, Validators.maxLength(50)]],
    back: ['', [Validators.required, Validators.maxLength(50)]]
  })

  constructor(
    private cardSetService: CardSetService,
    private router: Router,
    private cardService: CardService,
    public formBuilder: FormBuilder,
  ) {
    super();
    this.cards = [];
  }

  ngOnInit() {
    fromEvent(document, 'keypress').pipe(
      filter((keyEvent: KeyboardEvent) => keyEvent.key === GameKey.Enter)
    )
    .subscribe(() => {
      this.add();
    })

    this.setValue('cardSetStatus', 0);
  }

  add() {
    this.cards.push(new Card(null, this.getValue('front'), this.getValue('back')));
    this.setValue('front', '');
    this.getControl('front').reset();
    this.setValue('back', '');
    this.getControl('back').reset();
  }

  delete(index: number) {
    this.cards.splice(index, 1);
  }

  save() {
    this.cardSetService.create({
      name: this.getValue('cardSetName'),
      status: this.getValue('cardSetStatus'),
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
