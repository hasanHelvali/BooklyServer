namespace Bookly.Application.Common.Exceptions;
/// <summary>
/// Bulunamadı Durumları İçin Hata Dönen Custom Exception Class'ıdır.
/// </summary>
public sealed class NotFoundException:Exception
{
    public NotFoundException(string message) : base(message) { }
}
