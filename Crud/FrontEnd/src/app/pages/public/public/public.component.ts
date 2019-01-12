import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/services';
import { NotificationColorEnum } from 'src/app/enums';

@Component({
  selector: 'app-public',
  templateUrl: './public.component.html',
  styleUrls: ['./public.component.scss']
})
export class PublicComponent implements OnInit {

  constructor(private notificationService: NotificationService) { }

  ngOnInit() {
  }

  Teste(){
      this.notificationService.notify(" O Cadastro do veiculo foi efetuado com sucesso", NotificationColorEnum.warning);
  }

}
