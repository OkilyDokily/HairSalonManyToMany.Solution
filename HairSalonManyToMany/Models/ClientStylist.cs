

namespace HairSalonManyToMany.Models
{
  public class ClientStylist
  {
    public int ClientStylistId { get; set; }
    public int ClientId { get; set; }
    public int StylistId { get; set; }
    public virtual Client Client { get; set; }
    public virtual Stylist Stylist { get; set; }
  }
}