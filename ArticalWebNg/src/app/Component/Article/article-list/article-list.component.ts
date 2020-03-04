import { Component, OnInit } from '@angular/core';
import { ArticleListItem } from 'src/app/model/Article/articleListItem';
import { ArticleService } from 'src/app/Services/article.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {

 articles:ArticleListItem[];
 isAut =false;

  constructor(
    private authService:AuthenticationService,
    private articleService:ArticleService) 
  {}

  ngOnInit(): void {
    this.articleService.getArticles().subscribe(a=>this.articles=a);
    if(this.authService.currentUserValue)
    {
      this.isAut=true;
    }
  }

}
