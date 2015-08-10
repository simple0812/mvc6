using System;
using Microsoft.Data.Entity;

public class MyDbContext : DbContext {
    public DbSet<TodoItem> Todos {get;set;}

    protected override void OnConfiguring(DbContextOptions builder) {
        //builder.UseSqlServer(@"server=.;User ID=sa;Password=123;DataBase=TodoItems;Persist Security Info=True;Pooling=true;Max Pool Size=700");
        builder.UseSqlServer(@"server=.;uid=sa;pwd=123;database=TodoItems;");
    }
}

public class TodoItem {
    public int Id {get;set;}
    public string Description {get;set;}
}