import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { SnackbarComponent } from './shared/snackbar/snackbar.component';
import { InputComponent } from './shared/input/input.component';
import { NotificationService } from './services';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { PublicComponent } from './pages/public/public/public.component';
import { MainComponent } from './pages/public/main/main.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { VeiculosComponent } from './pages/public/veiculos/veiculos.component';
import { VeiculosListaComponent } from './pages/public/veiculos/veiculos-lista/veiculos-lista.component';
import { VeiculoService } from './services/veiculo.service';

@NgModule({
  declarations: [
    AppComponent,
    SnackbarComponent,
    InputComponent,
    PublicComponent,
    MainComponent,
    VeiculosComponent,
    VeiculosListaComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    NgSelectModule,
    LoadingBarHttpClientModule,
    LoadingBarRouterModule,
    AngularFontAwesomeModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
  ],
  providers: [
    VeiculoService,
    NotificationService,
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    { provide: LocationStrategy, useClass: HashLocationStrategy },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
