import { Component, OnInit, ViewChild } from '@angular/core';
import { CardSetService } from '../services/card-set.service';
import { CardSet } from '../models/card-set';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { MatDialog } from '@angular/material/dialog';
import { CardsDeleteDialogComponent } from './cards-delete-dialog/cards-delete-dialog.component';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./card.component.css']
})
export class CardsComponent implements OnInit {
  cardSets: CardSet[];
  pageEvent: PageEvent;
  trashIcon = faTrash;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private cardSetService: CardSetService,
    public dialog: MatDialog
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
    const dialogRef = this.dialog.open(CardsDeleteDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.cardSetService.delete(id).subscribe(
          () => this.loadCardSets(),
          err => console.log(err)
        );
      }
    });
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
