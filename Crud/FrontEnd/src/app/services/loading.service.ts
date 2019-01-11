import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class LoadingService {
    shower = new EventEmitter<boolean>();

    show(isVisible: boolean) {
        this.shower.emit(isVisible);
    }
}
