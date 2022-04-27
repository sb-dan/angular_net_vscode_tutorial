import { AppPreloadStrategy } from './app.loadingstrategy';
import { UserModule } from './../modules/user/user.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PreloadAllModules, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { StandardLayoutComponent } from '@layouts/standard-layout/standard-layout.component';
import { MinimalLayoutComponent } from '@layouts/minimal-layout/minimal-layout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    StandardLayoutComponent,
    MinimalLayoutComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatToolbarModule,
    MatButtonModule,
    FormsModule,
    RouterModule.forRoot(
      [
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        {
          path: '',
          component: StandardLayoutComponent,
          children: [
            { path: 'home', component: HomeComponent, pathMatch: 'full' },
            { path: 'fetch-data', component: FetchDataComponent },
          ],
        },
        {
          path: '',
          component: MinimalLayoutComponent,
          children: [{ path: 'counter', component: CounterComponent }],
        },
        {
          path: 'user',
          data: { preload: false, preloadDelay: 5000 },
          loadChildren: () =>
            import('@modules/user/user.module').then((m) => m.UserModule),
        },
      ],
      { preloadingStrategy: AppPreloadStrategy }
    ),
    BrowserAnimationsModule,
  ],
  providers: [AppPreloadStrategy],
  bootstrap: [AppComponent],
})
export class AppModule {}
