//using System;
//using System.Linq.Expressions;
//using System.Diagnostics;
//using Evol.FirstEC.EFRepository.Model;
//using Evol.Utilities.Expressions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Evol.Utilities.Tests;
//using Evol.Utilities.Sql;
//using System.Collections;
//using System.Collections.Generic;

//namespace Evol.Utilities.Test.Expressions
//{
//    [TestClass]
//    public class DynamicExpressionTest
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//            Expression<Func<int, int, int, int, int>> f = (a, b, c, d) => a * b * c + c * d;

//        }

//        [TestMethod]
//        public void DynamicExpressionJoinTest()
//        {
//            var exp = QueryPredicateBuilder.True<Product>()
//                .And(p => p.Price > 1500)
//                .And(p => p.Title.Contains("xiaomi"))
//                .And(prop => prop.Picture.Contains("jd.com") && prop.Picture.Length > 1);
//            Trace.WriteLine(exp.Body);
//        }


//        [TestMethod]
//        public void LambdaPredicateBuilderTest()
//        {
            

//            var price = 1500;
//            string title = null;
//            var predicate = LambdaValidPredicateBuilder.True<Product>()
//                .And(p => p.Price > price)
//                //.And(p => p.Title == title)
//                .And(p => p.SourceSite == "www.jd.com")
//                .And(p => p.Picture == null);
//            Trace.WriteLine(predicate.Body);
//        }

//        public class QueryParameter
//        {
//            public double Price { get; set; }

//            public string SourceSite { get; set; }

//            public int Follows { get; set; }

//            public string Picture { get; set; }

//            public string Description { get; set; }

//            public ProductStatusType Status { get; set; }
//        }

//        [TestMethod]
//        public void LambdaPredicateBuilderParameterTest()
//        {
//            var query = new QueryParameter() {
//                Price = 1500,
//                SourceSite = "www.jd.com",
//                Picture = null
//            };


//            var predicate = LambdaValidPredicateBuilder.True<Product>()
//                .And(p => p.Price > query.Price)
//                .And(p => p.SourceSite == query.SourceSite)
//                .And(p => p.Picture == query.Picture);
//            Trace.WriteLine(predicate.Body);
//        }

//        /// <summary>
//        /// 集合测试
//        /// </summary>
//        [TestMethod]
//        public void LambdaPredicateBuilderSetTest()
//        {
//            var query = new QueryParameter()
//            {
//                Price = 1500,
//                SourceSite = "www.jd.com",
//                Picture = null
//            };

//            var price = new List<double>() { 1000.00, 1400, 1500, 2000 };

//            var predicate = LambdaValidPredicateBuilder.True<Product>()
//                .And(p => price.Contains(p.Price))
//                .And(p => p.SourceSite == query.SourceSite);
//            Trace.WriteLine(predicate.Body);
//        }

//        [TestMethod]
//        public void PredicateBuilderCompareTest()
//        {
//            var query = new QueryParameter()
//            {
//                SourceSite = "www.jd.com",
//                Follows = 100,
//                Picture = null
//            };

//            var query2 = new QueryParameter()
//            {
//                Price = 1600,
//                SourceSite = "www.51buy.com",
//                Picture = null,
//                Description = "笔记本"
                
//            };

//            var query3 = new QueryParameter()
//            {
//                Price = 2600,
//                SourceSite = "www.taobao.com",
//                Picture = null,
//                Status = ProductStatusType.OutOfStock
//            };

//            TimeMonitor.Watch("SqlWhereBuilder", () => {
//                var predicate = SqlWhereBuilder.Create("Select * From [Product]")
//                .And("[Price] > {0}", "@Price", query2.Price)
//                .And("[SourceSite] > {0}", "@SourceSite", query2.SourceSite)
//                .And("[Picture] > {0}", "@Picture", query2.Picture).ToSqlString();
//            });

//            TimeMonitor.Watch("SqlWhereBuilder2", () => {
//                var predicate = SqlWhereBuilder.Create("Select * From [Product]")
//                .And("[Price] > {0}", "@Price", query2.Price)
//                .And("[SourceSite] > {0}", "@SourceSite", query2.SourceSite)
//                .Like("[Description]", "@Description", query2.Description) .ToSqlString();
//            });

//            TimeMonitor.Watch("SqlWhereBuilder3", () => {
//                var predicate = SqlWhereBuilder.Create("Select * From [Product]")
//                .And("[Price] > {0}", "@Price", query2.Price)
//                .And("[SourceSite] > {0}", "@SourceSite", query2.SourceSite)
//                .Like("[Picture]", "@Picture", query2.Description)
//                .And("[Status] = {0}", "@Status", query2.Status)
//                .ToSqlString();
//            });




//            TimeMonitor.Watch("LambdaValidPredicateBuilder", () => {

//                var predicate = LambdaValidPredicateBuilder.True<Product>()
//                    .And(p => p.Follows > query.Follows)
//                    .And(p => p.SourceSite == query.SourceSite)
//                    .And(p => p.Picture == query.Picture);
//            });

//            TimeMonitor.Watch("LambdaValidPredicateBuilder2", () => {
//                var predicate = LambdaValidPredicateBuilder.True<Product>()
//                    .And(p => p.Price > query2.Price)
//                    .And(p => p.SourceSite == query2.SourceSite)
//                    .And(p => p.Picture == query2.Picture)
//                    .And(p => p.Description.Contains(query2.Description));
//            });

//            TimeMonitor.Watch("LambdaValidPredicateBuilder3", () => {
//                var predicate = LambdaValidPredicateBuilder.True<Product>()
//                    .And(p => p.Price > query3.Price)
//                    .And(p => p.SourceSite == query3.SourceSite)
//                    .And(p => p.Picture == query3.Picture)
//                    .And(p => p.Status == query3.Status);
//            });

//            TimeMonitor.Watch("QueryPredicateBuilder", () => {

//                var predicate = QueryPredicateBuilder.True<Product>()
//                    .And(p => p.Follows > query.Follows, query.Follows)
//                    .And(p => p.SourceSite == query.SourceSite, query.SourceSite)
//                    .And(p => p.Picture == query.Picture, query.Picture);
//            });


//            var prices = new double[] { 1000.00, 1500.00, 2100.00};
//            var priceList = new List<double>();

//            TimeMonitor.Watch("LambdaValidPredicateBuilder4", () => {
//                var predicate = LambdaValidPredicateBuilder.True<Product>()
//                    .And(p => p.SourceSite == query3.SourceSite)
//                    .And(p => p.Picture == query3.Picture)
//                    .And(p => p.Status == query3.Status);
//            });

//            //TimeMonitor.WatchLoop("SqlWhereBuilder", 3, () => {
//            //    var predicate = SqlWhereBuilder.Create("Select * From [Product]")
//            //    .And("[Price] > {0}", "@Price", query2.Price)
//            //    .And("[SourceSite] > {0}", "@SourceSite", query2.SourceSite)
//            //    .And("[Picture] > {0}", "@Picture", query2.Picture).ToSqlString();
//            //});


//        }


//    }




//}
