using System;
using System.Collections.Generic;

namespace TechTalk.SpecFlow.Assist.ValueRetrievers
{
    public class NullableUIntValueRetriever : IValueRetriever
    {
        private readonly Func<string, uint> uintValueRetriever = v => new UIntValueRetriever().GetValue(v);

        public NullableUIntValueRetriever(Func<string, uint> uintValueRetriever = null)
        {
            if (uintValueRetriever != null)
                this.uintValueRetriever = uintValueRetriever;
        }

        public uint? GetValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return uintValueRetriever(value);
        }

        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType)
        {
            return GetValue(keyValuePair.Value);
        }

        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type type)
        {
            return type == typeof(uint?);
        }
    }
}