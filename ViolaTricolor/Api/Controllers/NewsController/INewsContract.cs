namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Контракт новости
    /// </summary>
    public interface INewsContract
    {
        /// <summary>
        /// Типы новостей
        /// </summary>
        NewsType NewsType { get; }
    }
}
