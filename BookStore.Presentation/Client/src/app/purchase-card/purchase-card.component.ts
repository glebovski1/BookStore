import { Component, OnInit } from '@angular/core';
import { PurchaseCardModel, PurchaseModel } from 'app/models';
import { PurchaseService, OrderService } from 'app/Service';
import { Subscriber } from 'rxjs';
import { Routes, RouterModule, Router } from '@angular/router';


@Component({
    selector: 'app-purchase-card',
    templateUrl: './purchase-card.component.html'
})
export class PurchaseCardComponent implements OnInit {
    currentPurchaseCard: PurchaseCardModel;
    router: Router;
    constructor(private purchaseService: PurchaseService,
                private orderService: OrderService) { }
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
         this.orderService.AddToOrder();
    }
}
