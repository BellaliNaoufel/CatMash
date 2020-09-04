namespace CatMash.Domain.Entities.DTO
{
    public partial class ApiResponse
    {
        public Image[] Images { get; set; }
    }

    public partial class Image
    {
        public string Url { get; set; }
        public string Id { get; set; }
    }
}