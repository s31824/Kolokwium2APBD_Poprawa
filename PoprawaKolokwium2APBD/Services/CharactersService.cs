using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium2APBD.Data;
using PoprawaKolokwium2APBD.DTOs;
using PoprawaKolokwium2APBD.Models;

namespace PoprawaKolokwium2APBD.Services;

public interface ICharacterService
{
    Task<CharacterGetDTO> GetCharacterById(int characterId);
    Task<int> AddItemsToBackpack(int characterId, List<int> request);
}

public class CharacterService(DatabaseContext context) : ICharacterService
{
    public async Task<CharacterGetDTO> GetCharacterById(int characterId)
    {
        var character = await context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .ThenInclude(t => t.Title)
            .FirstOrDefaultAsync(c => c.CharacterId == characterId);

        if (character == null)
        {
            throw new ArgumentException("Character not found");
        }
        
        var backpackItems = character.Backpacks.Select(backpack => new CharacterGetDTO.BackpackItem
        {
            ItemName = backpack.Item.Name,
            ItemWeight = backpack.Item.Weight,
            Amount = backpack.Amount
        }).ToList();
        var titles = character.CharacterTitles.Select(t => new CharacterGetDTO.Title
        {
            Name = t.Title.Name,
            AquiredAt = t.AcquiredAt
        }).ToList();

        return new CharacterGetDTO
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = backpackItems,
            Titles = titles
        };
    }

    public async Task<int> AddItemsToBackpack(int characterId, List<int> request)
    {
        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var character = await context.Characters
                .FirstOrDefaultAsync(c => c.CharacterId == characterId);

            if (character == null)
            {
                throw new ArgumentException("Character not found");
            }

            var newItemsWeight = 0;
            
            foreach (var itemId in request)
            {
                
                var item = await context.Items.FirstOrDefaultAsync(i => i.ItemId == itemId);
                
                if (item == null)
                {
                    throw new ArgumentException("Item not found");
                }
                
                newItemsWeight += item.Weight;
                
                await context.Backpacks.AddAsync(new Backpack
                {
                    CharacterId = characterId,
                    ItemId = itemId,
                    Amount = 1
                });
            }

            if (character.CurrentWeight + newItemsWeight < character.MaxWeight)
            {
                character.CurrentWeight += newItemsWeight;
            }
            else
            {
                throw new InvalidOperationException("Maximum weight exceeded");
            }
            
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        return 1;
    }
}