import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { AuthenticationService, PurchaseService } from 'app/Service';
import { PurchaseCardModel, OrderItemsModel, OrderModel, PurchaseModel } from 'app/models';
import { CurrentUserModel } from 'app/models/CurrentUserModel';

@Injectable({
    providedIn: 'root'
})
export class OrderService {
    purchaseCard: PurchaseCardModel;
    orderModel: OrderModel;
    orderItemsModel: OrderItemsModel;
    curentUser: CurrentUserModel;
    constructor(private http: HttpClient,
                private authService: AuthenticationService,
                private purchaseService: PurchaseService) { }
    public AddPurchaseToOrderModel(stripeToken: string) {
        this.purchaseCard = this.purchaseService.GetPurchaseCardFromLocalStorage();

        this.orderModel = new OrderModel();
        this.orderModel.userid = this.authService.getId();
        this.orderModel.stripeToken = stripeToken;
        this.orderModel.orderitemsmodel = new Array<OrderItemsModel>();
        this.purchaseCard.PurchaseModels.forEach(purchaseModel => {
            this.orderItemsModel = new OrderItemsModel();
            this.orderItemsModel.amount = purchaseModel.amount;
            this.orderItemsModel.currency = purchaseModel.currency;
            this.orderItemsModel.printingEditionId = purchaseModel.id;
            this.orderModel.orderitemsmodel.push(this.orderItemsModel);
        });
        const HttpOpts = this.authService.getHttpOptionsWithAccessToken();
        this.http.post<OrderModel>(`${environment.apiUrl}payment/AddOrder`, this.orderModel, HttpOpts).subscribe();
    }
}

