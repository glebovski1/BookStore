import { PurchaseModel } from 'src/app/models/purchaseModel';
import { DecimalPipe } from '@angular/common';

export class PurchaseCardModel {
    public PurchaseModels: Array<PurchaseModel>;
    public Amount: number;
    public TotalCost: DecimalPipe;
    constructor() {}
}
