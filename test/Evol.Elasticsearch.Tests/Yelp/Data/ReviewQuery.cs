using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Evol.Elasticsearch.Tests.Yelp.Model;
using MySql.Data;

namespace Evol.Elasticsearch.Tests.Yelp.Data
{
    public class ReviewQuery
    {
        IDbConnection connection;

        public ReviewQuery()
        {
            connection = YelpConnectionFactory.Instance.GetMySqlConnection("yelpConnection");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<Review> Query(int flag, int size = 100)
        {
            var items = connection.Query<Review>("SELECT id, stars, `date`, `text`, useful, funny, cool, business_id as businessId, user_id as userId, flag FROM review WHERE flag = @flag LIMIT 0, @size", new { flag, size });
            return items.AsList();
        }

        public bool Flaged(string id, int flag = 1)
        {
            var num = connection.Execute("UPDATE review set flag = @flag WHERE id = @id", new { flag, id });
            return num == 1;
        }

    }
}
