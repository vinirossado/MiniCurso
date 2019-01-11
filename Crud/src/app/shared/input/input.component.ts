import { Component, OnInit, Input, ContentChild, AfterContentInit } from '@angular/core';
import { NgModel, FormControlName } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html'
})
export class InputComponent implements AfterContentInit  {
  @Input() label: string;
  @Input() labelAlign = 'text-left';
  @Input() errorMessage: string;
  @Input() showTip = true;
  @Input() isRequired = false;
  @ContentChild(FormControlName) control: FormControlName;
  constructor() { }
  ngAfterContentInit(): void {
    if (this.control == null) {
      throw new Error('Esse componente precisa ser usado com uma diretiva formControlName');
    }
  }
  hasError(): boolean {
    return !this.control.valid && (this.control.dirty || this.control.touched);
  }
}
