using dataaccess;
using Microsoft.AspNetCore.Mvc;
using service;

public class PetController(PetService petService) : ControllerBase
{
    [HttpGet(nameof(CreatePet))]
    public async Task<Pet> CreatePet()
    {
        var dto = new CreatePetRequestDto("bobie", "cat", DateTime.Now,DateOnly.FromDayNumber(11111), 999, "id");
        return await petService.CreatePet(dto);
    }
}