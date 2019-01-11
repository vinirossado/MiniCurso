import { Component, OnInit } from '@angular/core';
import { transition, trigger, state, style, animate } from '@angular/animations';
import { NotificationColorEnum } from 'src/app/enums';
import { NotificationService } from 'src/app/services';
import { switchMap, tap } from 'rxjs/operators';
import { timer as observableTimer, Observable } from 'rxjs';

@Component({
  selector: 'app-snackbar',
  templateUrl: './snackbar.component.html',
  styleUrls: ['./snackbar.component.scss'],
    animations: [
      trigger('snack-visibility', [
        state(
          'hidden',
          style({
            opacity: 0,
            bottom: '-30px'
          })
        ),
        state(
          'visible',
          style({
            opacity: 1,
            bottom: '30px'
          })
        ),
        transition('hidden => visible', animate('500ms 0s ease-in')),
        transition('visible => hidden', animate('500ms 0s ease-out'))
      ])
    ]
  })
export class SnackbarComponent implements OnInit {
  message: string;
  type: string;

  snackVisibility = "hidden";

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {
    this.notificationService.notifier
      .pipe(
        tap(model => {
          this.message = model.message;
          let type;
          switch (model.type) {
            case NotificationColorEnum.warning:
              type = 'warning';
              break;
            case NotificationColorEnum.danger:
              type = 'danger';
              break;
            default:
              type = 'normal';
              break;
          }
          this.type = type;
          this.snackVisibility = 'visible';
        }),
        switchMap(message => observableTimer(3000))
      )
      .subscribe(timer => (this.snackVisibility = 'hidden'));
  }
}
