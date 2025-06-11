using System.ComponentModel.DataAnnotations;

namespace PoprawaKolokwium2APBD.Models;

public class Character
{
    [Key]
    public int CharacterId { get; set; }

    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(120)]
    public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    public virtual ICollection<CharacterTitle> CharacterTitles { get; set; } = null!;
    public virtual ICollection<Backpack> Backpacks { get; set; } = null!;
}