import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  private readonly apiUrl = 'http://localhost:8080/api/cdb/calculate'; // ou o endpoint real

  constructor(private http: HttpClient) {}

  getCdb(initialAmount: number, period: number): Observable<any> {
    const payload = {
      initialAmount: initialAmount,
      period: period
    };

    return this.http.post<any>(`${this.apiUrl}`, payload);
  }
}