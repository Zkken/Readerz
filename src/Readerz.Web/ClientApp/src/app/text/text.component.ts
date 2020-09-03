import { Component, OnInit } from '@angular/core';
import { UnknownText, Language, TextProcessingResult, TextItem } from '../models/text';
import { TextService } from '../services/text.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Card } from '../models/card';
import { CardSetService } from '../services/card-set.service';
import { CardSetStatus } from '../models/card-set';
import { switchMap } from 'rxjs/operators';
import { CardService } from '../services/card.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html',
  styleUrls: ['./text.component.css']
})
export class TextComponent implements OnInit {
  languages: Language[];
  lastTranslation: string = "Word that will be traslated will be here";
  translation: string = "Translation will be here";
  textItems: TextItem[];
  text = new UnknownText();
  textCreated = false;
  cards: Card[] = [];
  wordCash: Map<string, string[]> = new Map<string, string[]>();

  selectForm = this.fb.group({
    langToSelect: ['', [Validators.required]],
    langFromSelect: ['', [Validators.required]],
  });

  textForm = this.fb.group({
    textName: ['The text #1', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
    textInner: [`Amy normally hated Monday mornings, but this year was different. Kamal was in her art class and she liked Kamal. She was waiting outside the classroom when her friend Tara arrived.


    “Hi Amy! Your mum sent me a text. You forgot your inhaler. Why don’t you turn your phone on?” Amy didn’t like technology. She never sent text messages and she hated Facebook too.


    “Did Kamal ask you to the disco?” Tara was Amy’s best friend, and she wanted to know everything that was happening in Amy’s life. “I don’t think he likes me,” said Amy. “And I never see him alone. He’s always with Grant.” Amy and Tara didn’t like Grant.


    “Do you know about their art project?” asked Amy. “It’s about graffiti, I think,” said Tara. “They’re working on it at the old house behind the factory.” “But that building is dangerous,” said Amy. “Aah, are you worried he’s going to get hurt?" Tara teased. “Shut up, Tara! Hey look, here they come!”


    Kamal and Grant arrived. “Hi Kamal!” said Tara. “Are you going to the Halloween disco tomorrow?” “Yes. Hi Amy,” Kamal said, smiling. “Do you want to come and see our paintings after school?” “I’m coming too!” Tara insisted.


    After school, Kamal took the girls to the old house. It was very old and very dirty too. There was rubbish everywhere. The windows were broken and the walls were damp. It was scary. Amy didn’t like it. There were paintings of zombies and skeletons on the walls. “We’re going to take photos for the school art competition,” said Kamal. Amy didn’t like it but she didn’t say anything. “Where’s Grant?” asked Tara. “Er, he’s buying more paint.” Kamal looked away quickly. Tara thought he looked suspicious. “It’s getting dark, can we go now?” said Amy. She didn’t like zombies.`, 
    [Validators.required, Validators.minLength(10), Validators.maxLength(5000)]]
  });

  constructor( 
    private textService: TextService, 
    public fb: FormBuilder,
    private cardSetService: CardSetService,
    private cardService: CardService,
    private router: Router) {
  }

  get langToSelect() {
    return this.selectForm.get('langToSelect');
  }

  get langFromSelect() {
    return this.selectForm.get('langFromSelect');
  }

  get textName() {
    return this.textForm.get('textName');
  }

  get textInner() {
    return this.textForm.get('textInner');
  }

  get isLastCardUnique() {
    return !!this.cards.find(card => card.front === this.lastTranslation);
  }

  ngOnInit() {
    this.textService.getSupportedLanguages().subscribe(val => {
      this.languages = val.languages;
    })
  }

  selectWord(text: string) {
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }

    this.lastTranslation = text;

    if (this.wordCash.has(text)) {
      this.translation = this.wordCash.get(text).join(', ');
    } else {
      this.textService.getTranslatedWord({
        text: text,
        from: this.langFromSelect.value,
        to: this.langToSelect.value
      }).subscribe(val => {
        this.translation = val.translations.join(', ');
        this.wordCash.set(text, val.translations);
      });
    }
  }

  addCard() {
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }

    if (!this.lastTranslation || !this.translation) {
      return;
    }

    this.cards.push(new Card(null, this.lastTranslation, this.translation));
  }

  save() {
    this.cardSetService.create({
      status: CardSetStatus.Private,
      name: `${this.text.name}'s card set.`
    }).pipe(
      switchMap(result => {
        return this.cardService.createRange({
          cards: this.cards,
          cardSetId: result
        });
      })
    ).subscribe(() => this.router.navigateByUrl('/cards'));
  }

  setText() {
    this.text.innerText = this.textInner.value;
    this.text.name = this.textName.value;

    this.textService.getProcessed(this.text.innerText)
    .subscribe(val => {
      this.textItems = val.text;
    }, err => console.log(err));

    this.textCreated = true;
  }

  changeLangTo(e) {
    this.langToSelect.setValue(e.target.value);
  }

  changeLangFrom(e) {
    this.langFromSelect.setValue(e.target.value);
  }
}
