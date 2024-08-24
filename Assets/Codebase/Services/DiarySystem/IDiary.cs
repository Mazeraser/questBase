namespace Codebase.Services.DiarySystem
{
    public interface IDiary<T>
    {
        public void Add(T obj);
        public T[] Get();
    }
}