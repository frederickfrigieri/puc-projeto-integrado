import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputInvalidMessageComponent } from './input-invalid-message/input-invalid-message.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbAlert, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { InfoApiSwaggerComponent } from './info-api-swagger/info-api-swagger.component';



@NgModule({
  declarations: [
    InputInvalidMessageComponent,
    InfoApiSwaggerComponent
  ],
  imports: [
    CommonModule,
    NgSelectModule,
    NgbModule
  ],
  exports: [InputInvalidMessageComponent, NgSelectModule, NgbAlert, InfoApiSwaggerComponent]
})
export class SharedComponentsModule { }
