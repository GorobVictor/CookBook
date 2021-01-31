using System;

namespace Context.Model {
    public class Reviews {
        public int Id { get; set; }
        public int RevUserId { get; set; }
        public int RevRecipeId { get; set; }
        public int RevRating { get; set; }
        public string RevMessage { get; set; }
        public virtual DateTime RevDate { get; set; }
    }
}
