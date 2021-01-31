namespace Context.Model {
    public class Products {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public int UnitsId { get; set; }
        public string ProdDescription { get; set; }
        public Units Units { get; set; }
    }
}
