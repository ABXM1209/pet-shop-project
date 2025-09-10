using api;
using API.Dtos.Responses;
using api.Services;
using Microsoft.AspNetCore.Mvc;

public class PetShopController(PetService petService) : ControllerBase
{
    [HttpGet(nameof(CreateSellerWithAPetAndReturn))]
    public SellerDto CreateSellerWithAPetAndReturn([FromBody]CreateSellerDto dto)
    {
        var result = petService.CreateSellerWithPet(dto);
        return result;
    }
}