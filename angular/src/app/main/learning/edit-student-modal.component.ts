import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { StudentServiceProxy, EditStudentInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'editStudentModal',
  templateUrl: './edit-student-modal.component.html'
})
export class EditStudentModalComponent extends AppComponentBase {

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal' , { static: false }) modal: ModalDirective;
  @ViewChild('nameInput' , { static: false }) nameInput: ElementRef;

  student: EditStudentInput = new EditStudentInput();

  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,
    private _studentService: StudentServiceProxy
  ) {
    super(injector);
  }

  show(studentId): void {
    this.active = true;
    this._studentService.getStudentForEdit(studentId).subscribe((result)=> {
      this.student = result;
      this.modal.show();
    });

  }

  onShown(): void {
   // this.nameInput.nativeElement.focus();
  }

  save(): void {
    this.saving = true;
    this._studentService.editStudent(this.student)
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(this.student);
      });
    this.saving = false;
  }

  close(): void {
    this.modal.hide();
    this.active = false;
  }
}