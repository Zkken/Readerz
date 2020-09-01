import { Component, OnInit, ViewChild } from '@angular/core';
import { CardSetService } from '../services/card-set.service';
import { CardSet } from '../models/card-set';
import { PageEvent, MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./card.component.css']
})
export class CardsComponent implements OnInit {
  cardSets: CardSet[];

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(
    private cardSetService: CardSetService
  ) {
  }

  ngOnInit() {
    this.loadCardSets();
  }

  private loadCardSets() {
    let pageEvent = new PageEvent();
    pageEvent.pageIndex = 0;
    pageEvent.pageSize = 10;
    this.getData(pageEvent);
  }

  delete(id: number) {
    this.cardSetService.delete(id).subscribe(
      () => this.loadCardSets(),
      err => console.log(err));
  }

  getData(pageEvent: PageEvent) {
    this.cardSetService.getCards(
      pageEvent.pageIndex.toString(),
      pageEvent.pageSize.toString(),
      true
    ).subscribe(result => {
      this.paginator.length = result.totalPages;
      this.paginator.pageIndex = result.pageIndex;
      this.paginator.pageSize = result.pageSize;
      this.cardSets = result.data;
    }, err => console.log(err));
  }
}

//TODO add mat-table
