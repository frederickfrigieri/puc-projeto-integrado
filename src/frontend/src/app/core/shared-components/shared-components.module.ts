import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputInvalidMessageComponent } from './input-invalid-message/input-invalid-message.component';



@NgModule({
  declarations: [
    InputInvalidMessageComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [InputInvalidMessageComponent]
})
export class SharedComponentsModule { }
