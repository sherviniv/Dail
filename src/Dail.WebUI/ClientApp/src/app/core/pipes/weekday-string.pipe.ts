import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { DayOfWeek } from '../services/dail.service';

@Pipe({ name: 'weekdaytostring' })
export class WeekDayStringPipe implements PipeTransform {
    public transform(value: DayOfWeek) {
        const dayNames = [
            'شنبه',
            'یکشنبه',
            'دوشنبه',
            'سه شنبه',
            'چهارشنبه',
            'پنجشنبه',
            'جمعه',
        ]
        return dayNames[value];
    }
}