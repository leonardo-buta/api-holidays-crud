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
    return this.http.get<Holiday[]>(`${environment.apiUrl}/Holiday`);
  }

  get(id: any): Observable<Holiday> {
    return this.http.get(`${environment.apiUrl}/Holiday/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/Holiday`, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${environment.apiUrl}/Holiday/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/Holiday/${id}`);
  }

  getWithFilter(title: string, date: string): Observable<Holiday[]> {
    return this.http.get<Holiday[]>(`${environment.apiUrl}/Holiday?title=${title}&date=${date}`);
  }
}
