using Books.Core;
using Books.Core.Models;
using Books.Core.Repositories;
using Books.Core.Services;
using Books.Data;
using Books.Data.Repositories;
using Books.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookBuyerService, BookBuyerService>();
//builder.Services.AddScoped<IBookBuyRepository, BookBuyRepository>();

builder.Services.AddScoped<IBookSellerService, BookSaleService>();
//builder.Services.AddScoped<IBookSaleRepository, BookSaleRepository>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
builder.Services.AddScoped<IRepository<BookBuyer>, Repository<BookBuyer>>();
builder.Services.AddScoped<IRepository<BookSeller>, Repository<BookSeller>>();

builder.Services.AddDbContext<DataContext>();
//builder.Services.AddSingleton<DataContext>();

//builder.Services.AddSingleton<Mapping>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


// לצורך קשרי הגומלין ל DB
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; // או ReferenceHandler.Preserve
    });

builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
