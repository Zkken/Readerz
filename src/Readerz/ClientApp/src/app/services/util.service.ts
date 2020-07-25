import { Injectable } from "@angular/core";
import { isBoolean } from "util";
import { Observable, from } from "rxjs";
import { filter, map } from "rxjs/operators";

@Injectable()
export class Util {
    private static space: string = "&nbsp;"; // space character
    static tab: string = Util.space.repeat(4);

    static createInnerHtmlParagrapgh(value: string, classes?: string,): Observable<string> {
        return from(value.split('\n')).pipe(
            filter(val => !this.isBlank(val)),
            map(val => {
                let words: string[] = val.split(' ');
                words.map(word => "<span>" + word + "</span>");
                return `<p class="${classes}>` + Util.tab.repeat(2) + val + '</p>';
            })
        )
    }

    static isBlank(str: string) {
        return !str || /^\s*$/.test(str);
    }
}