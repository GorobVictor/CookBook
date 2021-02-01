using System.Collections.Generic;

namespace Context.Model {
    public class Recipts {
        public int Id { get; set; }
        public int RecCategoryId { get; set; }
        public string Recipt { get; set; }
        public int Caloric { get; set; }
        public string RecName { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<Reviews> Reviews { get; set; }
    }
}
