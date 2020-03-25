import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { StudentServiceProxy, CreateStudentInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'createStudentModal',
    templateUrl: './create-student-modal.component.html'
})
export class CreateStudentModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal' , { static: false }) modal: ModalDirective;
    @ViewChild('nameInput' , { static: false }) nameInput: ElementRef;

    student: CreateStudentInput = new CreateStudentInput();

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _studentService: StudentServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.student = new CreateStudentInput();
        this.modal.show();
    }

    onShown(): void {
        this.nameInput.nativeElement.focus();
    }

    save(): void {
        this.saving = true;
        this._studentService.createStudent(this.student)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(this.student);
            });
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}