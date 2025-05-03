﻿namespace Business.Dtos.Responses.Model;

public class CreatedModelResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
