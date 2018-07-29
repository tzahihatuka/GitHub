import { Component } from '@angular/core';
import { RootObject } from "./../shared/models/book-root-object.model";
import { bookInfo } from '../shared/models/book-data.model';
import { Book } from '../shared/models/book.model';

@Component({
    selector: 'app-book-list',
    templateUrl: './book-list.component.html',
    styleUrls: ['./book-list.component.css']
})
export class BookListComponent {
    public localBookData: RootObject;
    public selectedBook: Book;


    public setSelectedBook(bookId: string): void {
        for (let i of this.localBookData.items) {
            if (i.id == bookId){
              
                this.selectedBook = i;
                
            }  
        }
    }

    public constructor() {
        this.localBookData = bookInfo;

        for (let i = 0; i < this.localBookData.items.length; i++) {
            let temp: string = this.localBookData.items[i].volumeInfo.title;


            /** substring - (built in function in js - for string type)
            * Returns the substring at the specified location within a String object.
            * @param start The zero-based index number indicating the beginning of the substring.
            * @param end Zero-based index number indicating the end of the substring. The substring includes the characters up to, but not including, the character indicated by end.
            * If end is omitted, the characters from start through the end of the original string are returned.
            */
            this.localBookData.items[i].volumeInfo.title = temp.substring(0, 16);
        }
    }

}
