import { Component, OnInit } from '@angular/core';
import { UnknownText } from 'src/app/models/text';

@Component({
  selector: 'app-text-create',
  templateUrl: './text-create.component.html',
  styleUrls: ['./text-create.component.css']
})
export class TextCreateComponent implements OnInit {
  text: UnknownText;
  editMode: boolean = true;
  constructor() {
    this.text = new UnknownText();
   }

  ngOnInit() {
  }

  setText() {
    this.editMode = false;
  }
}
