import { OrderItemsModel } from 'app/models/OrderItemsModel';
import { UserModel } from 'app/models/UserModel';
import { DatePipe } from '@angular/common';
import { PaymentModel } from 'app/models';

export class OrderModel {
    public description: string;
    public userid: number;
    public paymentid: number;
    public orderitemsmodel: Array<OrderItemsModel>;
    public usermodel: UserModel;
    public date: DatePipe;
    public payment: PaymentModel;
    public stripeToken: string;
    constructor() {}
}
