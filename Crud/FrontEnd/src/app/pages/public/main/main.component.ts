import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, ActivatedRoute } from '@angular/router';
import { Menu } from 'src/app/models';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  title = 'myhome';
  menus: Menu[];
  currentPage: string;
  id: any;
  usuarioForm: FormGroup;

  constructor(private router: Router,
              private route: ActivatedRoute
  ) { }

  ngOnInit() {
    // Array que serão recebido os itens do menu lateral
    this.menus = [];
    // Inclusão do Item de menu Lateral(rota, Titulo que será exibido, Icone)
    this.menus.push(new Menu('/veiculos', 'Veiculos', 'fa fa-car'));
    this.menus.push(new Menu('/', 'Menu 2', 'fa fa-lock'));
    this.menus.push(new Menu('/', 'Menu 3', 'fa fa-lock'));
    this.menus.push(new Menu('/', 'Menu 4', 'fa fa-lock'));
    this.menus.push(new Menu('/', 'Menu 5', 'fa fa-lock'));
    this.menus.push(new Menu('/', 'Menu 6', 'fa fa-lock'));
    this.menus.push(new Menu('/', 'Menu 7', 'fa fa-lock'));
    this.menus.push(new Menu('/', 'Menu 8', 'fa fa-lock'));


  }

  isPageActive(url: string): boolean {
    if(!this.currentPage || !url)
    return false;

    return this.currentPage.indexOf(url) > -1;
  }
}
