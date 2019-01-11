import { NotificationColorEnum } from '../enums/notification-color.enum';
export class NotificationSnackModel {
  message: string = null;
  type: NotificationColorEnum = null;
  valid: string;

  constructor(message: string, type: NotificationColorEnum = null) {
    this.message = message;
    this.type = type;
  }
}
