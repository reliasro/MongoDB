using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Soinsoft.ReadyAsset.MongoDB
{
    internal class DBServices
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Equipment> _equipments;

        public DBServices()
        {
            //Create your MongoDB Atlas account and replace the connection string with yours
            //Create a database, collection and give permission to your IP Address
            //replace database/collection with the one you like

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://reliasro:uiaArxAMqsYnbR5S@cluster0.cavntu2.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(settings);
            _database = _client.GetDatabase("ReadyAsset");
            _equipments = _database.GetCollection<Equipment>("Equipment");
        }

        public async Task CreateCollection(string name)
        {
            await _database.CreateCollectionAsync(name);
        }

        public async Task DeleteEquipment(string id)
        {
            await _equipments.DeleteOneAsync(item => item._id == id);
        }

        public async Task UpdateEquipment(Equipment equipment)
        {
            await _equipments.FindOneAndReplaceAsync<Equipment>(equip => equip._id ==equipment._id, equipment);
        }

        public async Task<Equipment> GetEquipment(string id)
        {
            var result = await _equipments.FindAsync<Equipment>(equip => equip._id == id);
            return result.SingleOrDefault<Equipment>();
        }

        public async Task<string> InsertEquipment()
        {
            /*  await _equipments.InsertOneAsync(new Equipment { 
                   CurrentValue=9877,
                   Description="Truck",
                   LastMaintenance=DateTime.Now,
                   Location="DR",
                   Type=1,
                   Owner=new Customer { 
                       CompleteName="Juan Lopez",
                       CurrentBalance=5004
                   } 
               });*/

            Equipment equipment= new Equipment
            {
                CurrentValue = 80005,
                Description = "Kia Sorento 2015",
                LastMaintenance = DateTime.Now,
                Location = "Dominican Republic",
                Type = 1,
                Owner = new Company
                {
                    Address = "Avenuew 25852",
                    Contact = "Ricardo Torres Lead",
                    Country = "Puerto Rico",
                    Name = "Development Center of PR",
                    RegisterId = "000-Afff"
                }
            };

            await _equipments.InsertOneAsync(equipment);
            return equipment._id;

        }

    }
}
