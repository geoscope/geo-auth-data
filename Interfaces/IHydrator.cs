namespace geo_auth_data.Interfaces
{
    public interface IHydrator<TIn, TOut>
    {
        TOut Hydrate(TIn record);
    }
}