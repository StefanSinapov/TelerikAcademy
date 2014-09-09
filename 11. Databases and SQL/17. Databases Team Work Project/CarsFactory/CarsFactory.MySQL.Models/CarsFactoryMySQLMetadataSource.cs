namespace CarsFactory.MySQL.Models
{
    using System.Collections.Generic;

    using Telerik.OpenAccess.Metadata;
    using Telerik.OpenAccess.Metadata.Fluent;

    public partial class CarsFactoryMySQLMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var productMapping = new MappingConfiguration<Product>();

            productMapping.MapType(product => new
            {
                ID = product.ID,
                ManufacturerName = product.ManufacturerName,
                Model = product.Model,
                HorsePower = product.HorsePower,
                ReleaseYear = product.ReleaseYear,
                Price = product.Price
            }).ToTable("Products");

            productMapping.HasProperty(p => p.ID).IsIdentity(KeyGenerator.Autoinc);

            configurations.Add(productMapping);

            return configurations;
        }

        protected override void SetContainerSettings(MetadataContainer container)
        {
            container.Name = "CarsFactoryReports";
            container.DefaultNamespace = "CarsFactory.Reports.Models";
            container.NameGenerator.SourceStrategy = Telerik.OpenAccess.Metadata.NamingSourceStrategy.Property;
            container.NameGenerator.RemoveCamelCase = false;
        }
    }
}