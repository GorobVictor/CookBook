using System;

namespace Context.Model {
    public class Reviews {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ReciptsId { get; set; }
        public Int16 RevRating { get; set; }
        public string RevMessage { get; set; }
        public DateTime RevDate { get; set; }
    }
}
