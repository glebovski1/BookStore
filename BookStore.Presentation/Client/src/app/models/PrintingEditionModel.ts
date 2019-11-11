import {AuthorModel} from './AuthorModel';
import { DecimalPipe } from '@angular/common';

export class PrintingEditionModel {
    public id: number;
    public name: string;
    public description: string;
    public price: DecimalPipe;
    public status: string;
    public currency: string;
    public type: string;
    public authors: Array<AuthorModel>;
}
