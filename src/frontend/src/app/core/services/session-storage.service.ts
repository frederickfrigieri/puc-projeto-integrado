import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable({ providedIn: 'root' })
export class SessionStorageService {
    add(chave: string, content: any): any {
        localStorage.setItem(chave, content);
    }

    get(chave: any): any {
        return localStorage.getItem(chave);
    }
}