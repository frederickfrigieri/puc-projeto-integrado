import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageAlertService {

  constructor() { }

  success(message: string, title?: string): void {
    alert(message);
  }
}
