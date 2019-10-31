import { Component, OnInit } from '@angular/core';
import { PurchaseCardModel, PurchaseModel } from 'app/models';
import { PurchaseService } from 'app/Service';
import { Subscriber } from 'rxjs';


@Component({
    selector: 'app-purchase-card',
    templateUrl: './purchase-card.component.html'
})
export class PurchaseCardComponent implements OnInit {
    currentPurchaseCard: PurchaseCardModel;
    constructor(private purchaseService: PurchaseService) { }
    ngOnInit() {
        this.currentPurchaseCard = this.purchaseService.GetPurchaseCardFromLocalStorage();
    }
    onRemove(purchase: PurchaseModel) {
        for (let i = 0; i < this.currentPurchaseCard.PurchaseModels.length; i++) {
            if (this.currentPurchaseCard.PurchaseModels[i].id === purchase.id) {
                this.currentPurchaseCard.PurchaseModels.splice(i, 1);
            }
        }
        this.purchaseService.AddPurchaseCardToLocalStorage(this.currentPurchaseCard);

    }

    onRemoveAll() {
      this.purchaseService.DeletePurchaseCardFromLocalStorage();
      window.location.reload();
    }

    onBuy() {

    }
}
