using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;

namespace net6.Migrations
{
    [ContextType(typeof(MyDbContext))]
    public partial class initial : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201508100838351_initial";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("TodoItem", b =>
                    {
                        b.Property<string>("Description");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}