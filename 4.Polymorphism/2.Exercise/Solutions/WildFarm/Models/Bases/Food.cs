namespace WildFarm.Models
{
    public abstract class Food
    {
        protected Food(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; set; }
    }
}