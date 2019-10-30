import { DecimalPipe } from '@angular/common';

export class PurchaseModel {
    public id: number;
    public name: string;
    public amount: number;
    public price: DecimalPipe;
    public currency: string;
    constructor() {}
}
