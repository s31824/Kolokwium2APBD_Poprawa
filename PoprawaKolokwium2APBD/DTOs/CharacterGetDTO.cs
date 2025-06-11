namespace PoprawaKolokwium2APBD.DTOs;

public class CharacterGetDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<BackpackItem> BackpackItems { get; set; } = null!;
    public List<Title> Titles { get; set; } = null!;





    public class BackpackItem
    {
        public string ItemName { get; set; } = null!;
        public int ItemWeight { get; set; }
        public int Amount { get; set; }
    }

    public class Title
    {
        public string Name { get; set; } = null!;
        public DateTime AquiredAt { get; set; }
    }
}