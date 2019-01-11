import { Component } from '@angular/core';
import { NgSelectConfig } from '@ng-select/ng-select';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Crud';

  constructor(private config: NgSelectConfig) {
    //Realizando configuração padrão no <ng-select>
    this.config.notFoundText = 'Nada foi encontrado';
    this.config.loadingText = 'Buscando...';
  }
}
