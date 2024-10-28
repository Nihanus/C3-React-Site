namespace App.Test;

using Xunit;
using System.ComponentModel.DataAnnotations;
using App.Models;
using App.Services;
using App.Helpers;

public class BookReservationTests
{
    [Theory]
    [InlineData("lord", "2024-11-1", "2024-11-13", true, "book", 27.2d)]
    [InlineData("lord", "2024-11-1", "2024-11-20", false, "audiobook", 48.6d)]
    [InlineData("lord", "2024-11-1", "2024-11-13", false, "book", 22.2d)]
    [InlineData("lord", "2024-11-1", "2024-11-20", true, "audiobook", 53.6d)]
    public void ReserveBookPriceIsCorrect(string name, string startDay, string endDay, bool quickPickUp, string typeOfBook, double expectedPrice)
    {
        var controller = new BookReserve();
        expectedPrice = Math.Round(expectedPrice, 2);
        var reservation = new BookReservation{BookName=name, StartDay=DateTime.Parse(startDay), EndDay=DateTime.Parse(endDay), QuickPickUp=quickPickUp, TypeofBook=typeOfBook};

        double price = controller.GetPriceOfBook(reservation);

        price = Math.Round(price, 2);

        Assert.Equal(expectedPrice, price);
    }

    [Theory]
    [InlineData("lord", "2024-11-1", "2024-10-13", true, "book")]
    public void EndDayIsBeforeStartDay(string name, string startDay, string endDay, bool quickPickUp, string typeOfBook){
        var controller = new BookReserve();
        var reservation = new BookReservation{BookName=name, StartDay=DateTime.Parse(startDay), EndDay=DateTime.Parse(endDay), QuickPickUp=quickPickUp, TypeofBook=typeOfBook};

        try{
            controller.GetPriceOfBook(reservation);
        }
        catch(Exception ex){
            Assert.Equal(ex.GetType(),typeof(AppException));
        }
    }
}