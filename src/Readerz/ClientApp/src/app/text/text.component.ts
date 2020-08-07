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

  //dom generating with view
  //TODO: need to comment this section
  ngAfterViewInit() {
    from((this.text.innerText.split('\n'))).pipe(
      filter(val => !Util.isBlank(val)),
      switchMap(val => {
        let words = val.split(' '); // mb async
        return of(this.paragraphTemp.createEmbeddedView({ words: words }));
      })
    ).subscribe(val => {
      this.container.insert(val);
      this.cdr.detectChanges(); // detect changes by a reason of manual dom manipulating
    }, err => console.log(err))
  }

  //TODO bug: sentence: I love sushi., there are 3 words ["I", "love", "sushi."], 
  //but sushi has the end with dot, need to fix this case and similar with other punctuations.

  selectWord(event: any) {
    //check for validate errors
    if (this.langToSelect.errors || this.langFromSelect.errors) {
      return;
    }
    //traslate the span inner text
    let span = event.target as HTMLSpanElement
    this.textService.translateWord({
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
