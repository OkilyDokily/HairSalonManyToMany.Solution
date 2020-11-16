using System.Collections.Generic;

namespace HairSalonManyToMany.Models
{
  public class Stylist
  {
    public int StylistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<ClientStylist> Clients { get; set; }

    public Stylist()
    {
      this.Clients = new HashSet<ClientStylist>();
    }
  }
}