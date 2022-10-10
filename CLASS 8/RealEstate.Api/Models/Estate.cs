namespace RealEstate.Api.Models
{
    public class Estate
    {
        private long Id { get; set; }

        private string EstateName { get; set; }

        private string ContactPersonName { get; set; }

        private string ContactPersonPhone { get; set; }

        private string ContactPersonEmail { get; set; }

        private string Address  { get; set; }

        private int RoomNumber  { get; set; }

        private int BathroomNumber { get; set; }

        private int Area { get; set; }

        private int Price { get; set; }

        private string Photo { get; set; }

        private List<string> Photos { get; set; }
    }
}
