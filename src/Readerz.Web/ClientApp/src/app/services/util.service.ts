import { Injectable } from "@angular/core";

@Injectable()
export class Util {
    static isBlank(str: string) {
        return !str || /^\s*$/.test(str);
    }
}