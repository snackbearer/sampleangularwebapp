import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from './product';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class ProductService {

  private apiURL: string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiURL = baseUrl + "api/product";
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiURL);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(this.apiURL + "/" + id.toString());
  }

  addProduct(entity: Product): Observable<Product> {
    return this.http.post<Product>(this.apiURL, entity, httpOptions);
  }

  updateProduct(id: number, entity: Product): Observable<any> {
    return this.http.put(this.apiURL + "/" + id.toString(), entity, httpOptions);
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete(this.apiURL + "/" + id.toString(), httpOptions);
  }
}
