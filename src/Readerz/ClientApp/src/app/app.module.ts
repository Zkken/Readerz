import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CardListComponent } from './card/card-list.component';
import { CardFormComponent } from './card/card-form/card-form.component';
import { CardUpdateComponent } from './card/card-update/card-update.component';
import { CardSetComponent } from './card-set/card-set.component';
import { CardSetCreateComponent } from './card-set/card-set-create/card-set-create.component';

import { CardService } from './card/card.service';
import { CardSetService } from './card-set/card-set.service';
import { CardSetGameComponent } from './card-set/card-set-game/card-set-game.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CardListComponent,
    CardFormComponent,
    CardUpdateComponent,
    CardSetCreateComponent,
    CardSetComponent,
    CardSetGameComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cards/:id', component: CardListComponent, canActivate: [AuthorizeGuard] },
      { path: 'cards', component: CardSetComponent, canActivate: [AuthorizeGuard]},
      { path: 'cards/create', component: CardSetCreateComponent, canActivate: [AuthorizeGuard]},
      { path: 'cards/:id/game', component: CardSetGameComponent } 
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    CardService,
    CardSetService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
