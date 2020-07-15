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
import { WordListComponent } from './word/word-list.component';
import { WordFormComponent } from './word/word-form/word-form.component';
import { WordUpdateComponent } from './word/word-update/word-update.component';
import { WordCollectionComponent } from './word-collection/word-collection.component';
import { WordCollectionCreateComponent } from './word-collection/word-collection-create/word-collection-create.component';

import { WordService } from './word/word.service';
import { WordCollectionService } from './word-collection/word-collection.service';
import { WordCollectionGameComponent } from './word-collection/word-collection-game/word-collection-game.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    WordListComponent,
    WordFormComponent,
    WordUpdateComponent,
    WordCollectionCreateComponent,
    WordCollectionComponent,
    WordCollectionGameComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'word', component: WordListComponent, canActivate: [AuthorizeGuard] },
      { path: 'wordCollection', component: WordCollectionComponent, canActivate: [AuthorizeGuard]},
      { path: 'wordCollection/create', component: WordCollectionCreateComponent, canActivate: [AuthorizeGuard]},
      { path: 'wordCollection/:id/game', component: WordCollectionGameComponent } 
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    WordService,
    WordCollectionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
