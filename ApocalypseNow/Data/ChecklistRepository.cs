using ApocalypseNow.Models;
using SQLite;

namespace ApocalypseNow.Data;

internal class ChecklistRepository
{
    const string DbFileName = "apocalypse_checklist.db3";
    readonly SQLiteAsyncConnection db;

    public ChecklistRepository()
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, DbFileName);
        db = new SQLiteAsyncConnection(path);
    }

    // Expose DB path if you need it elsewhere
    public static string GetDbPath() => Path.Combine(FileSystem.AppDataDirectory, DbFileName);

    // Create tables (safe to call multiple times)
    public Task InitDbAsync()
    {
        return db.CreateTablesAsync(CreateFlags.None,
            typeof(ChecklistItem),
            typeof(CatastropheTypeEntity),
            typeof(Measure));
    }

    // ChecklistItem CRUD
    public Task<List<ChecklistItem>> GetAllChecklistItemsAsync() => db.Table<ChecklistItem>().ToListAsync();
    public Task<ChecklistItem> GetChecklistItemAsync(string id) => db.FindAsync<ChecklistItem>(id);
    public Task SaveChecklistItemAsync(ChecklistItem item) => db.InsertOrReplaceAsync(item);
    public Task DeleteChecklistItemAsync(string id) => db.DeleteAsync<ChecklistItem>(id);

    // Bulk save
    public Task SaveChecklistItemsAsync(IEnumerable<ChecklistItem> items)
    {
        return db.RunInTransactionAsync(conn =>
        {
            foreach (var it in items)
                conn.InsertOrReplace(it);
        });
    }

    // CatastropheType CRUD
    public Task<List<CatastropheTypeEntity>> GetAllCatastropheTypesAsync() => db.Table<CatastropheTypeEntity>().ToListAsync();
    public Task InsertCatastropheTypesAsync(IEnumerable<CatastropheTypeEntity> list) => db.InsertAllAsync(list);

    // Measures CRUD
    public Task<List<Measure>> GetMeasuresByTypeAsync(int catastropheTypeId)
        => db.Table<Measure>().Where(m => m.CatastropheTypeId == catastropheTypeId).ToListAsync();

    public Task<List<Measure>> GetAllMeasuresAsync() => db.Table<Measure>().ToListAsync();
    public Task SaveMeasureAsync(Measure m) => db.InsertOrReplaceAsync(m);
    public Task DeleteMeasureAsync(string id) => db.DeleteAsync<Measure>(id);

    // Count helpers
    public Task<int> ChecklistCountAsync() => db.Table<ChecklistItem>().CountAsync();
    public Task<int> CatastropheTypeCountAsync() => db.Table<CatastropheTypeEntity>().CountAsync();
    public Task<int> MeasuresCountAsync() => db.Table<Measure>().CountAsync();
}