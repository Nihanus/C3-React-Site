namespace App.Services;

using App.Helpers;
using App.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

public interface IBookReserve{
    BookReservation[] GetBookReservations();
    void ReserveBook(BookReservation model);
}

public class BookReserve : IBookReserve{
    private BookContext _context;
    public BookReserve(BookContext context){
        _context = context;
        /*List<BookType> types = new List<BookType>{
            new BookType{
                Name = "Book"
            },
            new BookType{
                Name = "Audiobook"
            }
        };
        _context.Types.AddRange(types);
        _context.SaveChanges();*/
    }
    public BookReserve(){
        _context = null;
    }

    public double GetPriceOfBook(BookReservation model){
        double price = 0;
        var type = model.TypeofBook;

        string tempDate = DateTime.Now.ToString("yyyy/MM/dd");
        DateTime currentDate = DateTime.Parse(tempDate);

        if(type == null){
            throw new AppException("Book type must be selected");
        }
        if(model.StartDay.CompareTo(model.EndDay) > 0){
            throw new AppException("Day of book return can't be before day of pickup");
        }
        else if(model.StartDay.CompareTo(model.EndDay) == 0){
            throw new AppException("Day of return can't be the same day as day of pickup");
        }
        else if(model.StartDay.CompareTo(currentDate) < 0){
            throw new AppException("Can't reserve book before current day");
        }
        else if(model.StartDay.CompareTo(currentDate) == 0 && !model.QuickPickUp){
            throw new AppException("Can't pick up the book today if you didn't choose \"Quick pick up\"");
        }

        TimeSpan duration = model.EndDay.Subtract(model.StartDay);
        if(type == "book"){
            price = 2*duration.Days;
        }
        else if(type == "audiobook"){
            price = 3*duration.Days;
        }

        if(duration.Days > 10){
            price *= 0.8;
        }
        else if(duration.Days > 3){
            price *= 0.9;
        }

        price += 3;
        if(model.QuickPickUp){
            price += 5;
        }

        return price;
    }
    public void ReserveBook(BookReservation model){
        double price = GetPriceOfBook(model);
        model.PriceOfBook = price;
        _context.Reservations.Add(model);
        _context.SaveChanges();
    }

    public BookReservation[] GetBookReservations(){
        return _context.Reservations.ToArray();
    }
}