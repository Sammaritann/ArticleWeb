export class Article {
    constructor(
        public articleId:string,
        public title:string,
        public createdUser:string,
        public createdDate:Date,
        public articleText:string
    ) { }
}