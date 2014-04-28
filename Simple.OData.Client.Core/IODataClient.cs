﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simple.OData.Client
{
    public interface IODataClient
    {
        IFluentClient<IDictionary<string, object>> For(string collectionName);
        IFluentClient<ODataEntry> For(ODataExpression expression);
        IFluentClient<T> For<T>(string collectionName = null) where T : class;

        Task<ISchema> GetSchemaAsync();
        Task<string> GetSchemaAsStringAsync();
        Task<string> GetCommandTextAsync(string collection, ODataExpression expression);
        Task<string> GetCommandTextAsync<T>(string collection, Expression<Func<T, bool>> expression);
        Task<IEnumerable<IDictionary<string, object>>> FindEntriesAsync(string commandText);
        Task<IEnumerable<IDictionary<string, object>>> FindEntriesAsync(string commandText, bool scalarResult);
        Task<Tuple<IEnumerable<IDictionary<string, object>>, int>> FindEntriesWithCountAsync(string commandText);
        Task<Tuple<IEnumerable<IDictionary<string, object>>, int>> FindEntriesWithCountAsync(string commandText, bool scalarResult);
        Task<IDictionary<string, object>> FindEntryAsync(string commandText);
        Task<object> FindScalarAsync(string commandText);
        Task<IDictionary<string, object>> GetEntryAsync(string collection, params object[] entryKey);
        Task<IDictionary<string, object>> GetEntryAsync(string collection, IDictionary<string, object> entryKey);
        Task<IDictionary<string, object>> InsertEntryAsync(string collection, IDictionary<string, object> entryData, bool resultRequired = true);
        Task<IDictionary<string, object>> UpdateEntryAsync(string collection, IDictionary<string, object> entryKey, IDictionary<string, object> entryData, bool resultRequired = true);
        Task<IEnumerable<IDictionary<string, object>>> UpdateEntriesAsync(string collection, string commandText, IDictionary<string, object> entryData, bool resultRequired = true);
        Task DeleteEntryAsync(string collection, IDictionary<string, object> entryKey);
        Task<int> DeleteEntriesAsync(string collection, string commandText);
        Task LinkEntryAsync(string collection, IDictionary<string, object> entryKey, string linkName, IDictionary<string, object> linkedEntryKey);
        Task UnlinkEntryAsync(string collection, IDictionary<string, object> entryKey, string linkName);
        Task<IEnumerable<IDictionary<string, object>>> ExecuteFunctionAsync(string functionName, IDictionary<string, object> parameters);
        Task<T> ExecuteFunctionAsScalarAsync<T>(string functionName, IDictionary<string, object> parameters);
        Task<T[]> ExecuteFunctionAsArrayAsync<T>(string functionName, IDictionary<string, object> parameters);
    }
}