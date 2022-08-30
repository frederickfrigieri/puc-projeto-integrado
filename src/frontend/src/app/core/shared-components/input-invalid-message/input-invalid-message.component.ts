import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input-invalid-message',
  templateUrl: './input-invalid-message.component.html',
  styleUrls: ['./input-invalid-message.component.scss']
})
export class InputInvalidMessageComponent implements OnInit {

  @Input() frmGroup : FormGroup;
  @Input() controlName : string;
  @Input() message: string = '* Campo inválido';

  get frmControl(): FormControl {
    return <FormControl>this.frmGroup.controls[this.controlName];
  }

  constructor() { }

  ngOnInit(): void {
  }

}
