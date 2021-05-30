namespace infrastructure.tests
{
    using System;
    using User;
    using Xunit;

    public sealed class JsonUserDatastoreTests
    {
        public class Ctor
        {
            [Fact]
            public void NullMapper_Ctor_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new JsonUserDatastore(null));
            }
        }
    }
}