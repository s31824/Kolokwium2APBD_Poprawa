using System.ComponentModel.DataAnnotations;

namespace PoprawaKolokwium2APBD.Models;

public class Title
{
    [Key]
    public int TitleId { get; set; }
    [MaxLength(100)] 
    public string Name { get; set; } = null!;
    public virtual ICollection<CharacterTitle> CharacterTitles { get; set; } = null!;
}