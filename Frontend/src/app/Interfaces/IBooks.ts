export interface IBook {
    id: number;
    name: string;
    price: number;
    discount: number;
    image: string;
    about: string;
    publishYear: number;
    pageCount: number;
    authorName: string;
    publisherName: string;
    translatorName: string;
    categoryName: string;
  }
  
  
  export  class AddBook{
    name: string;
    price: number;
    discount: number;
    image: string;
    about: string;
    publishYear: number;
    pageCount: number;
    authorId:number;
    publisherId:number;
    translatorId:number;
    categoryId:number;
  }