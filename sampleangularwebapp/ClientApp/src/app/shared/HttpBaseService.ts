import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
//import { AppConfiguration } from 'src/app/shared/models';
import { Observable } from 'rxjs';
//import { fpQueryOptions } from 'src/app/shared/types';
import { map } from 'rxjs/operators';
import { puts } from 'util';

export abstract class HttpBaseService {
  private _baseUrl: string;

  constructor(private http: HttpClient, private baseServiceUrl: string) {
    this._baseUrl = baseServiceUrl + '/v1/';
  }

  protected get<TData>(
    relativeUrl: string,
    // options?: fpQueryOptions,
  ): Observable<TData> {
    const url = this._baseUrl + relativeUrl;

    //const preparedOptions = this.prepareOptions(options);

    const response = this.http.get<TData>(url, { observe: 'response' });

    return null; //this.processOnResponse(response);
  }
  

}
