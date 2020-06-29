import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormComponent } from './form.component';


@NgModule({
  declarations: [FormComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [FormComponent]
})

export class FormModule { }
