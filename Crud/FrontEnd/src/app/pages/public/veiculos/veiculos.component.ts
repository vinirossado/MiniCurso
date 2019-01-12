import { Component, OnInit } from '@angular/core';
import { NotificationColorEnum } from 'src/app/enums';
import { Veiculo } from 'src/app/models/veiculos.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/services';
import { VeiculoService } from 'src/app/services/veiculo.service';

@Component({
  selector: 'app-veiculos',
  templateUrl: './veiculos.component.html',
  styleUrls: ['./veiculos.component.scss']
})
export class VeiculosComponent implements OnInit {

  id: number;
  veiculos: Veiculo[] = [];
  veiculo: Veiculo;
  veiculoForm: FormGroup;
  marcas: string[] = [
  'CHEVROLET',
  'VOLKSWAGEN',
  'FIAT',
  'AUDI',
  'CITROEN',
  'HONDA',
  'SUBARU',
  'FERRARI',
  'BUGATTI',
  'LAMBORGHINI',
  'FORD',
  'HYUNDAI',
  'JAC',
  'KIA'];

  combustiveis: string[] = [
    'Gasolina',
    'Alcool',
    'Diesel',
    'Flex',
    'Eletrico',
    'Hibrido'
  ];

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private veiculoService: VeiculoService,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {

    this.id = this.activatedRoute.snapshot.params['id'];

    console.log(this.id, 'this.ID')
    this.veiculoForm = this.fb.group({
      id: [0, [Validators.required]],
      nome: ['', [Validators.required]],
      modelo: ['', [Validators.required]],
      marca: ['', [Validators.required]],
      anoFabricacao: [''],
      anoModelo:    [''],
      chassi: [''],
      cor: [''],
      combustivel: [''],
      portas: [''],
      valor: ['0.00'],
    });

    if (this.id) {
      this.veiculoService
        .encontrarVeiculo(this.id)
        .toPromise()
        .then(veiculo => {
          this.veiculo = veiculo;
          this.veiculoForm.patchValue(veiculo);
        });
    }
  }

  deletar(id: number) {
    id = this.id;

    this.veiculoService
      .deletarVeiculo(id)
      .subscribe(Veiculo => {
        this.veiculo = this.veiculo;
        this.notificationService.notify(
          'O Veiculos foi deletado com sucesso.',
          NotificationColorEnum.normal
        );
        this.router.navigate(['/veiculos']);
      });
  }

  salvar(veiculo) {

    veiculo.combustivel = veiculo.combustivel.$ngOptionLabel;
    veiculo.marca = veiculo.marca.$ngOptionLabel;

console.log(veiculo)
    this.veiculoService
      .cadastrarVeiculo(veiculo)
      .subscribe(veiculos => {
        console.log(veiculo)
        if (veiculo.id > 0) {
          this.notificationService.notify(`O Veiculo ${veiculo.nome} foi alterado com sucesso`,
            NotificationColorEnum.normal);
          this.router.navigate(['/veiculos']);
        } else {
          this.notificationService.notify(`O Veiculo ${veiculo.nome} foi salvo com sucesso`,
            NotificationColorEnum.normal);
          this.router.navigate(['/veiculos']);
        }
        this.veiculos = veiculos
      });
    this.veiculoForm.reset({
      id: 0,
    });
  }

}
