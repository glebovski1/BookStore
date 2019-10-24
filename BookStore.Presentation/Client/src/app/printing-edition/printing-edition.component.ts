import { Component, OnInit } from '@angular/core';
import { PrintingEditionService, AuthenticationService } from '../service';
import { PrintingEditionModel } from '../models';
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
  printingEditionModel: PrintingEditionModel;
  constructor(private printingEditionService: PrintingEditionService,
              private authService: AuthenticationService,
              private formBuilder: FormBuilder) {
    this.models = [];
  }
  selectedModel: PrintingEditionModel;
  onSelect(model: PrintingEditionModel): void {
    this.selectedModel = model;
    this.sekcondComumnType = 'DetailsPrintingEdition';
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

  onSubmit() {
    this.printingEditionModel = new PrintingEditionModel();
    this.printingEditionModel.Name = this.f.name.value;
    this.printingEditionModel.Description = this.f.description.value;
    this.printingEditionModel.Currency = this.f.currency.value;
    this.printingEditionModel.Type = this.f.type.value;
    this.printingEditionModel.Authors = this.f.authors.value;
    this.printingEditionModel.Price = this.f.price.value;
    this.printingEditionModel.Status = 'Available';
    this.printingEditionService.addPrintingEdition(this.printingEditionModel);
  }
  ngOnInit() {
    this.getAll();
    this.currentRole = this.authService.getRole();
    this.isAdminCondition = (this.currentRole === 'Admin');
  }
  getAll() {
    this.printingEditionService.getAll().subscribe(
      (data: PrintingEditionModel[]) => {
        this.models = data;

      },
      (error) => {
        this.errorText = error.Massage;
        this.authService.refreshToken();
      });
  }

}
