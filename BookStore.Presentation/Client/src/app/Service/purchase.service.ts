import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PurchaseCardModel, PurchaseModel } from '../models';

@Injectable({ providedIn: 'root' })
export class PurchaseService {

    public AddPurchaseCardToLocalStorage(purchaseCard: PurchaseCardModel) {
localStorage.setItem('purchaseCard', JSON.stringify(purchaseCard));
    }

    public GetPurchaseCardFromLocalStorage(): PurchaseCardModel {
        const purchaseCardModel = JSON.parse(localStorage.getItem('purchaseCard'));
        return purchaseCardModel;
    }
 }