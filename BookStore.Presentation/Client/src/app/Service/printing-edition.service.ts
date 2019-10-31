import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, filter, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { AuthenticationService } from 'app/Service/authentication.service';
import { environment } from 'environments/environment';
import { PrintingEditionModel, FilterModel } from 'app/models';



@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {
  token: string;
  constructor(private http: HttpClient, private authService: AuthenticationService) { }
  public getAll(page: number): Observable<PrintingEditionModel[]> {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    return this.http.post<PrintingEditionModel[]>(`${environment.apiUrl}printingedition/getall`, page, httpOptions);

  }
  public async addPrintingEdition(printingEdition: PrintingEditionModel): Promise<PrintingEditionModel> {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    return await this.http.post<PrintingEditionModel>(`${environment.apiUrl}printingedition/post`
    , printingEdition, httpOptions).toPromise();
  }
  public async deletePrintingEdition(id: number) {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    return await this.http.post<any>(`${environment.apiUrl}printingedition/delete`, id, httpOptions).toPromise();

  }

  public async getAllFiltred(filterModel: FilterModel): Promise<PrintingEditionModel> {
    return await this.http.post<any>(`${environment.apiUrl}printingedition/GetAllFiltred`, filterModel
    , this.authService.getHttpOptionsWithAccessToken()).toPromise();
        
  }
}