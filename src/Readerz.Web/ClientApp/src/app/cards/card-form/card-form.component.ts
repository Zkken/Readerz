import { Component, OnInit, Input } from '@angular/core';
import { Card } from 'src/app/models/card';

@Component({
  selector: 'app-card-form',
  templateUrl: './card-form.component.html',
  styleUrls: ['./card-form.component.css']
})
export class CardFormComponent implements OnInit {
  @Input() card: Card
  constructor() { }

  ngOnInit() {
  }

}
