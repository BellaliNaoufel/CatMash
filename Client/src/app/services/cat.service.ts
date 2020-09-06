import { CatModel } from './../models/cat';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const baseUrl = 'https://localhost:44374/api/v1/';

@Injectable({
  providedIn: 'root'
})
export class CatService {

  constructor(private http: HttpClient) { }

  getAllCats(): Observable<CatModel[]> {
    return this.http
      .get<CatModel[]>(`${baseUrl}cats`)
      .pipe(catchError(this.handelError('getAllCats', [])));
  }

  getRandomTwoCats(): Observable<CatModel[]> {
    return this.http
      .get<CatModel[]>(`${baseUrl}cats/random`)
      .pipe(catchError(this.handelError('getRandomTwoCats', [])));
  }

  updateCat(cat: CatModel): Observable<any> {
    return this.http
      .put(
        baseUrl + `cats/${cat.id}`,
        cat
      )
      .pipe(
        tap(_ => console.log(`updated cat id=${cat.id}`)),
        catchError(this.handelError('updateCat'))
      );
  }

  resetDatabase(): Observable<any> {
    return this.http
    .post(`${baseUrl}reset`, null)
    .pipe(catchError(this.handelError('resetDatabase', [])));
  }

  private handelError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
