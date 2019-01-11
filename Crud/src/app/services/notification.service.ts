import { EventEmitter } from '@angular/core';
import { NotificationSnackModel } from '../models/notification-snack.model';
import { NotificationColorEnum } from '../enums/notification-color.enum';

export class NotificationService {
  notifier = new EventEmitter<NotificationSnackModel> ();

  notify(message: string, type: NotificationColorEnum) {
    const model = new NotificationSnackModel(message, type);
    this.notifier.emit(model);
  }

}
