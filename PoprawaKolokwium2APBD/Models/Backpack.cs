using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PoprawaKolokwium2APBD.Models;

[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class Backpack
{
    [Column("Character_ID")]
    public int CharacterId { get; set; }
    [Column("Item_ID")]
    public int ItemId { get; set; }
    public int Amount { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public virtual Character Character { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; }
}