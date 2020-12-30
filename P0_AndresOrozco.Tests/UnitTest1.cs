using System;
using P0_AndresOrozco;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace P0_AndresOrozco.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<StoreAppDBContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
        }
    }
}
