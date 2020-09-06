import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';

@Component({
    template: ''
})  
export class BaseFormComponent {

    // the form model
    form: FormGroup;

    constructor() {
    }

    // retrieve a FormControl
    getControl(name: string) {
        return this.form.get(name);
    }

    // returns TRUE if the FormControl is valid
    isValid(name: string) {
        let e = this.getControl(name);
        return e && e.valid;
    }

    // returns TRUE if the FormControl has been changed
    isChanged(name: string) {
        let e = this.getControl(name);
        return e && (e.dirty || e.touched);
    }

    // returns TRUE if the FormControl is raising an error,
    // i.e. an invalid state after user changes
    hasError(name: string) {
        let e = this.getControl(name);
        return e && (e.dirty || e.touched) && e.invalid;
    }

    //returns a value from form control
    getValue(name: string) {
        return this.getControl(name).value;
    }

    setValue(name: string, value: any) {
        return this.getControl(name).setValue(value);
    }
}