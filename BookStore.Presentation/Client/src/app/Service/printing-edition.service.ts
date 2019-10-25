import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PrintingEditionModel } from '../models';
import { Observable } from 'rxjs';
import { map, filter, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/service/authentication.service';



@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {
  token: string;
    constructor(private http: HttpClient, private authService: AuthenticationService) { }
  public getAll(page: number): Observable<PrintingEditionModel[]> {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    return this.http.post<PrintingEditionModel[]>(`http://localhost:52192/api/printingedition/getall`, page,  httpOptions);
    
  }
  public addPrintingEdition(printingEdition: PrintingEditionModel) {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    this.http.post<PrintingEditionModel>(`http://localhost:52192/api/printingedition/post`, printingEdition,
    httpOptions).subscribe();
    }
    public deletePrintingEdition(id: number){
      const httpOptions = this.authService.getHttpOptionsWithAccessToken();
this.http.post<any>(`http://localhost:52192/api/printingedition/delete`, id, httpOptions).subscribe();

    }
}