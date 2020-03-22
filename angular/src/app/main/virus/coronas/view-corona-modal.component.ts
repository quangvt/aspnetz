import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { GetCoronaForViewDto, CoronaDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewCoronaModal',
    templateUrl: './view-corona-modal.component.html'
})
export class ViewCoronaModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetCoronaForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetCoronaForViewDto();
        this.item.corona = new CoronaDto();
    }

    show(item: GetCoronaForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
