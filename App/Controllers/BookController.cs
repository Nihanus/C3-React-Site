using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

/// <summary>
/// Controler for getting books from the db
/// </summary>
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase{
    private IBookLook _bookLook;
    public BookController(IBookLook bookLook){
        _bookLook = bookLook;
    }
    /// <summary>
    /// Get all of the books in the DB
    /// </summary>
    /// <returns>HTTP 200 along with all of the books</returns>
    [HttpGet]
    public IActionResult GetBooks(){
        return Ok(_bookLook.GetBooks());
    }
    /// <summary>
    /// Gets one book from the db
    /// </summary>
    /// <param name="id">ID of the desired book</param>
    /// <returns>HTTP 200 with the data of the book</returns>
    [HttpGet("{id}")]
    public IActionResult GetBook(int id){
        var book = _bookLook.GetBook(id);
        return Ok(book);
    }
}
