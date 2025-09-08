using System.ComponentModel.DataAnnotations;
using dataaccess;

namespace service;

public class PetService(MyDbContext dbContext)
{
    public async Task<Pet> CreatePet(CreatePetRequestDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        var pet = new Pet(id: Guid.NewGuid().ToString(), name: dto.Name, createdAt: DateTime.UtcNow, age: dto.Age);
        await dbContext.Pets.AddAsync(pet);
        await dbContext.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> DeletePet(string id)
    {
        var pet = dbContext.Pets.FirstOrDefault(p => p.Id == id) ??
                  throw new KeyNotFoundException($"Pet with id {id} not found");
        dbContext.Pets.Remove(pet);
        await dbContext.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> UpdatePet(CreatePetRequestDto dto, string id)
    {
        var pet = dbContext.Pets.FirstOrDefault(p => p.Id == id) ??
                  throw new KeyNotFoundException($"Pet with id {id} not found");
        //Overwriting the properties
        pet.Name = dto.Name;
        pet.Age = dto.Age;
        
        //Save
        await dbContext.SaveChangesAsync();
        return pet;
    }
}