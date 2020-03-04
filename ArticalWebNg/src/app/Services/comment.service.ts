import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { UpdateComment } from '../model/Comment/update-comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private url = environment.apiUrl + '/articles';
  constructor( 
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router,) { }

    getComments(articleId:string):Observable<Array<Comment>>
    {
      return this.http.get<Array<Comment>>(`${this.url}/${articleId}/comments`);
    }

    addComment(articleId:string, updateComment:UpdateComment):Observable<Comment>
    {
      return this.http.post<Comment>(`${this.url}/${articleId}/comments`,updateComment);
    }

    updateComment(articleId:string, id:string,updateComment:UpdateComment):Observable<Comment>
    {
      return this.http.put<Comment>(`${this.url}/${articleId}/comments/${id}`,updateComment);
    }

    deleteComment(articleId:string,id:string):Observable<Object>
    {
      return this.http.delete(`${this.url}/${articleId}/comments/${id}`);
    }
}
