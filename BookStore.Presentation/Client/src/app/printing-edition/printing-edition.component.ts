import { Component, OnInit } from '@angular/core';
import { PrintingEditionService, AuthenticationService, PurchaseService } from 'app/Service';
import { PrintingEditionModel, AuthorModel, FilterModel, PurchaseModel, PurchaseCardModel } from 'app/models';
import { error } from 'util';
import { getLocaleNumberFormat } from '@angular/common';
import { Observable, Subscriber } from 'rxjs';
import { HttpBackend } from '@angular/common/http';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';


@Component({
  selector: 'app-printing-edition',
  templateUrl: './printing-edition.component.html',
  styleUrls: ['./printing-edition.component.css']
})
export class PrintingEditionComponent implements OnInit {

  models: PrintingEditionModel[];
  errorText: string;
  currentRole: string;
  isAdminCondition: boolean;
  sekcondComumnType: string;
  AddNewPrintingEditionForm: FormGroup;
  FilterPrintingEdition: FormGroup;
  pageNumber: number;
  printingEditionModel: PrintingEditionModel;
  filteModel: FilterModel;
  purchase: PurchaseModel;
  purchaseCard: PurchaseCardModel;
  selectedModel: PrintingEditionModel;
  amountInpute: FormGroup;
  constructor(private printingEditionService: PrintingEditionService,
              private authService: AuthenticationService,
              private formBuilder: FormBuilder,
              private purchaseService: PurchaseService) {
    this.models = [];
  }

  ngOnInit() {
    this.currentRole = this.authService.getRole();
    this.isAdminCondition = (this.currentRole === 'Admin');
    this.pageNumber = 1;
    this.getAll();
    this.amountInpute = this.formBuilder.group({
      amount: 1
    });
  }
  onSelect(model: PrintingEditionModel) {
    this.selectedModel = model;
    this.sekcondComumnType = 'DetailsPrintingEdition';
  }
  onDelete(model: PrintingEditionModel) {
    this.printingEditionService.deletePrintingEdition(model.id).then(() => { this.getAll(); });
    this.getAll();
  }
  onAddPrintingEdition() {
    this.sekcondComumnType = 'AddPrintingEdition';
    this.AddNewPrintingEditionForm = this.formBuilder.group(
      {
        name: '',
        description: '',
        price: '',
        currency: '',
        type: '',
        authors: ''
      }
    );
  }
  get f() { return this.AddNewPrintingEditionForm.controls; }

  onAddToCard() {
    this.purchaseCard = this.purchaseService.GetPurchaseCardFromLocalStorage();
    if (!this.purchaseCard) {
      this.purchaseCard = new PurchaseCardModel();
    }
    this.purchase = new PurchaseModel();
    this.purchase.id = this.selectedModel.id;
    this.purchase.name = this.selectedModel.name;
    this.purchase.price = this.selectedModel.price;
    this.purchase.currency = this.selectedModel.currency;
    this.purchase.amount = this.amountInpute.controls.amount.value;
    this.purchaseCard.PurchaseModels.forEach(element => {
      if (element.id === this.purchase.id) {
        const result = element.amount + this.purchase.amount;
        element.amount = result;
      }
    });
    if (!this.purchaseCard.PurchaseModels.find(purchas => purchas.id === this.purchase.id)) {
      this.purchaseCard.PurchaseModels.push(this.purchase);
    }
    if (!this.purchaseCard.PurchaseModels) {
      this.purchaseCard.PurchaseModels = new Array<PurchaseModel>();
      this.purchaseCard.PurchaseModels.push(this.purchase);
    }
    
    this.purchaseService.AddPurchaseCardToLocalStorage(this.purchaseCard);

  }

  onPreviousPage() {
    this.pageNumber--;
    this.getAll();
  }
  onNextPage() {
    this.pageNumber++;
    this.getAll();
  }
  onPageNumber(page: number) {
    this.pageNumber = page;
    this.getAll();
  }
  onRefresh() {
    this.getAll();
  }
  onFilter() {
    this.sekcondComumnType = 'filter';
    this.FilterPrintingEdition = this.formBuilder.group(
      {
        name: '',
        type: '',
        uperPrice: '0',
        lowerPrice: '0',
        author: ''
      }
    );
  }
  get ffilter() { return this.FilterPrintingEdition.controls; }

  onFilterPrintingEdition() {
    this.filteModel = new FilterModel();
    this.filteModel.name = this.ffilter.name.value;
    this.filteModel.author = this.ffilter.author.value;
    this.filteModel.type = this.ffilter.type.value;
    this.filteModel.uperprice = this.ffilter.uperPrice.value;
    this.filteModel.lowerprice = this.ffilter.lowerPrice.value;
    this.filteModel.pagenumber = this.pageNumber;
    this.printingEditionService.getAllFiltred(this.filteModel).then((data: any) => {
      this.models = data;
    },
      (error) => {
        this.errorText = error.Massage;
        this.authService.refreshToken();
      })
      .then(() => { });
  }

  onSubmit() {
    this.printingEditionModel = new PrintingEditionModel();
    this.printingEditionModel.name = this.f.name.value;
    this.printingEditionModel.description = this.f.description.value;
    this.printingEditionModel.currency = this.f.currency.value;
    this.printingEditionModel.type = this.f.type.value;
    const AuthorsNamesArray = this.f.authors.value.split(',', 100);
    this.printingEditionModel.authors = Array<AuthorModel>();
    AuthorsNamesArray.forEach((element: string) => {
      this.printingEditionModel.authors.push(new AuthorModel(element));
    });
    this.printingEditionModel.price = this.f.price.value;
    this.printingEditionModel.status = 'Available';
    this.printingEditionService.addPrintingEdition(this.printingEditionModel)
      .then(() => { this.getAll(); });
  }

  getAll() {
    this.printingEditionService.getAll(this.pageNumber).subscribe(
      (data: PrintingEditionModel[]) => {
        this.models = data;
      },
      (error) => {
        this.errorText = error.Massage;
        this.authService.refreshToken();
      });
  }
}
