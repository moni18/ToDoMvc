using System;


namespace Data.Domain.Base
{
    public interface IIdentifiable<TKey> where TKey: IComparable, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
