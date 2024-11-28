﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductJudgeAPI.Entities;

namespace ProductJudgeAPI
{
    public class BooksService
    {
        public readonly IMongoCollection<Book> _booksCollection;

        public BooksService(
            IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetAsync(FilterDefinition<Book>? filter = null)
        {
            filter ??= Builders<Book>.Filter.Empty;  // Usa un filtro vacío si no se proporciona ninguno
            return await _booksCollection.Find(filter).ToListAsync();
        }

        public async Task<List<Book>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}