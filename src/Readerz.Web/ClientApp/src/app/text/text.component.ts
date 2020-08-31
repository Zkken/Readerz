import { Component, OnInit, ViewChild, TemplateRef, ViewContainerRef, AfterViewInit, ChangeDetectorRef, Input } from '@angular/core';
import { UnknownText } from '../models/text';
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

  languages: Language[];
  languageFrom: string;
  languageTo: string;
  lastTranslation: string = "Word that will be traslated will be here";
  translation: string = "Translation will be here";
  paragraph: string;
  cards: Card[];
  wordCash: Map<string, string[]> = new Map<string, string[]>();

  selectForm = this.fb.group({
    langToSelect: ['', [Validators.required]],
    langFromSelect: ['', [Validators.required]]
  });

  constructor(private cdr: ChangeDetectorRef, private textService: TextService,
    public fb: FormBuilder) {
  }

  get langToSelect() {
    return this.selectForm.get('langToSelect');
  }

  get langFromSelect() {
    return this.selectForm.get('langFromSelect');
  }

  ngOnInit() {
    this.textService.getSupportedLanguages().subscribe(val => {
      this.languages = val.languages;
    })
  }

  ngAfterViewInit() {
    this.textService.getProcessed(this.text.innerText)
      .subscribe(val => {
        console.log(val.text);
        let paragraph = this.paragraphTemp.createEmbeddedView({ text: val.text });
        this.container.insert(paragraph);
        this.cdr.detectChanges();
      }, err => console.log(err));
  }

  selectWord(text: string) {
    //check for validate errors
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }
    this.lastTranslation = text;

    //traslate the span inner text
    if (this.wordCash.has(text)) {
      this.translation = this.wordCash.get(text).join(', ');
    } else {
      this.textService.getTranslatedWord({
        text: text,
        from: this.languageFrom,
        to: this.languageTo
      }).subscribe(val => {
        this.translation = val.translations.join(', ');
        this.wordCash.set(text, val.translations);
      });
    }
  }

  addWordToCards() {
    //check for validate errors
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }
    //check for existings last translation 
    if (!this.lastTranslation || !this.translation) {
      return;
    }
    //push new card to card array
    this.cards.push(new Card(null, this.lastTranslation, this.translation));
  }
}
