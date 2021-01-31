namespace Context.Model {
    public class Ingredients {
        public int Id { get; set; }
        public int ReciptsId { get; set; }
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public string IngProperty { get; set; }
        public virtual Products Products { get; set; }
    }
}
