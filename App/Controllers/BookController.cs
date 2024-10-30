using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase{
    private IBookLook _bookLook;
    public BookController(IBookLook bookLook){
        _bookLook = bookLook;
    }
    [HttpGet]
    public IActionResult GetBooks(){
        return Ok(_bookLook.GetBooks());
    }
    [HttpGet("{id}")]
    public IActionResult GetBook(int id){
        var book = _bookLook.GetBook(id);
        return Ok(book);
    }
}
