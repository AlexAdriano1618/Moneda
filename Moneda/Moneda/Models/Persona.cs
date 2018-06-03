
namespace Moneda.Models
{
    using Newtonsoft.Json;
    public partial class Persona
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Cedula")]
        public string Cedula { get; set; }
        [JsonProperty(PropertyName = "Nombres")]
        public string Nombres { get; set; }
        [JsonProperty(PropertyName = "Apelllidos")]
        public string Apelllidos { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
    }
}
