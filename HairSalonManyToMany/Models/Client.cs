using System.Collections.Generic;

namespace HairSalonManyToMany.Models
{
    public class Client
    {
        public int ClientId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}

        public virtual ICollection<ClientStylist> Stylists {get;set;}

        public Client()
        {
            this.Stylists = new HashSet<ClientStylist>();
        }
    }
}