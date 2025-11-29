namespace Domain
{
    public class DatabaseOptions
    {
#if DEBUG
        public const string DatabaseConnectionString = @"Data Source=DESKTOP-VTQHJ6A;Initial Catalog=PostMaker;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=True;Command Timeout=0";
#endif
#if RELEASE
        public const string DatabaseConnectionString = @"";
#endif
    }
}
