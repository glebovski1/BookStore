import {AuthorModel} from './AuthorModel';
import { DecimalPipe } from '@angular/common';

export class PrintingEditionModel {
    public Name: string;
    public Description: string;
    public Price: DecimalPipe;
    public Status: string;
    public Currency: string;
    public Type: string;
    public Authors: Array<AuthorModel>;
}
