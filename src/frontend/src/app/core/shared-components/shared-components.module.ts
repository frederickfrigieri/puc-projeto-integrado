import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputInvalidMessageComponent } from './input-invalid-message/input-invalid-message.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbAlert, NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    InputInvalidMessageComponent
  ],
  imports: [
    CommonModule,
    NgSelectModule,
    NgbModule
  ],
  exports: [InputInvalidMessageComponent, NgSelectModule, NgbAlert]
})
export class SharedComponentsModule { }
