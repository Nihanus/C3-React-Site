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
    }

    /// <summary>
    /// Get all books in the db
    /// </summary>
    /// <returns>List of all the books in db</returns>
    public List<Book> GetBooks(){
        return _context.Books.ToList();
    }

    /// <summary>
    /// Get a specific book
    /// </summary>
    /// <param name="id">ID of the desired book</param>
    /// <returns>The book with a matching id</returns>
    /// <exception cref="KeyNotFoundException">If there ar no books with the matching id</exception>
    public Book GetBook(int id){
        var book = _context.Books.Find(id);
        if(book == null){
            throw new KeyNotFoundException("Book not found");
        }
        return book;
    }
}