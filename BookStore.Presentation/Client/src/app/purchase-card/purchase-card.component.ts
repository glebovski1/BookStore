import { Component, OnInit } from '@angular/core';
import { PurchaseCardModel, PurchaseModel } from 'app/models';
import { PurchaseService, OrderService } from 'app/Service';
import { Subscriber } from 'rxjs';
import { Routes, RouterModule, Router } from '@angular/router';
import { Token } from '@angular/compiler';


@Component({
  selector: 'app-purchase-card',
  templateUrl: './purchase-card.component.html'
})
export class PurchaseCardComponent implements OnInit {
  currentPurchaseCard: PurchaseCardModel;
  router: Router;
  handler: any;
  strripeTokenId: string;
  constructor(private purchaseService: PurchaseService,
              private orderService: OrderService) { }
  ngOnInit() {
    this.currentPurchaseCard = this.purchaseService.GetPurchaseCardFromLocalStorage();
    this.loadStripe();
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

  onBuy(amount) {

    const handler = ( window as any).StripeCheckout.configure({
      key: 'pk_test_GhI3dhTheEfuwO53bIyGMgjj005nqG8cvT',
      locale: 'auto',
      token: (token: {id: string; } ) => {
        this.orderService.AddPurchaseToOrderModel(token.id);
                }

      });
    handler.open({
        name:  'Demo Site',
        description:  '2 widgets',
        amount: amount * 100
      });
     
    }

  loadStripe() {

    if (!window.document.getElementById('stripe-script')) {
      const s = window.document.createElement('script');
      s.id = 'stripe-script';
      s.type = 'text/javascript';
      s.src = 'https://checkout.stripe.com/checkout.js';
      s.onload = () => {
        this.handler = ( window as any).StripeCheckout.configure({
          key: 'pk_test_aeUUjYYcx4XNfKVW60pmHTtI',
          locale: 'auto',
          token (token: any) {
            // You can access the token ID with `token.id`.
            // Get the token ID to your server-side code for use.
            console.log(token);
            alert('Payment Success!!');
          }
        });
      };

      window.document.body.appendChild(s);
    }
  }
}
