import { Component, OnInit } from '@angular/core';
import { PrintingEditionService, AuthenticationService } from '../service';
import { PrintingEditionModel, AuthorModel } from '../models';
import { error } from 'util';
import { getLocaleNumberFormat } from '@angular/common';
import { Observable } from 'rxjs';
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
  pageNumber: number;
  printingEditionModel: PrintingEditionModel;
  constructor(private printingEditionService: PrintingEditionService,
              private authService: AuthenticationService,
              private formBuilder: FormBuilder) {
    this.models = [];
  }
  selectedModel: PrintingEditionModel;
  ngOnInit() {
    this.currentRole = this.authService.getRole();
    this.isAdminCondition = (this.currentRole === 'Admin');
    this.pageNumber = 1;
    this.getAll();
  }
   onSelect(model: PrintingEditionModel) {
    this.selectedModel = model;
    this.sekcondComumnType = 'DetailsPrintingEdition';
  }
  onDelete(model: PrintingEditionModel) {
     this.printingEditionService.deletePrintingEdition(model.id);
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

  onPreviousPage() {
    this.pageNumber = this.pageNumber - 1;
    this.getAll();
  }
  onNextPage() {
    this.pageNumber = this.pageNumber + 1;
    this.getAll();
  }
  onPageNumber(page: number) {
    this.pageNumber = page;
    this.getAll();
  }


  onSubmit() {
    this.printingEditionModel = new PrintingEditionModel();
    this.printingEditionModel.name = this.f.name.value;
    this.printingEditionModel.description = this.f.description.value;
    this.printingEditionModel.currency = this.f.currency.value;
    this.printingEditionModel.type = this.f.type.value;
    const AuthorsNamesArray = this.f.authors.value.split(',', 100);
    AuthorsNamesArray.forEach(element => {
      this.printingEditionModel.authors.push(new AuthorModel(element));
    });
    this.printingEditionModel.price = this.f.price.value;
    this.printingEditionModel.status = 'Available';
    this.printingEditionService.addPrintingEdition(this.printingEditionModel);
    this.getAll();
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
