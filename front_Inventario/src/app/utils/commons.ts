import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, throwError } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class Commons {
  // URL DE API
  private _URL = environment.API_URL;

  constructor(private http: HttpClient) {}

  //* PETICIONES HTTP

  //* --------------
  //* POST
  //* --------------
  postReq(url: string, params: any = null) {
    const _endPoint = `${this._URL}/${url}`;
    return this.http.post(_endPoint, params).pipe(
      tap((rs) => {
        return rs;
      }),
      catchError((err, caught): any => {
        console.error('ERROR: ', err);
        console.error('CAUGHT: ', caught);
        return this.handleError(err);
      })
    );
  }

  //* MANEJO DE ERRORES HTTP
  handleError(error: HttpErrorResponse) {
    console.group('HANDLE ERROR--------------');
    console.error('ERROR: ', error);
    if (error.status === 0) {
      // this.showAlert(
      //   'No se pudo establecer conexion con el servidor: ' + error.message,
      //   'ERROR'
      // );
      console.error(
        'No se pudo establecer conexion con el servidor: ' + error.message
      );
    } else {
      if (error.error != undefined && error.error.object != undefined) {
        //  this.showAlert(error.error.object, 'Error!');
        console.error('ERROR SPECIFIC: ' + error.error.object);
      }
    }
    console.groupEnd();
    return throwError(
      () =>
        new Error(
          'Algo a salido mal; intente mas tarde.' + JSON.stringify(error.error)
        )
    );
  }
}
