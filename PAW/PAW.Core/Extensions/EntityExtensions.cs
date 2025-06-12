using PAW.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Models.Enums;

namespace PAW.Core.Extensions
{
    public static class EntityExtensions
    {
        public static void AddAudit(this IEntity entity, string user)
        {
            if (entity.isDirty ?? false)
            {
                if (entity.TempID <= 0)
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = user;
                }
                else
                {
                    entity.ModifiedDate = DateTime.Now;
                    entity.ModifiedBy = user;
                }
            }
        }

        public static void AddLogging(this IEntity entity, LoggingType logginType) 
        {
            if (logginType == LoggingType.Create) 
            {
                Debug.WriteLine("Creating object!");
                return;
            }

            if (logginType == LoggingType.Update)
            {
                Debug.WriteLine("Updating object!");
                return;
            }

            if (logginType == LoggingType.Delete)
            {
                Debug.WriteLine("Deleting object!");
                return;
            }

            if (logginType == LoggingType.Read)
            {
                Debug.WriteLine("Reading object!");
                return;
            }
        }

    }
}
