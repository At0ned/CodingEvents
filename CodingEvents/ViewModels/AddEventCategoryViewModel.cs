using System.ComponentModel.DataAnnotations;

namespace CodingEvents;

public class AddEventCategoryViewModel
{
[Required]
[StringLength(20), MinLength(3)]    
public string? CategoryName {get; set;}

}
