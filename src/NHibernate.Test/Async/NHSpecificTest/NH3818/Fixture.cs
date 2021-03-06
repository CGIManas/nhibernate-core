﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Linq;
using System.Linq.Dynamic;
using NHibernate.Linq;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH3818
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		public override string BugNumber
		{
            get { return "NH3818"; }
		}

        [Test]
        public async Task SelectConditionalValuesTestAsync()
        {
            using (var spy = new SqlLogSpy())
            using (var session = OpenSession())
            using (session.BeginTransaction())
            {
                var days = 33;

                var cat = new MyLovelyCat
                {
                    GUID = Guid.NewGuid(),
                    Birthdate = DateTime.Now.AddDays(-days),
                    Color = "Black",
                    Name = "Kitty",
                    Price = 0
                };
                await (session.SaveAsync(cat));
                
                await (session.FlushAsync());

                var catInfo =
                    await (session.Query<MyLovelyCat>()
                        .Select(o => new
                        {
                            o.Color,
                            AliveDays = (int)(DateTime.Now - o.Birthdate).TotalDays,
                            o.Name,
                            o.Price,
                        })
                        .SingleAsync());

                //Console.WriteLine(spy.ToString());
                Assert.That(catInfo.AliveDays == days);

                var catInfo2 =
                    await (session.Query<MyLovelyCat>()
                        .Select(o => new
                        {
                            o.Color,
                            AliveDays = o.Price > 0 ? (DateTime.Now - o.Birthdate).TotalDays : 0,
                            o.Name,
                            o.Price,
                        })
                        .SingleAsync());

                //Console.WriteLine(spy.ToString());
                Assert.That(catInfo2.AliveDays == 0);

            }
        }

    }
}