import { MinimalLayoutComponent } from './../../app/layouts/minimal-layout/minimal-layout.component';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignOnComponent } from './sign-on/sign-on.component';
import { StandardLayoutComponent } from 'src/app/layouts/standard-layout/standard-layout.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [SignOnComponent, ProfileComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: 'user',
        component: StandardLayoutComponent,
        children: [
          { path: '', redirectTo: 'profile', pathMatch: 'full' },
          { path: 'profile', component: SignOnComponent },
        ],
      },
      {
        path: 'user',
        component: MinimalLayoutComponent,
        children: [{ path: 'signon', component: SignOnComponent }],
      },
    ]),
  ],
})
export class UserModule {}
