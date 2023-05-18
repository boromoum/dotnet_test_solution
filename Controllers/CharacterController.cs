using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMG.TestSolution.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CMG.TestSolution.Api.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CharacterController : ControllerBase
  {

    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
      this._characterService = characterService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
    {
      return Ok(await _characterService.GetAllCharacters());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
    {
      return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost("Add")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {
      return Ok(await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      var response = await _characterService.UpdateCharacter(updatedCharacter);
      if (response.Data is null)
      {
        return NotFound(response);
      }
      else { return Ok(response); }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
    {
      var response = await _characterService.DeleteCharacter(id);
      if (response.Data is null)
      {
        return NotFound(response);
      }
      else { return Ok(response); }
    }
  }
}