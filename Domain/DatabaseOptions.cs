namespace Domain
{
    public class DatabaseOptions
    {
#if DEBUG
        public const string DatabaseConnectionString = @"Data Source=DESKTOP-VTQHJ6A;Initial Catalog=PostMaker;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=True;Command Timeout=0";
#endif
#if RELEASE
        public const string DatabaseConnectionString = @"Server=tcp:padti.database.windows.net,1433;Initial Catalog=PostMaker;Persist Security Info=False;User ID=pad;Password=utmisa123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif
    }
}
