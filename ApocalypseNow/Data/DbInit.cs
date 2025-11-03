using ApocalypseNow.Enums;
using ApocalypseNow.Models;
using Mtf.Extensions;
using SQLite;

namespace ApocalypseNow.Data;

public static class DbInit
{
    const string DbFileName = "apocalypse_checklist.db3";

    static string GetDbPath()
    {
        return Path.Combine(FileSystem.AppDataDirectory, DbFileName);
    }

    public static async Task InitializeAndSeedAsync()
    {
        var path = GetDbPath();
        var db = new SQLiteAsyncConnection(path);

        // create tables
        await db.CreateTableAsync<ChecklistItem>().ConfigureAwait(false);
        await db.CreateTableAsync<CatastropheTypeEntity>().ConfigureAwait(false);
        await db.CreateTableAsync<Measure>().ConfigureAwait(false);

        // seed checklist items if empty
        var cnt = await db.Table<ChecklistItem>().CountAsync().ConfigureAwait(false);
        if (cnt == 0)
        {
            var checklistSeed = new[]
            {
                new ChecklistItem { Title = "Water", Quantity = "10", Unit = "liters", Location = "Cellar", Priority = 11 },
                new ChecklistItem { Title = "Non-perishable food", Quantity = "21", Unit = "meals", Location = "Pantry", Priority = 11 },
                new ChecklistItem { Title = "First aid kit", Quantity = "1", Unit = "set", Location = "Hall", Priority = 10 },
                new ChecklistItem { Title = "Bicycle", Quantity = "1", Unit = "pcs", Location = "Garage", Priority = 9 },
                new ChecklistItem { Title = "Basic tools", Quantity = "1", Unit = "set", Location = "Toolbox", Priority = 9 },
                new ChecklistItem { Title = "Flashlight", Quantity = "2", Unit = "pcs", Location = "Kitchen", Priority = 8 },
                new ChecklistItem { Title = "Batteries", Quantity = "10", Unit = "pcs", Location = "Kitchen", Priority = 8 },
                new ChecklistItem { Title = "Powerbank", Quantity = "2", Unit = "pcs", Location = "Bedroom", Priority = 7 },
                new ChecklistItem { Title = "Radio (battery)", Quantity = "1", Unit = "pcs", Location = "Living room", Priority = 7 },
                new ChecklistItem { Title = "Warm clothing / blankets", Quantity = "4", Unit = "sets", Location = "Closet", Priority = 9 },
                new ChecklistItem { Title = "Multi-tool / Knife", Quantity = "1", Unit = "pcs", Location = "Toolbox", Priority = 9 },
                new ChecklistItem { Title = "Sanitation / hygiene kit", Quantity = "1", Unit = "set", Location = "Bathroom", Priority = 8 }
            };
            await db.InsertAllAsync(checklistSeed).ConfigureAwait(false);
        }

        // seed catastrophe types from enum if empty
        var ctCount = await db.Table<CatastropheTypeEntity>().CountAsync().ConfigureAwait(false);
        if (ctCount == 0)
        {
            var ctList = Enum.GetValues(typeof(CatastropheType))
                             .Cast<CatastropheType>()
                             .Select(e => new CatastropheTypeEntity
                             {
                                 Id = (int)e,
                                 Name = e.ToString(),
                                 Description = e.GetDescription()
                             })
                             .ToList();
            await db.InsertAllAsync(ctList).ConfigureAwait(false);
        }

        // seed basic measures if empty
        var mCount = await db.Table<Measure>().CountAsync().ConfigureAwait(false);
        if (mCount == 0)
        {
            var measures = new List<Measure>
            {
                // Flood
                new() { Title = "Move to higher ground", Description = "Go to upper floors or nearby safe high area", CatastropheTypeId = (int)CatastropheType.Flood, Priority = 11 },
                new() { Title = "Seal doors and vents", Description = "Use plastic/sandbags to block leaks", CatastropheTypeId = (int)CatastropheType.Flood, Priority = 9 },

                // Wildfire
                new() { Title = "Prepare evacuation bag", Description = "Grab essentials and leave early", CatastropheTypeId = (int)CatastropheType.Wildfire, Priority = 11 },
                new() { Title = "Create defensible space", Description = "Clear flammable material around home", CatastropheTypeId = (int)CatastropheType.Wildfire, Priority = 9 },

                // Earthquake
                new() { Title = "Drop, Cover, Hold On", Description = "Protect yourself during shaking", CatastropheTypeId = (int)CatastropheType.Earthquake, Priority = 11 },
                new() { Title = "Secure heavy furniture", Description = "Anchor shelves, water heaters", CatastropheTypeId = (int)CatastropheType.Earthquake, Priority = 9 },

                // Pandemic
                new() { Title = "Isolate symptomatic people", Description = "Keep sick family members separated", CatastropheTypeId = (int)CatastropheType.Pandemic, Priority = 10 },
                new() { Title = "Stock masks and sanitizer", Description = "Personal protective items", CatastropheTypeId = (int)CatastropheType.Pandemic, Priority = 8 },

                // PowerOutage
                new() { Title = "Check generator and fuel", Description = "Test backup power and store fuel safely", CatastropheTypeId = (int)CatastropheType.PowerOutage, Priority = 10 },
                new() { Title = "Gather flashlights and batteries", Description = "Accessible lighting", CatastropheTypeId = (int)CatastropheType.PowerOutage, Priority = 9 },

                // War
                new() { Title = "Identify nearest shelter", Description = "Know nearest official shelter or strong cover", CatastropheTypeId = (int)CatastropheType.War, Priority = 11 },
                new() { Title = "Secure important documents", Description = "Keep IDs and papers in waterproof bag", CatastropheTypeId = (int)CatastropheType.War, Priority = 9 }
            };

            await db.InsertAllAsync(measures).ConfigureAwait(false);
        }
    }
}