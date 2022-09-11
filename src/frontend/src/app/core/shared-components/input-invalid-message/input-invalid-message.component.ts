import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input-invalid-message',
  templateUrl: './input-invalid-message.component.html',
  styleUrls: ['./input-invalid-message.component.scss']
})
export class InputInvalidMessageComponent implements OnInit {

  @Input() frmGroup: FormGroup;
  @Input() controlName: string;
  @Input() message: string = '* Campo inválido';
  @Input() arrayName: string;
  @Input() arrayIndex: number;


  get frmControl(): FormControl {
    let ctrl;
    if (this.arrayName) {
      let group = <FormGroup>this.frmGroup.get(this.arrayName);
      ctrl = <FormControl>group.controls[this.arrayIndex].get(this.controlName);
    } else {
      ctrl = <FormControl>this.frmGroup.controls[this.controlName];
    }
    return ctrl;
  }

  constructor() { }

  ngOnInit(): void {
  }

}
