namespace MichelAPP.Models
{
    public class CoffeeModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string[] Ingredients { get; set; }
        public required string Image { get; set; }
        public string IngredientsList => string.Join(", ", Ingredients);
    }
}
