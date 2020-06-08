using System;

namespace Subra.SSL_SMS.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        string CreateUser { get; set; }
        DateTime CreateDate { get; set; }
        string UpdateUser { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
