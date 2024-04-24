using Api.GildedRose.Dmi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/updatequality", () =>
{
    //get items from the database
    var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = "select * from items";
    var itemReader = cmd.ExecuteReader();
    
    var items = new List<Item>();

    while (itemReader.Read())
    {
        items.Add(new Item(
            itemReader.GetFieldValue<int>("ItemId"),
            itemReader.GetFieldValue<string>("Name"),
            itemReader.GetFieldValue<int>("SellIn"),
            itemReader.GetFieldValue<int>("Quality")
            ));
    }

    //update items quality
    var gildedRose = new GildedRose(items);
    gildedRose.UpdateQuality();
})
.WithName("UpdateQuality")
.WithOpenApi();

app.MapGet("/updatequality/{itemName}", (string itemName) =>
{
    //get items from the database
    var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
    conn.Open();

    var cmd = conn.CreateCommand();
    cmd.CommandText = $"select * from items where Name = '{itemName}'";
    var itemReader = cmd.ExecuteReader();

    var items = new List<Item>();

    while (itemReader.Read())
    {
        items.Add(new Item(
            itemReader.GetFieldValue<int>("ItemId"),
            itemReader.GetFieldValue<string>("Name"),
            itemReader.GetFieldValue<int>("SellIn"),
            itemReader.GetFieldValue<int>("Quality")
            ));
    }

    //update items quality
    var gildedRose = new GildedRose(items);
    gildedRose.UpdateQuality();
})
.WithName("UpdateQualityByName")
.WithOpenApi();

app.Run();


internal class Item(int ItemId, string Name, int SellIn, int Quality)
{
    public int ItemId { get; } = ItemId;
    public string Name { get; } = Name;
    public int SellIn { get; set; } = SellIn;
    public int Quality { get; set;  } = Quality;

    public override string ToString()
    {
        return this.Name + ", " + this.SellIn + ", " + this.Quality;
    }
}