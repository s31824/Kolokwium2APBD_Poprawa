using Microsoft.AspNetCore.Mvc;
using PoprawaKolokwium2APBD.DTOs;
using PoprawaKolokwium2APBD.Services;

namespace PoprawaKolokwium2APBD.Controllers;


[ApiController]
[Route("api/[controller]/{characterId:int}")]
public class CharactersController(ICharacterService characterService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CharacterGetDTO>> GetCharacterById([FromRoute] int characterId)
    {
        try
        {
            return Ok(await characterService.GetCharacterById(characterId));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("backpacks")]
    public async Task<IActionResult> AddItemsToBackpack([FromRoute] int characterId, [FromBody] List<int> request)
    {
        try
        {
            await characterService.AddItemsToBackpack(characterId, request);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}