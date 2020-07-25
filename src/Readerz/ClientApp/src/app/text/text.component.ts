import { Component, OnInit, ElementRef, ViewChild, TemplateRef, ViewContainerRef, AfterViewInit, ChangeDetectorRef, Injectable, Input } from '@angular/core';
import { Card } from '../services/card.service';
import { UnknownText } from '../models/text';
import { Util } from '../services/util.service';
import { delay, filter, map, mergeMap, switchMap } from 'rxjs/operators';
import { from, of } from 'rxjs';

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html',
  styleUrls: ['./text.component.css']
})
export class TextComponent implements OnInit, AfterViewInit {
  @Input() text: UnknownText;

  @ViewChild('paragraphTemplate', { static: false }) paragraphTemp: TemplateRef<any>;
  @ViewChild('container', { read: ViewContainerRef, static: false }) container: ViewContainerRef;

  constructor(private cdr: ChangeDetectorRef) {
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
  //but sushi with the end of dot, need to fix this cases.

  selectWord(event: any) {
    let span = event.target as HTMLSpanElement
    console.log(span.innerText);
    span.className = "border rounded bg-info";
  }

}
