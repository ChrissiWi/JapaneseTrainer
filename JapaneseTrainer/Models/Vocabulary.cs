using System.ComponentModel.DataAnnotations;

namespace JapaneseTrainer.Models;

public class Vocabulary
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Japanese word is required")]
    [MinLength(1, ErrorMessage = "Japanese word cannot be empty")]
    public string JapaneseWord { get; set; } = string.Empty;

    [Required(ErrorMessage = "Translation is required")]
    [MinLength(1, ErrorMessage = "Translation cannot be empty")]
    public string Translation { get; set; } = string.Empty;

} 