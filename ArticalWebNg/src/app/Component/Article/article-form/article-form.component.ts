import { Component, OnInit } from '@angular/core';
import { UpdateArticle } from 'src/app/model/Article/updateArticle';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ArticleService } from 'src/app/Services/article.service';


@Component({
  selector: 'app-article-form',
  templateUrl: './article-form.component.html',
  styleUrls: ['./article-form.component.css']
})
export class ArticleFormComponent implements OnInit {

  updateArticle = new UpdateArticle("","","");
  existed = false;
  id:string;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private articleService:ArticleService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.articleService.getArticle(p['id']).subscribe(a => {
        this.updateArticle.articleText = a.articleText;
        this.updateArticle.createdUser = a.createdUser;
        this.updateArticle.title = a.title;
        this.id=p['id'];
      });
      this.existed = true;
    });
  }
  
  navigateToMain()
  {
    this.router.navigate(['/']);
  }
  
  onCancel() {
    this.navigateToMain();
  }
  
  onSubmit() {
    if(this.existed)
    {
      this.articleService.updateArticle(this.id,this.updateArticle).subscribe(p=>this.navigateToMain());
    }
    else
    {
      this.updateArticle.createdUser = JSON.parse(localStorage.getItem('currentUser')).userName;
      this.articleService.addArtcile(this.updateArticle).subscribe(p=>this.navigateToMain());
    }
  }

  onDelete() 
  {
    if(this.existed)
    {
      this.articleService.deleteArticle(this.id).subscribe(p=> this.navigateToMain());
    }
  }

}
