namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public static class DBSetExtension
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
