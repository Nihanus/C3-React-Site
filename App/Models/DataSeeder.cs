namespace App.Models;

public class DataSeeder{
    private BookContext _context;

    public DataSeeder(BookContext context){
        _context = context;
    }

    public void SeededData(){
        _context.Books.AddRange(GetBookData());
        _context.SaveChanges();
    }

    private List<Book> GetBookData(){
        return new List<Book>{
            new Book{
                Id = 1,
                BookName = "Lord of the Rings",
                ReleaseYear = 1957,
                ImgPath = "https://cdn11.bigcommerce.com/s-gibnfyxosi/images/stencil/1920w/products/154740/156431/51eq24cRtRL__98083.1615576774.jpg?c=1"
            },
            new Book{
                Id = 2,
                BookName = "The Hobbit",
                ReleaseYear = 1937,
                ImgPath = "https://images.thenile.io/r1000/9780007487288.jpg"
            }
        };
    }
    private List<BookType> GetBookTypes(){
        return new List<BookType>{
            new BookType{
                Id = 1,
                Name = "Book"
            },
            new BookType{
                Id = 2,
                Name = "Audiobook"
            }
        };
    }
}