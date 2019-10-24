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
  public getAll(): Observable<PrintingEditionModel[]> {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    return this.http.get<PrintingEditionModel[]>(`http://localhost:52192/api/printingedition/getall`, httpOptions);
    
  }
  public addPrintingEdition(printingEdition: PrintingEditionModel) {
    const httpOptions = this.authService.getHttpOptionsWithAccessToken();
    this.http.post<PrintingEditionModel>(`http://localhost:52192/api/printingedition/post`, printingEdition,
    httpOptions).subscribe();
    
    }
}