namespace App.Services;

using App.Models;

public interface IBookLook{
    List<Book> GetBooks();
    Book GetBook(int id);
}

public class BookLook : IBookLook{
    private BookContext _context;
    public BookLook(BookContext context){
        _context = context;
        /*List<Book> books = new List<Book>{
            new Book{
                BookName = "Lord of the Rings",
                ReleaseYear = 1957,
                ImgPath = "https://cdn11.bigcommerce.com/s-gibnfyxosi/images/stencil/1920w/products/154740/156431/51eq24cRtRL__98083.1615576774.jpg?c=1"
            },
            new Book{
                BookName = "The Hobbit",
                ReleaseYear = 1937,
                ImgPath = "https://images.thenile.io/r1000/9780007487288.jpg"
            }
        };
        _context.Books.AddRange(books);
        _context.SaveChanges();*/
    }

    public List<Book> GetBooks(){
        return _context.Books.ToList();
    }

    public Book GetBook(int id){
        var book = _context.Books.Find(id);
        if(book == null){
            throw new KeyNotFoundException("Book not found");
        }
        return book;
    }
}