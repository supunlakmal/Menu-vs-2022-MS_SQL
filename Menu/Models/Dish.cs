namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        //price
        public double Price { get; set; }


        // need toget list of  DishIngredeients
        public List<DishIngredient> DishIngredients { get; set; }



    }
}
