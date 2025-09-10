using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public record CreatePetRequestDto
{
    public CreatePetRequestDto(string name, string breed, DateTime createdAt, DateOnly soldDate, int price, string sellerId)
    {
        Name = name;
        Breed = breed;
        CreatedAt = createdAt;
        SoldDate = soldDate;
        Price = price;
        SellerId = sellerId;
    }

    [MinLength(3)]
    public string Name { get; set; }
    public string Breed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateOnly SoldDate { get; set; }
    public int Price { get; set; }
    public string SellerId { get; set; }
}