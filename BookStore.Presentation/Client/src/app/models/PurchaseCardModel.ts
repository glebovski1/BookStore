
import { DecimalPipe } from '@angular/common';
import { PurchaseModel } from 'app/models/purchaseModel';

export class PurchaseCardModel {
    public PurchaseModels: Array<PurchaseModel>;
    public Amount: number;
    public TotalCost: DecimalPipe;
    constructor() {}
}
