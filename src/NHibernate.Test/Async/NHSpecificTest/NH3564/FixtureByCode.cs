﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NUnit.Framework;
using Environment = NHibernate.Cfg.Environment;

namespace NHibernate.Test.NHSpecificTest.NH3564
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial class MyDummyCache : ICache
	{

		public Task<object> GetAsync(object key, CancellationToken cancellationToken)
		{
			try
			{
				return Task.FromResult<object>(hashtable[KeyAsString(key)]);
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task PutAsync(object key, object value, CancellationToken cancellationToken)
		{
			try
			{
				hashtable[KeyAsString(key)] = value;
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task RemoveAsync(object key, CancellationToken cancellationToken)
		{
			try
			{
				hashtable.Remove(KeyAsString(key));
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task ClearAsync(CancellationToken cancellationToken)
		{
			try
			{
				hashtable.Clear();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task LockAsync(object key, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
			// local cache, so we use synchronization
		}

		public Task UnlockAsync(object key, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
			// local cache, so we use synchronization
		}
	}
}