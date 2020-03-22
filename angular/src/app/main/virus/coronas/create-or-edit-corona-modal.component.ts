import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { CoronasServiceProxy, CreateOrEditCoronaDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';

@Component({
    selector: 'createOrEditCoronaModal',
    templateUrl: './create-or-edit-corona-modal.component.html'
})
export class CreateOrEditCoronaModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    corona: CreateOrEditCoronaDto = new CreateOrEditCoronaDto();



    constructor(
        injector: Injector,
        private _coronasServiceProxy: CoronasServiceProxy
    ) {
        super(injector);
    }

    show(coronaId?: number): void {

        if (!coronaId) {
            this.corona = new CreateOrEditCoronaDto();
            this.corona.id = coronaId;

            this.active = true;
            this.modal.show();
        } else {
            this._coronasServiceProxy.getCoronaForEdit(coronaId).subscribe(result => {
                this.corona = result.corona;


                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
            this.saving = true;

			
            this._coronasServiceProxy.createOrEdit(this.corona)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }







    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
