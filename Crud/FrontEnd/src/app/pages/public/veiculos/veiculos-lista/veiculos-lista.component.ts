import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-veiculos-lista',
  templateUrl: './veiculos-lista.component.html',
  styleUrls: ['./veiculos-lista.component.scss']
})
export class VeiculosListaComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  novo(){
    this.router.navigate(['/veiculos/novo']);
  }
}
