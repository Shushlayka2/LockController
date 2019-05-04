import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Code } from './code';

@Injectable({ providedIn: 'root' })
export class CodeService {
  codeUrl = 'https://lockserverapi.azurewebsites.net/api/code/';

  constructor(private http: HttpClient) { }

  getCodes(): Observable<Code[]> {
    return this.http.get<Code[]>(this.codeUrl + 'getcodes');
  }

  generateNewCode(): Observable<Code[]> {
    return this.http.get<Code[]>(this.codeUrl + 'generatecode');
  }

  delteCode(code: Code): Observable<Code[]> {
    return this.http.post<Code[]>(this.codeUrl + 'removecode', code);
  }
}
