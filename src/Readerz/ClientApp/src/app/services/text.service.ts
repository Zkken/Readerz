import { Injectable, Inject } from "@angular/core";

@Injectable()
export class TextService {
    constructor(@Inject('BASE_URL') private baseUrl: string) {

    }

    getText(id: number) {
    
    }
}