using Newtonsoft.Json;

namespace Context.Model {
    public class User {
        public int Id { get; set; }
        public string UsName { get; set; }
        public string UsSurname { get; set; }
        [JsonIgnore]
        public string UsLogin { get; set; }
        [JsonIgnore]
        public string UsPassword { get; set; }
    }
}
