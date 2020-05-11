using System;

namespace BookStore.Domain {
    public class IdGenerator {
        internal static string GenerateNewId() => Guid.NewGuid().ToString("D");
    }
}