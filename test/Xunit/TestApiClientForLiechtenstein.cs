#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

using System.Threading.Tasks;
using Xunit;

namespace OpenPlzApi.Client.LI.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ApiClientForLiechtenstein"/>.
    /// </summary>
    public class TestApiClientForLiechtenstein
    {
        [Fact]
        public async Task TestComunes()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForLiechtenstein>();

            var communes = await client.GetCommunesAsync();

            Assert.Equal(11, communes.Count);

            var existsTriesen = false;
            var existsPlanken = false;

            foreach (var commune in communes)
            {
                if (commune.Name == "Triesen") existsTriesen = true;
                if (commune.Name == "Planken") existsPlanken = true;
            }

            Assert.True(existsTriesen);
            Assert.True(existsPlanken);
        }

        [Fact]
        public async Task TestFullTextSearch()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForLiechtenstein>();

            var streets = await client.PerformFullTextSearchAsync("9490 Alte Landstrasse", 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsKey = false;

            foreach (var street in streets)
            {
                if (street.Key == "89440155")
                {
                    existsKey = true;

                    Assert.Equal("Alte Landstrasse", street.Name);
                    Assert.Equal("9490", street.PostalCode);
                    Assert.Equal("Vaduz", street.Locality);
                    Assert.Equal(StreetStatus.Real, street.Status);
                    Assert.Equal("7001", street.Commune.Key);
                    Assert.Equal("Vaduz", street.Commune.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestLocalities()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForLiechtenstein>();

            var localities = await client.GetLocalitiesAsync(null, "Vaduz", 1, 10);

            Assert.Equal(1, localities.PageIndex);
            Assert.Equal(10, localities.PageSize);

            Assert.True(localities.Count > 0);
            Assert.True(localities.TotalPages >= 1);
            Assert.True(localities.TotalCount >= 1);

            var Exists_Name = false;
            var Exists_PostalCode = false;

            foreach (var locality in localities)
            {
                if ((locality.PostalCode == "9490") && (locality.Name == "Vaduz")) 
                {
                    Exists_Name = true;
                    Exists_PostalCode = true;

                    Assert.Equal("7001", locality.Commune.Key);
                    Assert.Equal("Vaduz", locality.Commune.Name);

                    break;
                }
            }

            Assert.True(Exists_Name);
            Assert.True(Exists_PostalCode);
        }

        [Fact]
        public async Task TestStreets()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForLiechtenstein>();

            var streets = await client.GetStreetsAsync("Alte Landstrasse", "9490", null, 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsKey = false;

            foreach (var street in streets)
            {
                if (street.Key == "89440155")
                {
                    existsKey = true;

                    Assert.Equal("Alte Landstrasse", street.Name);
                    Assert.Equal("9490", street.PostalCode);
                    Assert.Equal("Vaduz", street.Locality);
                    Assert.Equal(StreetStatus.Real, street.Status);
                    Assert.Equal("7001", street.Commune.Key);
                    Assert.Equal("Vaduz", street.Commune.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }
    }
}
