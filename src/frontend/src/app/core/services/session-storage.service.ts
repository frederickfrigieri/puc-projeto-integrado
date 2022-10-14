import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class SessionStorageService {
    add(chave: string, content: any): any {
        localStorage.setItem(chave, content);
    }

    get(chave: any): any {
        return localStorage.getItem(chave);
    }

    remove(chave: any) {
        localStorage.removeItem(chave);
    }
}