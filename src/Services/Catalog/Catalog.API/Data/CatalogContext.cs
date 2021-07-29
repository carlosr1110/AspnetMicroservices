using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;

        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            var client = new MongoClient(configuration.GetConnectionString("DefaultConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("ConnectionStrings:DatabaseName"));
            var Products = database.GetCollection<Product>(configuration.GetValue<string>("ConnectionStrings:CollectionName"));
        }

        public IMongoCollection<Product> Products { get; }
    }
}
