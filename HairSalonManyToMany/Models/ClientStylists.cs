namespace HairSalonManyToMany.Models
{
    public class ClientStylists
    {
        public int ClientStylistsId;
        public int ClientId;
        public int StylistId;
        public virtual Client Client;
        public virtual Stylist Stylist;
    }
}