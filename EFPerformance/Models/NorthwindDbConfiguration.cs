using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFPerformance.Models
{
    public class NorthwindDbConfiguration : DbConfiguration
    {
        public NorthwindDbConfiguration()
        {
            SetDatabaseInitializer(new NullDatabaseInitializer<NorthwindDb>());
            SetManifestTokenResolver(new CustomManifestTokenResolver());
        }
    }

    public class CustomManifestTokenResolver : IManifestTokenResolver
    {
        public string ResolveManifestToken(DbConnection connection)
        {
            return "2012";
        }

    }

}