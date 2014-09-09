namespace CarsFactory.MySQL.Models
{
    using System.Linq;

    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public partial class CarsFactoryMySQL : OpenAccessContext, ICarsFactoryMySQLUnitOfWork
    {
        private static string connectionStringName = @"CarsFactoryDB";

        private static BackendConfiguration backend = GetBackendConfiguration();

        private static MetadataSource metadataSource = new CarsFactoryMySQLMetadataSource();

        public CarsFactoryMySQL()
            : base(connectionStringName, backend, metadataSource)
        {
        }

        public CarsFactoryMySQL(string connection)
            : base(connection, backend, metadataSource)
        {
        }

        public CarsFactoryMySQL(BackendConfiguration backendConfiguration)
            : base(connectionStringName, backendConfiguration, metadataSource)
        {
        }

        public CarsFactoryMySQL(string connection, MetadataSource metadataSource)
            : base(connection, backend, metadataSource)
        {
        }

        public CarsFactoryMySQL(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
            : base(connection, backendConfiguration, metadataSource)
        {
        }

        public IQueryable<Product> Products
        {
            get
            {
                return this.GetAll<Product>();
            }
        }

        public static BackendConfiguration GetBackendConfiguration()
        {
            BackendConfiguration backend = new BackendConfiguration();

            backend.Runtime.AllowCascadeDelete = true;
            backend.Backend = "MySql";
            backend.ProviderName = "MySql.Data.MySqlClient";

            CustomizeBackendConfiguration(ref backend);

            return backend;
        }

        static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
    }
}