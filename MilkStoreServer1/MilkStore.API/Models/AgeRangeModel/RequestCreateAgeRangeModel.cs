namespace MilkStore.API.Models.AgeRangeModel
{
    public class RequestCreateAgeRangeModel
    {
        public int AgeRangeID { get; set; }
        public string Baby { get; set; }
        public string Mama { get; set; }
        public int? ProductItemID { get; set; }
    }
}
