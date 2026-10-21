using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_12
{
    public class Cache<TKey, TValue>
    {
        private class CacheEntry
        {
            public TValue Value { get; }
            public DateTimeOffset? ExpiresAt { get; }

            public CacheEntry(TValue value, DateTimeOffset? expiresAt)
            {
                Value = value;
                ExpiresAt = expiresAt;
            }
        }

        private Dictionary<TKey, CacheEntry> items = new Dictionary<TKey, CacheEntry>();
        public void Add( TKey key, TValue value, TimeSpan? timeToLive = null) {
            DateTimeOffset? expiresAt = null;

            if (timeToLive.HasValue)
            {
                if (timeToLive.Value <= TimeSpan.Zero)
                {
                    items.Remove(key);
                    return;
                }
                expiresAt = DateTimeOffset.UtcNow.Add(timeToLive.Value);
            }
            items[key] = new CacheEntry(value, expiresAt);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            if (items.TryGetValue(key, out CacheEntry entry))
            {
                if (entry.ExpiresAt.HasValue && DateTimeOffset.UtcNow >= entry.ExpiresAt.Value)
                {
                    items.Remove(key);
                }
                else
                {
                    value = entry.Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        public TValue Get(TKey key)
        {
            if (TryGet(key, out TValue value))
            {
                return value;
            }

            return default(TValue);
        }

        public bool Contains(TKey key)
        {
            return TryGet(key, out TValue value);
        }

        public bool Remove(TKey key)
        {
            return items.Remove(key);
        }
    }
}