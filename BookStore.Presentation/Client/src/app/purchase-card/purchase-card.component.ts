import { Component, OnInit } from '@angular/core';
import { PurchaseService} from '../Service';
import {PurchaseCardModel, PurchaseModel} from '../models';
 
@Component({
    selector: 'app-purchase-card',
    templateUrl: './purchase-card.component.html'
})
export class PurchaseCardComponent implements OnInit {
currentPurchaseCard: PurchaseCardModel;
    constructor(private purchaseService: PurchaseService) {}
    
    ngOnInit() {
this.currentPurchaseCard = this.purchaseService.GetPurchaseCardFromLocalStorage();
    }

}