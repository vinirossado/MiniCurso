import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Veiculo } from '../models';
import { Observable } from 'rxjs';

@Injectable()

export class VeiculoService {

  constructor(
    private http: HttpClient,
    private router: Router
  ) {}

  listarVeiculos(): any {
    //Nome da API/Route do Controller/Route do metodo
    //http://localhost/veiculos/veiculos/veiculos;
    return this.http.get<any>(`${environment.api}veiculos/veiculos/`);
  }

  cadastrarVeiculo(veiculo: Veiculo): Observable<Veiculo[]> {
    return this.http.post<Veiculo[]>(`${environment.api}veiculos/veiculo`, veiculo);
  }

  encontrarVeiculo(veiculoId: number): Observable<Veiculo>{
    return this.http.get<Veiculo>(`${environment.api}veiculos/veiculo/${veiculoId}`);
  }

  deletarVeiculo(veiculoId: number): Observable<Veiculo> {
    return this.http.delete<Veiculo>(`${environment.api}veiculos/veiculo/${veiculoId}`);
  }
}
