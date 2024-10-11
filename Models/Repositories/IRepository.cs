﻿namespace GESTION_DES_ARTICLES.Models.Repositories
{
    public interface IRepository<T>
    {
        T Get(int Id);
        IEnumerable<T> GetAll();
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
        List<T> Search(string term);
    }
}
