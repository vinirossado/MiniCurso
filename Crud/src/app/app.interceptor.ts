import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';

import { NotificationColorEnum } from './enums/notification-color.enum';
import { LoadingService } from './services/loading.service';
import { NotificationService } from './services/notification.service';

@Injectable()
export class AppInterceptor implements HttpInterceptor {
  constructor(private injector: Injector) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const ns = this.injector.get(NotificationService);
    const loading = this.injector.get(LoadingService);

    // if (loginService.isLoggedIn()) {
    //   req = req.clone({ headers: req.headers.set('Authorization', `Bearer ${loginService.getToken()}`) });
    // }

    // Verificar se a requisição foi feita por um hub
    let isHubRequest = req.url.indexOf('hub') > -1;

    return next.handle(req)
      .pipe(
        tap((event: HttpEvent<any>) => {
          if (!isHubRequest) {
            loading.show(true);
          }
        }, (err: HttpErrorResponse) => {
          let message = '';
          if (err.error != null) {
            if (typeof (err.error) === 'string') {
              message = err.error;
            } else {
              message = err.error.Message;
            }
          } else {
            message = err.message;
          }

          if (err instanceof HttpErrorResponse) {
            if (!navigator.onLine) {
              ns.notify('Não foi possível se comunicar com o servidor.', NotificationColorEnum.danger);
            } else {

              let errorMessage = typeof (err.error) == 'string' ? err.error : null;

              switch (err.status) {
                case 400:
                  ns.notify(errorMessage || 'Má requisição.', NotificationColorEnum.danger);
                  break;
                // case 401:
                //   ns.notify(errorMessage || 'Não autenticado.', NotificationColorEnum.danger);
                //   loginService.logout();
                //   break;
                case 403:
                  ns.notify(errorMessage || 'Não autorizado.', NotificationColorEnum.danger);
                  break;
                case 404:
                  ns.notify(errorMessage || 'Não encontrado.', NotificationColorEnum.danger);
                  break;
                case 500:
                  ns.notify(errorMessage || 'Erro interno do servidor.', NotificationColorEnum.danger);
                  break;
                default:
                  ns.notify(errorMessage || 'Não foi possível se conectar com o servidor.', NotificationColorEnum.danger);
              }
            }
          } else {
            ns.notify('Erro interno do Angular.', NotificationColorEnum.danger);
          }

          loading.show(false);
        }, () => {
          if (!isHubRequest) {
            loading.show(false);
          }
        })
      );
  }
}
