namespace Api_Northwind.Service
{
    public interface IService<TEntity> where TEntity : class
    {
       

       List<TEntity> Search1(string abc);
    }
}
