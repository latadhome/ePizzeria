namespace ePizzeriaHub.Entities
{
    /// <summary>
    /// Pizza shop can have different categories Pizza, Drinks ..etc
    /// </summary>
    public class Category
    {
        public int Id { get; set; }  
        public string Name { get; set; }

        public string Description { get; set; }       

        public List<Item> Items { get; set; }        

    }
}