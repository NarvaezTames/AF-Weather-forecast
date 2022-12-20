namespace WeatherForecastAppsFactory.Logic.Services
{
    /// <summary>
    /// Converts a TSource object  forecast into a TDestination object
    /// </summary>
    ///<inheritdoc/>
    public interface IConverter<TSource, TDestination>
    {
        /// <summary>
        /// Converts a TSource object  forecast into a TDestination object
        /// </summary>
        /// <param name="source">TObject</param>
        /// <returns>TDestination</returns>
        TDestination Convert(TSource source);
    }
}