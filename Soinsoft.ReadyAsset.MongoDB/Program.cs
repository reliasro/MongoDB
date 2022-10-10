namespace Soinsoft.ReadyAsset.MongoDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string new_id;
            Console.WriteLine("MongoDB Atlas Sample CRUD");
            Console.WriteLine("=======");

            DBServices service = new DBServices();
            Console.WriteLine("Connected to MongoDB Atlas");

            //await service.CreateCollection("WorkOrder");
            Console.WriteLine("WorkOrder collection created");

            new_id= await service.InsertEquipment();
            Console.WriteLine("New equipment inserted");

            Console.WriteLine($"Id of the inserted equipment: {new_id}");

            var item = await service.GetEquipment(new_id);
            Console.WriteLine($"Equipment read: {item.Description}");

            Console.WriteLine("Editing. Type a description");
            string description = Console.ReadLine();

            if (description == "") description = "This equipment have been edited";

            item.Description = description;
            await service.UpdateEquipment(item);

            //Read again the equipment
            item = await service.GetEquipment(new_id);
            Console.WriteLine($"Reading... edited equipment: {item.Description}");


            await service.DeleteEquipment(new_id);
            Console.WriteLine($" Document {new_id} deleted from MongoDB Atlas");

            Console.WriteLine(" press any key to finish this application...");
            Console.ReadLine();
        }
    }
}
