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
  paragraph: string

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
    this.textService.getProcessed(this.text.innerText)
    .subscribe(val => {
      console.log(val.text);
      let paragraph = this.paragraphTemp.createEmbeddedView({text: val.text});
      this.container.insert(paragraph);
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
