import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { take } from "rxjs/operators";
import { environment } from '@environments/environment';
import { Company,Currency } from '@app/models';

const baseUrl = `${environment.apiUrl}/company`;

@Injectable({ providedIn: 'root' })
export class CompanyService {
    constructor(private http: HttpClient) { }
   
    getAll(): Observable<any[]> {
        return this.http.get<Company[]>(baseUrl);
    }
    getById(id: string) {
        return this.http.get<Company>(`${baseUrl}/${id}`);
    }
    create(params: any) {
        return this.http.post(baseUrl, params);
    }
    update(id: string, params: any) {
        return this.http.put(`${baseUrl}/${id}`, params);
    }
    delete(id: string) {
        return this.http.delete(`${baseUrl}/${id}`);
    }
}