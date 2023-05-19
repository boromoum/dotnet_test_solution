using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMG.TestSolution.Api.Data;
using CMG.TestSolution.Api.Models.Responses;

namespace CMG.TestSolution.Api.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    private static List<Character> characters = new List<Character> {
        new Character(),
        new Character{ Id = 1,  Name= "Sonal"}
    };
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CharacterService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var character = _mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(character);
      serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      try
      {
        var character = characters.FirstOrDefault(c => c.Id == id);

        if (character is null)
          throw new Exception($"Character with Id '{id}' not found'");
        characters.Remove(character);
        serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }
      return serviceResponse;

    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var dbCharacters = await _context.Characters.ToListAsync();
      serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
      if (dbCharacter is not null)
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
      return serviceResponse;
      throw new Exception("Character not found");
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      try
      {
        var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

        if (character is null)
          throw new Exception($"Character with Id '{updatedCharacter.Id}' not found'");
        _mapper.Map(updatedCharacter, character);
        // character.Name = updatedCharacter.Name;
        // character.HitPoints = updatedCharacter.HitPoints;
        // character.Strength = updatedCharacter.Strength;
        // character.Defense = updatedCharacter.Defense;
        // character.Intell = updatedCharacter.Intell;
        // character.RpgClass = updatedCharacter.RpgClass;
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }
      return serviceResponse;

    }
  }
}