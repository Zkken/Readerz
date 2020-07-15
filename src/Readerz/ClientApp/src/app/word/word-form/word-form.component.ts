import { Component, Input } from "@angular/core";
import { Word } from "../word";

@Component({
    selector: 'word-form',
    templateUrl: './word-form.component.html'
})
export class WordFormComponent {
    @Input() word: Word;
}