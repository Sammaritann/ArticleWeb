import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { RegistrationComponent } from './Component/login/registration/registration.component';
import { ArticleComponent } from './Component/Article/article/article.component';
import { ArticleListComponent } from './Component/Article/article-list/article-list.component';
import { ArticleFormComponent } from './Component/Article/article-form/article-form.component';




const routes: Routes = [
{ path: '', redirectTo: '/articles', pathMatch: 'full' },
{path:"login",component:LoginComponent},
{path:"register",component:RegistrationComponent},
{path:"articles/:id",component:ArticleComponent},
{path:"articles", component:ArticleListComponent},
{path:"article",component:ArticleFormComponent},
{path:"article/:id", component:ArticleFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
