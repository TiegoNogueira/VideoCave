namespace VC.Data.Contexts
{
    public static class DBInitialize
    {
        public static void Initialize(VideoCaveContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}