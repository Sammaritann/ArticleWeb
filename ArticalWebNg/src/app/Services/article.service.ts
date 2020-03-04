import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from '../model/Article/article';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ArticleListItem } from '../model/Article/articleListItem';
import { UpdateArticle } from '../model/Article/updateArticle';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  private url = environment.apiUrl + '/articles';
  constructor(    
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router,) { }
    
    getArticles():Observable<Array<ArticleListItem>>
    {
      return this.http.get<Array<ArticleListItem>>(this.url);
    }

    getArticle(id:string):Observable<Article>
    { 
      return this.http.get<Article>(`${this.url}/${id}`);
    }

    addArtcile(updateArticle:UpdateArticle):Observable<Article>
    {
      return this.http.post<Article>(`${this.url}`,updateArticle);
    }

    updateArticle(id:string,updateArticle:UpdateArticle):Observable<Article>
    {
      return this.http.put<Article>(`${this.url}/${id}`,updateArticle);
    }

    deleteArticle(id:string):Observable<Object>
    {
      return this.http.delete(`${this.url}/${id}`);
    }
}
