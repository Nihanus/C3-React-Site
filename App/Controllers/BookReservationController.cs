using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class BookReservationController : ControllerBase{
    private IBookReserve _bookReserve;

    public BookReservationController(IBookReserve bookReserve){
        _bookReserve = bookReserve;
    }

    [HttpGet("reservations")]
    public IActionResult GetReservations(){
        return Ok(_bookReserve.GetBookReservations());
    }

    [HttpPost]
    public IActionResult ReserveBook(BookReservation model){
        _bookReserve.ReserveBook(model);
        return Ok(new {message = "Book reservation succesful"});
    }
}