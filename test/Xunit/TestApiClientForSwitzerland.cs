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

namespace OpenPlzApi.Client.CH.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ApiClientForSwitzerland"/>.
    /// </summary>
    public class TestApiClientForSwitzerland
    {
        [Fact]
        public async Task TestCantons()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var cantons = await client.GetCantonsAsync();

            Assert.True(cantons.Count == 26);

            var existsZürich = false;
            var existsAargau = false;

            foreach (var canton in cantons) 
            {
                if (canton.Name == "Zürich") existsZürich = true;
                if (canton.Name == "Aargau") existsAargau = true;
            }

            Assert.True(existsZürich);
            Assert.True(existsAargau);
        }

        [Fact]
        public async Task TestCommunesByCanton()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var communes = await client.GetCommunesByCantonAsync("10", 1, 10);

            Assert.Equal(1, communes.PageIndex);
            Assert.Equal(10, communes.PageSize);

            Assert.True(communes.Count > 0);
            Assert.True(communes.TotalPages >= 1);
            Assert.True(communes.TotalCount >= 1);

            var existsKey = false;

            foreach (var commune in communes)
            {
                if (commune.Key == "2008")
                {
                    existsKey = true;

                    Assert.Equal("Châtillon (FR)", commune.Name);
                    Assert.Equal("11419", commune.HistoricalCode);
                    Assert.Equal("Châtillon (FR)", commune.ShortName);
                    Assert.Equal("1001", commune.District.Key);
                    Assert.Equal("District de la Broye", commune.District.Name);
                    Assert.Equal("10", commune.Canton.Key);
                    Assert.Equal("FR", commune.Canton.ShortName);
                    Assert.Equal("Fribourg / Freiburg", commune.Canton.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestCommunesByDistrict()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var communes = await client.GetCommunesByDistrictAsync("1002", 1, 10);

            Assert.Equal(1, communes.PageIndex);
            Assert.Equal(10, communes.PageSize);

            Assert.True(communes.Count > 0);
            Assert.True(communes.TotalPages >= 1);
            Assert.True(communes.TotalCount >= 1);

            var existsKey = false;

            foreach (var commune in communes)
            {
                if (commune.Key == "2061")
                {
                    existsKey = true;

                    Assert.Equal("Auboranges", commune.Name);
                    Assert.Equal("11680", commune.HistoricalCode);
                    Assert.Equal("Auboranges", commune.ShortName);
                    Assert.Equal("1002", commune.District.Key);
                    Assert.Equal("District de la Glâne", commune.District.Name);
                    Assert.Equal("10", commune.Canton.Key);
                    Assert.Equal("FR", commune.Canton.ShortName);
                    Assert.Equal("Fribourg / Freiburg", commune.Canton.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestDistrictsByCanton()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var districts = await client.GetDistrictsByCantonAsync("10", 1, 10);

            Assert.Equal(1, districts.PageIndex);
            Assert.Equal(10, districts.PageSize);

            Assert.True(districts.Count > 0);
            Assert.True(districts.TotalPages >= 1);
            Assert.True(districts.TotalCount >= 1);

            var existsKey = false;

            foreach (var district in districts)
            {
                if (district.Key == "1001")
                {
                    existsKey = true;

                    Assert.Equal("District de la Broye", district.Name);
                    Assert.Equal("10107", district.HistoricalCode);
                    Assert.Equal("10", district.Canton.Key);
                    Assert.Equal("FR", district.Canton.ShortName);
                    Assert.Equal("Fribourg / Freiburg", district.Canton.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestFullTextSearch()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var streets = await client.PerformFullTextSearchAsync("8002 Bederstrasse", 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsKey = false;

            foreach (var street in streets)
            {
                if (street.Key == "10098541")
                {
                    existsKey = true;

                    Assert.Equal("Bederstrasse", street.Name);
                    Assert.Equal("8002", street.PostalCode);
                    Assert.Equal("Zürich", street.Locality);
                    Assert.Equal(StreetStatus.Real, street.Status);
                    Assert.Equal("261", street.Commune.Key);
                    Assert.Equal("Zürich", street.Commune.Name);
                    Assert.Equal("Zürich", street.Commune.ShortName);
                    Assert.Equal("112", street.District.Key);
                    Assert.Equal("Bezirk Zürich", street.District.Name);
                    Assert.Equal("1", street.Canton.Key);
                    Assert.Equal("ZH", street.Canton.ShortName);
                    Assert.Equal("Zürich", street.Canton.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestLocalities()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var localities = await client.GetLocalitiesAsync(null, "Zürich", 1, 10);

            Assert.Equal(1, localities.PageIndex);
            Assert.Equal(10, localities.PageSize);

            Assert.True(localities.Count > 0);
            Assert.True(localities.TotalPages >= 1);
            Assert.True(localities.TotalCount >= 1);

            var existsStreet = false;

            foreach (var locality in localities)
            {
                if ((locality.PostalCode == "8001") && (locality.Name == "Zürich"))
                {
                    existsStreet = true;

                    Assert.Equal("261", locality.Commune.Key);
                    Assert.Equal("Zürich", locality.Commune.Name);
                    Assert.Equal("Zürich", locality.Commune.ShortName);
                    Assert.Equal("112", locality.District.Key);
                    Assert.Equal("Bezirk Zürich", locality.District.Name);
                    Assert.Equal("1", locality.Canton.Key);
                    Assert.Equal("ZH", locality.Canton.ShortName);
                    Assert.Equal("Zürich", locality.Canton.Name);

                    break;
                }
            }

            Assert.True(existsStreet);
        }

        [Fact]
        public async Task TestStreets()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForSwitzerland>();

            var streets = await client.GetStreetsAsync("Bederstrasse", "8002", null, 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsKey = false;

            foreach (var street in streets)
            {
                if (street.Key == "10098541")
                {
                    existsKey = true;

                    Assert.Equal("Bederstrasse", street.Name);
                    Assert.Equal("8002", street.PostalCode);
                    Assert.Equal("Zürich", street.Locality);
                    Assert.Equal(StreetStatus.Real, street.Status);
                    Assert.Equal("261", street.Commune.Key);
                    Assert.Equal("Zürich", street.Commune.Name);
                    Assert.Equal("Zürich", street.Commune.ShortName);
                    Assert.Equal("112", street.District.Key);
                    Assert.Equal("Bezirk Zürich", street.District.Name);
                    Assert.Equal("1", street.Canton.Key);
                    Assert.Equal("ZH", street.Canton.ShortName);
                    Assert.Equal("Zürich", street.Canton.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }
    }
}
