using System.Collections.Generic;

namespace HairSalonManyToMany.Models
{
  public class Stylist
  {
    public int StylistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Client> Clients { get; set; }

    public Stylist()
    {
      Clients = new HashSet<Client>();
    }
  }
}