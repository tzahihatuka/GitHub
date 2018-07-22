import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MainComponent } from './main/main.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleInfoComponent } from './article-info/article-info.component';
import { articales } from './shared/data/json_list';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainComponent,
    ArticlesListComponent,
    ArticleInfoComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [articales],
  bootstrap: [AppComponent]
})
export class AppModule { }
