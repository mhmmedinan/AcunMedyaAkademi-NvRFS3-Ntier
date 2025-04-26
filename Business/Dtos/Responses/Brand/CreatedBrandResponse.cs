namespace Business.Dtos.Responses.Brand
{
    public record CreatedBrandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
