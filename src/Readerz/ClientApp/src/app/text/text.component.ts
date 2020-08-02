import { Component, OnInit, ViewChild, TemplateRef, ViewContainerRef, AfterViewInit, ChangeDetectorRef,  Input } from '@angular/core';
import { UnknownText } from '../models/text';
import { Util } from '../services/util.service';
import { filter, switchMap } from 'rxjs/operators';
import { from, of } from 'rxjs';
import { TextService, Language } from '../services/text.service';

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

  constructor(private cdr: ChangeDetectorRef, private textService: TextService) {
    this.textService.getSupportedLanguages().subscribe(val => {
      this.languages = val.languages;
    })
  }

  ngOnInit() {
  }

  //dom generating with view
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
    let span = event.target as HTMLSpanElement

    this.textService.translateWord({
      text: span.innerText,
      from: this.languageFrom,
      to: this.languageTo
    }).subscribe(val => {
      console.log(val.translations);
    });

    span.className = "border rounded bg-info";
  }

}
