using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace DataAccessLayer.DAL
{
    public class EventCofiguration:DbConfiguration
    {
        public EventCofiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());

        }
    }
}
