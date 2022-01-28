import { Injectable, Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'persiandateshort' })
export class PersianDatePipe implements PipeTransform {
    public transform(value: Date) {
        if(!value) return '';
        let time = new Date(value.getTime() - value.getTimezoneOffset() * 60 * 1000);
        return time.toLocaleTimeString('fa-IR') + ' - ' + new Date(value).toLocaleDateString('fa-IR');
    }
}