using usingMinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MapGet gibi endpoint tasarımlarında Delegate'in ProductService instance'ini parametre olarak alabilmesi için IoC'ye eklemelisiniz!
builder.Services.AddSingleton<ProductService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", (ProductService productService) =>
{
    return productService.GetProducts();
});

app.MapGet("/products/search/{name}", (ProductService productService, string name) => productService.SearchByName(name));

app.MapGet("/products/{id}", (ProductService productService, int id) => productService.GetById(id));

app.MapPost("/products", (ProductService productService, CreateProductRequest request) =>
{
    int id = productService.Create(request);
    return Results.Created($"/products/{id}", request);
});


var productService = app.Services.GetRequiredService<ProductService>();

app.Run();


