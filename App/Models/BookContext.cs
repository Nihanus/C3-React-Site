namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class BookContext : DbContext{
    public BookContext(DbContextOptions<BookContext> options) : base(options){

    }

    public DbSet<Book> Books {get; set;} = null!;
    public DbSet<BookReservation> Reservations {get; set;} = null!;

}