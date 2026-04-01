namespace Bookly.Application.Common.Exceptions;
/// <summary>
/// İş Kuralları Ihlalleri İçin Hata Dönen Custom Exception Class'ıdır.
/// </summary>
public sealed class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
}
