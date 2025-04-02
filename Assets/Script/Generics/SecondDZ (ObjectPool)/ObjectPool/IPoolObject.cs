public interface IPoolObject<T>
{
    public void Init(T objectToPool, int count);
    public void Deinit(T objectToReturn);
}