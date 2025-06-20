import { Injectable } from '@angular/core';
import { Heroi } from '../models/heroi';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { SuperPoder } from '../models/super-poder';
import { HeroiSaveDTO } from '../models/heroi-save-dto';

@Injectable({
  providedIn: 'root'
})
export class HeroiService {

  readonly apiUrl = "http://localhost:5131/api"

  constructor(private http: HttpClient) { }

  public getAllHerois() : Observable<Heroi[]> {
    return this.http.get<Heroi[]>(`${this.apiUrl}/Herois`);
  }

  public createHeroi(heroi: HeroiSaveDTO): Observable<Heroi> {
    return this.http.post<Heroi>(`${this.apiUrl}/Herois/`, heroi);
  }

  public updateHeroi(id: number, heroi: HeroiSaveDTO): Observable<Heroi> {
    return this.http.put<Heroi>(`${this.apiUrl}/Herois/${id}`, heroi);
  }

  public deleteHeroi(heroi: Heroi): Observable<Heroi> {
    return this.http.delete<Heroi>(`${this.apiUrl}/Herois/${heroi.id}`);
  }

  public getAllSuperpoderes(): Observable<SuperPoder[]>{
    return this.http.get<SuperPoder[]>(`${this.apiUrl}/Superpoderes`)
  }
}
