namespace Sample
{
    public interface IFactory<in TArg, out TResult>
    {
        TResult Create(TArg arg);
    }

    public interface IFactory<in TArg1, in TArg2, out TResult>
    {
        TResult Create(TArg1 arg1, TArg2 arg2);
    }
}