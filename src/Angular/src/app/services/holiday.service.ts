import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Holiday } from '../models/holiday.model';

@Injectable({
  providedIn: 'root'
})
export class HolidayService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Holiday[]> {
    return this.http.get<Holiday[]>(environment.apiUrl);
  }

  get(id: any): Observable<Holiday> {
    return this.http.get(`${environment.apiUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(environment.apiUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${environment.apiUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/${id}`);
  }

  getWithFilter(title: string, date: string): Observable<Holiday[]> {
    return this.http.get<Holiday[]>(`${environment.apiUrl}?title=${title}&date=${date}`);
  }
}
