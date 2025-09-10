using System.ComponentModel.DataAnnotations;
using API.Dtos.Responses;
using dataaccess;

namespace api.Services;

public class PetService(MyDbContext ctx)
{
    public SellerDto CreateSellerWithPet(CreateSellerDto dto)
    {
        //always step 1: Data validation
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        
        //step 1b: data validation on the basis of existing data
        if (ctx.Sellers.Any(seller => seller.Name.Trim().ToLower().Equals(dto.Name.Trim().ToLower())))
            throw new ValidationException("SOMEONE ALREADY HAS THAT NAME");
        
        //step 2: objection instantiation / entity mapping
        var Id = Guid.NewGuid().ToString();
        var seller = new Seller()
        {
            Id = Id,
            Name = "Bob",
            Description = "asjdlksa"
        };
        var p = new Pet()
        {
            Name = "my cute pet",
            Id = Guid.NewGuid().ToString(),
            Breed = "cat",
            Createdat = DateTime.UtcNow,
            Price = 1239821398213,
            SoldDate = null,
            Seller = Id,
        };
  
        //step 3: Database queries and commands / 3rd party services and APIs
        ctx.Sellers.Add(seller);
        ctx.SaveChanges();
        ctx.Pets.Add(p);
        ctx.SaveChanges();
        
        //step 4: Map to response model
        var response =  new SellerDto(seller);

        //step 5: return statement
        return response;
    }
}