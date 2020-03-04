import { Component, OnInit } from '@angular/core';
import { Article } from 'src/app/model/Article/article';
import { ArticleService } from 'src/app/Services/article.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommentService } from 'src/app/Services/comment.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { UpdateComment } from 'src/app/model/Comment/update-comment';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

  article:Article;
  comments:Comment[];
  isAut =false;
  isCommenting = false;
  updateComment = new UpdateComment("","");
  id:string;
  constructor(
    private authService:AuthenticationService,
    private route: ActivatedRoute,
    private router: Router,
    private articleService: ArticleService,
    private commentService:CommentService) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.articleService.getArticle(p['id']).subscribe(a => this.article = a);
      this.commentService.getComments(p['id']).subscribe(c=>this.comments = c);
      this.id=p['id'];
    });
    if(this.authService.currentUserValue)
    {
      this.isAut=true;
    }
  }

  onAddComment()
  {
    this.updateComment.createdUser = this.authService.currentUserValue.userName;
    this.commentService.addComment(this.id,this.updateComment).subscribe(c=>{
      this.comments.push(c);
      this.isCommenting=false;
      this.updateComment.commentText="";
      this.updateComment.createdUser="";
    });
  }

}
