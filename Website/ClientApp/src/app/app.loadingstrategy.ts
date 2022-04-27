import { Injectable } from '@angular/core';
import { PreloadingStrategy, Route } from '@angular/router';
import { Observable, of, timer } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

@Injectable()
export class AppPreloadStrategy implements PreloadingStrategy {
  preload(route: Route, load: () => Observable<any>): Observable<any> {
    if (!route.data || !route.data.preload) return of(null);

    if (!route.data.preloadDelay) return load();

    return timer(route.data.preloadDelay).pipe(mergeMap(() => load()));
  }
}
