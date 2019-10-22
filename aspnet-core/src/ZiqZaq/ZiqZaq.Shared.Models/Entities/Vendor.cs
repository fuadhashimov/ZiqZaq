namespace ZiqZaq.Shared.Models.Entities
{
    public class Vendor 
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string AgencyEmail { get; set; }
        public string HomePhone { get; set; }
        public string Website { get; set; }
        public string FacebookAddress { get; set; }
        public string InstagramAddress { get; set; }
        public string TwitterAddress { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}