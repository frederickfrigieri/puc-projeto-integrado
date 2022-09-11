import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { environment } from "src/environments/environment";
import { SessionStorageService } from "./session-storage.service";

@Injectable({ providedIn: 'root' })
export class AuthService {

    private endpoint = environment.urlAuth;

    static chave = 'DS-202212';

    constructor(private httpClient: HttpClient) { }

    logar(model: any): Observable<any> {
        return this.httpClient.post<any>(`${this.endpoint}/logar`, model);
    }
}
