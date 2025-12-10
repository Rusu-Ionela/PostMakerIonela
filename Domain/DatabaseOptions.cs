namespace Domain
{
    public class DatabaseOptions
    {
        public const string DatabaseConnectionString =
            "Server=tcp:padioana.database.windows.net,1433;Initial Catalog=PostMakerIonela;Persist Security Info=False;User ID=ionela201527;Password=Ioana201527;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
namespace Domain
{
    public class DatabaseOptions
    {
#if DEBUG
        // Conexiune LOCALĂ – când rulezi cu IIS Express pe PC
        public const string DatabaseConnectionString =
            @"Data Source=DESKTOP-VTQHJ6A;Initial Catalog=PostMaker;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=True;Command Timeout=0";
#endif

#if RELEASE
        // Conexiune AZURE – când publici aplicația
        public const string DatabaseConnectionString =
            "Server=tcp:padioana.database.windows.net,1433;Initial Catalog=PostMakerIonela;Persist Security Info=False;User ID=ionela201527;Password=Ioana201527;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif
    }
}
