import { Injectable } from "@angular/core";
import { isBoolean } from "util";
import { Observable, from } from "rxjs";
import { filter, map } from "rxjs/operators";

@Injectable()
export class Util {
    static isBlank(str: string) {
        return !str || /^\s*$/.test(str);
    }
}