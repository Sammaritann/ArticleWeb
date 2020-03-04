export class Comment {
    constructor(
        public commentId:string,
        public createdUser:string,
        public createdDate:Date,
        public commentText:string
    ) { }
}