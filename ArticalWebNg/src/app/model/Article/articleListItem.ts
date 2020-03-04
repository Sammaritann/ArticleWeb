export class ArticleListItem {
    constructor(
        public articleId:string,
        public title:string,
        public createdUser:string,
        public createdDate:Date,
    ) { }
}