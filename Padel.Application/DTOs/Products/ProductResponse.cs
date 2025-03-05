namespace Padel.Application.DTOs.Productos;

public record ProductResponse(
    int Id,
    string Name,
    decimal Price,
    DateTime CreationDate
);


