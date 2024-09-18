namespace Menu.Models
{
    public class Ingredient
    {
        //id
        public int Id { get; set; }

        //name
        public string Name { get; set; }

        public List<DishIngredient> DishIngredients { get; set; }

    }
}
