using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Handle
{
    interface IClient
    {

    }

    public partial class nullClient : IClient
    {
        public int id { get; set; }
        public string client_name { get; set; }
        public System.DateTime birth_date { get; set; }

        public nullClient()
        {
            this.id = 0;
            this.client_name = "undefinded";
            this.birth_date = new DateTime(0, 0, 0);
        }
    }
    static class ClientFactory
    {
        public static IClient GetClient(string type_client, string name_string, string date_string, int _parent_id = 0)
        {
            switch(type_client)
            {
                case "PHYS": return new PhysClients { birth_date = Convert.ToDateTime(date_string), client_name = name_string };
                case "COMPANY": return new CompanyClients { create_date = Convert.ToDateTime(date_string), company_name = name_string,parent_id=_parent_id };
                default : return new nullClient();
            }
    }
}
}
