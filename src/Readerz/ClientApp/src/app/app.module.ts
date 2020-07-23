import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ApiAuthorizationModule } from '../api-authorization/api-authorization.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CardsIdComponent } from './cards/cards-id/cards-id.component';
import { CardFormComponent } from './cards/card-form/card-form.component';
import { CardsComponent } from './cards/cards.component';
import { CardsCreateComponent } from './cards/cards-create/cards-create.component';

import { AuthorizeGuard } from '../api-authorization/authorize.guard';
import { AuthorizeInterceptor } from '../api-authorization/authorize.interceptor';

import { CardSetService } from './services/card-set.service';
import { CurrentUserService } from './services/current-user-service';
import { CardService } from './services/card.service';
import { CardsGameComponent } from './cards/cards-game/cards-game.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CardsComponent,
    CardsCreateComponent,
    CardsIdComponent,
    CardFormComponent,
    CardsGameComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    AngularFontAwesomeModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cards', component: CardsComponent, canActivate: [AuthorizeGuard] },
      { path: 'cards/create', component: CardsCreateComponent, canActivate: [AuthorizeGuard] },
      { path: 'cards/:id', component: CardsIdComponent, canActivate: [AuthorizeGuard] }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    CardSetService,
    CurrentUserService,
    CardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
