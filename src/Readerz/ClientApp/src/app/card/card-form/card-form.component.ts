import { Component, Input } from "@angular/core";
import { Card } from "../card";

@Component({
    selector: 'card-form',
    templateUrl: './card-form.component.html'
})
export class CardFormComponent {
    @Input() card: Card;
}