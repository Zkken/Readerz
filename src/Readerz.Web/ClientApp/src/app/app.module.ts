import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ApiAuthorizationModule } from '../api-authorization/api-authorization.module';
import { ReactiveFormsModule }   from '@angular/forms';

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
import { CardService } from './services/card.service';
import { CardsGameComponent } from './cards/cards-game/cards-game.component';
import { TextComponent } from './text/text.component';
import { TextService } from './services/text.service';
import { TextCreateComponent } from './text/text-create/text-create.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule, MatTable} from '@angular/material/table';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { MatPaginatorModule } from '@angular/material/paginator';

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
    TextComponent,
    TextCreateComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cards', component: CardsComponent, canActivate: [AuthorizeGuard] },
      { path: 'cards/create', component: CardsCreateComponent, canActivate: [AuthorizeGuard] },
      { path: 'cards/:id', component: CardsIdComponent, canActivate: [AuthorizeGuard] },
      { path: 'cards/:id/game', component: CardsGameComponent, canActivate: [AuthorizeGuard]},
      { path: 'text', component: TextCreateComponent, canActivate: [AuthorizeGuard] }
    ]),
    BrowserAnimationsModule,
    MatPaginatorModule,
    MatTableModule,
    FontAwesomeModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    CardSetService,
    CardService,
    TextService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
