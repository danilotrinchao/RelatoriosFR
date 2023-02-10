namespace RelatorioFr.Core.ApplicationService.Ports
{
    public interface IRepository<T> where T : class
    {
        public T Get(string NomeRelatorio);
        public IEnumerable<T> GetAll();
        public T Insert(T t);
        public void Update(T t);
        public void Delete(int id);
    }
}
