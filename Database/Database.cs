using LiteDB;
using ServerSettings = Mirror.Settings.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Database
{
    public static class DatabaseUtilities
    {
        /// <summary>
        /// Insert a class into the database and create a collection of those types. If you want to update a collection pull the data before you push it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Upsert<T>(T data)
        {
            using (var db = new LiteDatabase(ServerSettings.DatabaseLocation + ServerSettings.DatabaseFile))
            {
                return db.GetCollection<T>().Upsert(data);
            }
        }

        /// <summary>
        /// Update Data if it exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateData<T>(T data)
        {
            using (var db = new LiteDatabase(ServerSettings.DatabaseLocation + ServerSettings.DatabaseFile))
            {
                return db.GetCollection<T>().Update(data);
            }
        }

        /// <summary>
        /// Get a single class from the database based on the field type. ie. "PlayerName" "Stuyk"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Get<T>(string fieldName, BsonValue data)
        {
            using (var db = new LiteDatabase(ServerSettings.DatabaseLocation + ServerSettings.DatabaseFile))
            {
                return db.GetCollection<T>().FindOne(Query.EQ(fieldName, data));
            }
        }

        /// <summary>
        /// Get a single class based on the id location in the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetById<T>(int id)
        {
            using (var db = new LiteDatabase(ServerSettings.DatabaseLocation + ServerSettings.DatabaseFile))
            {
                return db.GetCollection<T>().FindOne(Query.EQ("UserID", id));
            }
        }

        /// <summary>
        /// Return all documents from a collection by Type / Class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetCollection<T>()
        {
            using (var db = new LiteDatabase(ServerSettings.DatabaseLocation + ServerSettings.DatabaseFile))
            {
                return db.GetCollection<T>().FindAll();
            }
        }

        /// <summary>
        /// Check if the collection of Class name exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Exists<T>()
        {
            using (var db = new LiteDatabase(ServerSettings.DatabaseLocation + ServerSettings.DatabaseFile))
            {
                return db.CollectionExists(typeof(T).Name);
            }
        }
    }
}
