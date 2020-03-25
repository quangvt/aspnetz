import * as _ from 'lodash';
import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { StudentServiceProxy, StudentListDto, ListResultDtoOfStudentListDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './learning.component.html',
    styleUrls: ['./learning.component.less'],
    animations: [appModuleAnimation()]
})

export class LearningComponent extends AppComponentBase implements OnInit {
    student: StudentListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _studentService: StudentServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getPeople();
    }

    getPeople(): void {
        this._studentService.getStudent(this.filter).subscribe((result) => {
            this.student = result.items;
        });
    }

    deleteStudent(student: StudentListDto): void {
        this.message.confirm(
            this.l('AreYouSureToDeleteTheStudent', student.name),
            student.name,
            isConfirmed => {
                if (isConfirmed) {
                    this._studentService.deleteStudent(student.id).subscribe(() => {
                        this.notify.info(this.l('SuccessfullyDeleted'));
                        _.remove(this.student, student);
                    });
                }
            }
        );
    } 
}