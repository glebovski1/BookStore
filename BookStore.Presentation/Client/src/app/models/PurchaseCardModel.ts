
import { DecimalPipe } from '@angular/common';
import { PurchaseModel } from 'app/models/purchaseModel';

export class PurchaseCardModel {
    public PurchaseModels: Array<PurchaseModel>;
    public Amount: number;
    public TotalCost: DecimalPipe;
    constructor() {}
    public GetPurchaseModelById(id: number) {
        return this.PurchaseModels.filter(purchase => purchase.id === id);
    }
}
