import { Component, OnInit, ViewChild, TemplateRef, ViewContainerRef, AfterViewInit, ChangeDetectorRef, Input } from '@angular/core';
import { UnknownText } from '../models/text';
import { Util } from '../services/util.service';
import { filter, switchMap } from 'rxjs/operators';
import { from, of } from 'rxjs';
import { TextService, Language } from '../services/text.service';
import { Card } from '../services/card.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html',
  styleUrls: ['./text.component.css']
})
export class TextComponent implements OnInit, AfterViewInit {
  @Input() text: UnknownText;

  @ViewChild('paragraphTemplate', { static: false }) paragraphTemp: TemplateRef<any>;
  @ViewChild('container', { read: ViewContainerRef, static: false }) container: ViewContainerRef;

  languages: Language[]
  languageFrom: string
  languageTo: string
  lastTranslation: string = "Word that will be traslated will be here"
  translation: string = "Translation will be here"
  cards: Card[]
  selectForm = this.fb.group({
    langToSelect: ['', [Validators.required]],
    langFromSelect: ['', [Validators.required]]
  })

  constructor(private cdr: ChangeDetectorRef, private textService: TextService,
    public fb: FormBuilder) {
    this.textService.getSupportedLanguages().subscribe(val => {
      this.languages = val.languages;
    })
  }

  get langToSelect() {
    return this.selectForm.get('langToSelect');
  }

  get langFromSelect() {
    return this.selectForm.get('langFromSelect');
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    // //first of all text will be splitted by '\n' characters
    // from((this.text.innerText.split('\n'))).pipe(
    //   //check if text string is not blank
    //   filter(val => !Util.isBlank(val)),
    //   //switch map that returns a paragraph that will be insert on the page with all words in text string
    //   switchMap(val => {
    //     let words = Util.getWords(val); // get words
    //     return of(this.paragraphTemp.createEmbeddedView({ words: words }));
    //   })
    // ).subscribe(val => {
    //   this.container.insert(val); // add to container of paragrapsh new paragraph
    //   this.cdr.detectChanges(); // detect changes by a reason of manual dom manipulating
    // }, err => console.log(err))

    this.textService.getProcessed(this.text.innerText)
    .subscribe(val => {
      let p = this.paragraphTemp.createEmbeddedView({text: val});
      this.container.insert(p);
      this.cdr.detectChanges();
    }, err => console.log(err));
  }

  selectWord(event: any) {
    //check for validate errors
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }
    //traslate the span inner text
    let span = event.target as HTMLSpanElement
    this.textService.getTranslatedWord({
      text: span.innerText,
      from: this.languageFrom,
      to: this.languageTo
    }).subscribe(val => {
      this.lastTranslation = span.innerText;
      this.translation = val.translations.join(', ');
    });

    span.className = "border rounded bg-info";
  }

  addWordToCards() {
    //check for validate errors
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }
    //check for existings last translation 
    if(!this.lastTranslation || !this.translation) {
      return;
    }
    //push new card to card array
    this.cards.push(new Card(null, this.lastTranslation, this.translation));
  }
}
