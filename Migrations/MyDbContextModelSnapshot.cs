using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;

namespace net6.Migrations
{
    [ContextType(typeof(MyDbContext))]
    public class MyDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
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