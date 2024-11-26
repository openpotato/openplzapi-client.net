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

namespace OpenPlzApi.Client.AT.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ApiClientForAustria"/>.
    /// </summary>
    public class TestApiClientForAustria
    {
        [Fact]
        public async Task TestDistrictsByFederalProvince()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var districts = await client.GetDistrictsByFederalProvinceAsync("7", 1, 10);

            Assert.Equal(1, districts.PageIndex);
            Assert.Equal(10, districts.PageSize);

            Assert.True(districts.Count > 0);
            Assert.True(districts.TotalPages >= 1);
            Assert.True(districts.TotalCount >= 1);

            var existsKey = false;

            foreach (var district in districts)
            {
                if (district.Key == "701")
                {
                    existsKey = true;

                    Assert.Equal("701", district.Code);
                    Assert.Equal("Innsbruck-Stadt", district.Name);
                    Assert.Equal("7", district.FederalProvince.Key);
                    Assert.Equal("Tirol", district.FederalProvince.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestFederalProvinces()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var federalProvinces = await client.GetFederalProvincesAsync();

            Assert.Equal(9, federalProvinces.Count);

            var existsWien = false;
            var existsBurgenland = false;

            foreach (var federalProvince in federalProvinces) 
            {
                if (federalProvince.Name == "Wien") existsWien = true;
                if (federalProvince.Name == "Burgenland") existsBurgenland = true;
            }

            Assert.True(existsWien);
            Assert.True(existsBurgenland);
        }

        [Fact]
        public async Task TestFullTextSearch()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var streets = await client.PerformFullTextSearchAsync("1020 Adambergergasse", 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsKey = false;

            foreach (var street in streets)
            {
                if (street.Key == "900017")
                {
                    existsKey = true;

                    Assert.Equal("Adambergergasse", street.Name);
                    Assert.Equal("1020", street.PostalCode);
                    Assert.Equal("Wien, Leopoldstadt", street.Locality);
                    Assert.Equal("90001", street.Municipality.Key);
                    Assert.Equal("90201", street.Municipality.Code);
                    Assert.Equal("Wien", street.Municipality.Name);
                    Assert.Equal("Statutarstadt", street.Municipality.Status);
                    Assert.Equal("900", street.District.Key);
                    Assert.Equal("902", street.District.Code);
                    Assert.Equal("Wien  2., Leopoldstadt", street.District.Name);
                    Assert.Equal("9", street.FederalProvince.Key);
                    Assert.Equal("Wien", street.FederalProvince.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestLocalities()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var localities = await client.GetLocalitiesAsync(null, "Wien", 1, 10);

            Assert.Equal(1, localities.PageIndex);
            Assert.Equal(10, localities.PageSize);

            Assert.True(localities.Count > 0);
            Assert.True(localities.TotalPages >= 1);
            Assert.True(localities.TotalCount >= 1);

            var existsKey = false;

            foreach (var locality in localities)
            {
                if (locality.Key == "17223")
                {
                    existsKey = true;

                    Assert.Equal("Wien, Innere Stadt", locality.Name);
                    Assert.Equal("1010", locality.PostalCode);
                    Assert.Equal("90001", locality.Municipality.Key);
                    Assert.Equal("90401", locality.Municipality.Code);
                    Assert.Equal("Wien", locality.Municipality.Name);
                    Assert.Equal("Statutarstadt", locality.Municipality.Status);
                    Assert.Equal("900", locality.District.Key);
                    Assert.Equal("904", locality.District.Code);
                    Assert.Equal("Wien  4., Wieden", locality.District.Name);
                    Assert.Equal("9", locality.FederalProvince.Key);
                    Assert.Equal("Wien", locality.FederalProvince.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestMunicipalitiesByDistrict()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var municipalities = await client.GetMunicipalitiesByDistrictAsync("701", 1, 10);

            Assert.Equal(1, municipalities.PageIndex);
            Assert.Equal(10, municipalities.PageSize);

            Assert.True(municipalities.Count > 0);
            Assert.True(municipalities.TotalPages >= 1);
            Assert.True(municipalities.TotalCount >= 1);

            var existsKey = false;

            foreach (var municipality in municipalities)
            {
                if (municipality.Key == "70101")
                {
                    existsKey = true;

                    Assert.Equal("70101", municipality.Code);
                    Assert.Equal("Innsbruck", municipality.Name);
                    Assert.Equal("6020", municipality.PostalCode);
                    Assert.True(municipality.MultiplePostalCodes);
                    Assert.Equal("Statutarstadt", municipality.Status);
                    Assert.Equal("701", municipality.District.Key);
                    Assert.Equal("701", municipality.District.Code);
                    Assert.Equal("Innsbruck-Stadt", municipality.District.Name);
                    Assert.Equal("7", municipality.FederalProvince.Key);
                    Assert.Equal("Tirol", municipality.FederalProvince.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestMunicipalitiesByFederalProvince()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var municipalities = await client.GetMunicipalitiesByFederalProvinceAsync("7", 1, 10);

            Assert.Equal(1, municipalities.PageIndex);
            Assert.Equal(10, municipalities.PageSize);

            Assert.True(municipalities.Count > 0);
            Assert.True(municipalities.TotalPages >= 1);
            Assert.True(municipalities.TotalCount >= 1);

            var existsKey = false;

            foreach (var municipality in municipalities)
            {
                if (municipality.Key == "70101")
                {
                    existsKey = true;

                    Assert.Equal("70101", municipality.Code);
                    Assert.Equal("Innsbruck", municipality.Name);
                    Assert.Equal("6020", municipality.PostalCode);
                    Assert.True(municipality.MultiplePostalCodes);
                    Assert.Equal("Statutarstadt", municipality.Status);
                    Assert.Equal("701", municipality.District.Key);
                    Assert.Equal("701", municipality.District.Code);
                    Assert.Equal("Innsbruck-Stadt", municipality.District.Name);
                    Assert.Equal("7", municipality.FederalProvince.Key);
                    Assert.Equal("Tirol", municipality.FederalProvince.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestStreets()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForAustria>();

            var streets = await client.GetStreetsAsync(null, "1020", null, 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsKey = false;

            foreach (var street in streets)
            {
                if (street.Key == "900017")
                {
                    existsKey = true;

                    Assert.Equal("Adambergergasse", street.Name);
                    Assert.Equal("1020", street.PostalCode);
                    Assert.Equal("Wien, Leopoldstadt", street.Locality);
                    Assert.Equal("90001", street.Municipality.Key);
                    Assert.Equal("90201", street.Municipality.Code);
                    Assert.Equal("Wien", street.Municipality.Name);
                    Assert.Equal("Statutarstadt", street.Municipality.Status);
                    Assert.Equal("900", street.District.Key);
                    Assert.Equal("902", street.District.Code);
                    Assert.Equal("Wien  2., Leopoldstadt", street.District.Name);
                    Assert.Equal("9", street.FederalProvince.Key);
                    Assert.Equal("Wien", street.FederalProvince.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }
    }
}
