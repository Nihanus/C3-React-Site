using System.ComponentModel.DataAnnotations;

namespace App.Models;

/// <summary>
/// Model for the book
/// </summary>
public class Book{
    [Key]
    public int Id {get; set;}
    public string? BookName { get; set; }
    public int ReleaseYear { get; set; }
    public string? ImgPath { get; set; }
}