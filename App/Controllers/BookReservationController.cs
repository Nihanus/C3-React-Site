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

    /// <summary>
    /// Get the list of book reservations that the user has made
    /// </summary>
    /// <returns>List of book reservations</returns>
    [HttpGet("reservations")]
    public IActionResult GetReservations(){
        return Ok(_bookReserve.GetBookReservations());
    }

    /// <summary>
    /// Writes to the db information of the books reservation
    /// </summary>
    /// <param name="model">Data model for book reservations</param>
    /// <returns>HTTP 200</returns>
    [HttpPost]
    public IActionResult ReserveBook(BookReservation model){
        _bookReserve.ReserveBook(model);
        return Ok(new {message = "Book reservation succesful"});
    }
}