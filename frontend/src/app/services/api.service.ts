import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:44311/api';

  constructor(private http: HttpClient) { }

  register(user: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Auth/register`, user);
  }

  login(user: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Auth/login`, user);
  }

  // assignment endpoints
  assign(giverId: number, receiverId: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/Assignment/assign`, { giverId, receiverId});
  }

  deleteAssignment(data: any): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Assignment/my-assignment/delete`, data);
  }

  getAssignment(data: any): Observable<any> {
    return this.http.get(`${this.baseUrl}/Assignment/my-assignment`, data);
  }

  //gift endpoints

  getGifts(): Observable<any> {
    return this.http.get(`${this.baseUrl}/Gift/my-gifts`);
  }

  addGifts(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Gift/add`, data);
  }

  updateGifts(data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/Gift/update/{giftsId}`, data);
  }

  deleteGifts(data: any): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Gift/delete/{giftId}`, data);
  }

  // users endpoint

  getUsers(): Observable<any> {
    return this.http.get(`${this.baseUrl}/User/allUsers`);
  }

}
