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

namespace OpenPlzApi.Client.DE.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ApiClientForGermany"/>.
    /// </summary>
    public class TestApiClientForGermany
    {
        [Fact]
        public async Task TestDistrictsByFederalState()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var districts = await client.GetDistrictsByFederalStateAsync("09", 1, 10);

            Assert.Equal(1, districts.PageIndex);
            Assert.Equal(10, districts.PageSize);

            Assert.True(districts.Count > 0);
            Assert.True(districts.TotalPages >= 1);
            Assert.True(districts.TotalCount >= 1);

            var existsKey = false;

            foreach (var district in districts)
            {
                if (district.Key == "09161")
                {
                    existsKey = true;

                    Assert.Equal("Ingolstadt", district.Name);
                    Assert.Equal("Kreisfreie Stadt", district.Type);
                    Assert.Equal("Ingolstadt", district.AdministrativeHeadquarters);
                    Assert.Equal("091", district.GovernmentRegion.Key);
                    Assert.Equal("Oberbayern", district.GovernmentRegion.Name);
                    Assert.Equal("09", district.FederalState.Key);
                    Assert.Equal("Bayern", district.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestDistrictsByGovernmentRegion()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var districts = await client.GetDistrictsByGovernmentRegionAsync("091", 1, 10);

            Assert.Equal(1, districts.PageIndex);
            Assert.Equal(10, districts.PageSize);

            Assert.True(districts.Count > 0);
            Assert.True(districts.TotalPages >= 1);
            Assert.True(districts.TotalCount >= 1);

            var existsKey = false;

            foreach (var district in districts)
            {
                if (district.Key == "09161")
                {
                    existsKey = true;

                    Assert.Equal("Ingolstadt", district.Name);
                    Assert.Equal("Kreisfreie Stadt", district.Type);
                    Assert.Equal("Ingolstadt", district.AdministrativeHeadquarters);
                    Assert.Equal("091", district.GovernmentRegion.Key);
                    Assert.Equal("Oberbayern", district.GovernmentRegion.Name);
                    Assert.Equal("09", district.FederalState.Key);
                    Assert.Equal("Bayern", district.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestFederalStates()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var FederalStates = await client.GetFederalStatesAsync();

            Assert.Equal(16, FederalStates.Count);

            var existsBerlin = false;
            var existsRheinlandPfalz = false;

            foreach (var federalState in FederalStates) 
            {
                if (federalState.Name == "Berlin") existsBerlin = true;
                if (federalState.Name == "Rheinland-Pfalz") existsRheinlandPfalz = true;
            }

            Assert.True(existsBerlin);
            Assert.True(existsRheinlandPfalz);
        }


        [Fact]
        public async Task TestFullTextSearch()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var streets = await client.PerformFullTextSearchAsync("Berlin Pariser Platz", 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsStreet = false;

            foreach (var street in streets)
            {
                if ((street.Name == "Pariser Platz") && (street.PostalCode == "10117"))
                {
                    existsStreet = true;

                    Assert.Equal("Berlin", street.Locality);
                    Assert.Equal("11000000", street.Municipality.Key);
                    Assert.Equal("Berlin, Stadt", street.Municipality.Name);
                    Assert.Equal("Kreisfreie Stadt", street.Municipality.Type);
                    Assert.Equal("11", street.FederalState.Key);
                    Assert.Equal("Berlin", street.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsStreet);
        }
        [Fact]
        public async Task TestGovernmentRegionsByFederalState()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var governmentRegions = await client.GetGovernmentRegionsByFederalStateAsync("09", 1, 10);

            Assert.Equal(1, governmentRegions.PageIndex);
            Assert.Equal(10, governmentRegions.PageSize);

            Assert.True(governmentRegions.Count > 0);
            Assert.True(governmentRegions.TotalPages >= 1);
            Assert.True(governmentRegions.TotalCount >= 1);

            var existsKey = false;

            foreach (var governmentRegion in governmentRegions)
            {
                if (governmentRegion.Key == "091")
                {
                    existsKey = true;

                    Assert.Equal("Oberbayern", governmentRegion.Name);
                    Assert.Equal("09", governmentRegion.FederalState.Key);
                    Assert.Equal("Bayern", governmentRegion.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestLocalities()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var localities = await client.GetLocalitiesAsync("56566", null, 1, 10);

            Assert.Equal(1, localities.PageIndex);
            Assert.Equal(10, localities.PageSize);

            Assert.True(localities.Count > 0);
            Assert.True(localities.TotalPages >= 1);
            Assert.True(localities.TotalCount >= 1);

            var existsLocality = false;

            foreach (var locality in localities)
            {
                if ((locality.Name == "Neuwied") && (locality.PostalCode == "56566"))
                {
                    existsLocality = true;

                    Assert.Equal("07138045", locality.Municipality.Key);
                    Assert.Equal("Neuwied, Stadt", locality.Municipality.Name);
                    Assert.Equal("Stadt", locality.Municipality.Type);
                    Assert.Equal("07138", locality.District.Key);
                    Assert.Equal("Neuwied", locality.District.Name);
                    Assert.Equal("07", locality.FederalState.Key);
                    Assert.Equal("Rheinland-Pfalz", locality.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsLocality);
        }

        [Fact]
        public async Task TestMunicipalAssociationsByDistrict()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var municipalAssociations = await client.GetMunicipalAssociationsByDistrictAsync("09180", 1, 10);

            Assert.Equal(1, municipalAssociations.PageIndex);
            Assert.Equal(10, municipalAssociations.PageSize);

            Assert.True(municipalAssociations.Count > 0);
            Assert.True(municipalAssociations.TotalPages >= 1);
            Assert.True(municipalAssociations.TotalCount >= 1);

            var existsKey = false;

            foreach (var municipalAssociation in municipalAssociations)
            {
                if (municipalAssociation.Key == "091805133")
                {
                    existsKey = true;

                    Assert.Equal("Saulgrub (VGem)", municipalAssociation.Name);
                    Assert.Equal("Verwaltungsgemeinschaft", municipalAssociation.Type);
                    Assert.Equal("Saulgrub", municipalAssociation.AdministrativeHeadquarters);
                    Assert.Equal("09180", municipalAssociation.District.Key);
                    Assert.Equal("Garmisch-Partenkirchen", municipalAssociation.District.Name);
                    Assert.Equal("Landkreis", municipalAssociation.District.Type);
                    Assert.Equal("09", municipalAssociation.FederalState.Key);
                    Assert.Equal("Bayern", municipalAssociation.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestMunicipalAssociationsByFederalState()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var municipalAssociations = await client.GetMunicipalAssociationsByFederalStateAsync("09", 1, 10);

            Assert.Equal(1, municipalAssociations.PageIndex);
            Assert.Equal(10, municipalAssociations.PageSize);

            Assert.True(municipalAssociations.Count > 0);
            Assert.True(municipalAssociations.TotalPages >= 1);
            Assert.True(municipalAssociations.TotalCount >= 1);

            var existsKey = false;

            foreach (var municipalAssociation in municipalAssociations)
            {
                if (municipalAssociation.Key == "091715101")
                {
                    existsKey = true;

                    Assert.Equal("Emmerting (VGem)", municipalAssociation.Name);
                    Assert.Equal("Verwaltungsgemeinschaft", municipalAssociation.Type);
                    Assert.Equal("Emmerting", municipalAssociation.AdministrativeHeadquarters);
                    Assert.Equal("09171", municipalAssociation.District.Key);
                    Assert.Equal("Altötting", municipalAssociation.District.Name);
                    Assert.Equal("09", municipalAssociation.FederalState.Key);
                    Assert.Equal("Bayern", municipalAssociation.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestMunicipalitiesByDistrict()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var municipalities = await client.GetMunicipalitiesByDistrictAsync("09180", 1, 10);

            Assert.Equal(1, municipalities.PageIndex);
            Assert.Equal(10, municipalities.PageSize);

            Assert.True(municipalities.Count > 0);
            Assert.True(municipalities.TotalPages >= 1);
            Assert.True(municipalities.TotalCount >= 1);

            var existsKey = false;

            foreach (var municipality in municipalities)
            {
                if (municipality.Key == "09180112")
                {
                    existsKey = true;

                    Assert.Equal("Bad Kohlgrub", municipality.Name);
                    Assert.Equal("Kreisangehörige Gemeinde", municipality.Type);
                    Assert.Equal("82433", municipality.PostalCode);
                    Assert.False(municipality.MultiplePostalCodes);
                    Assert.Equal("09180", municipality.District.Key);
                    Assert.Equal("Garmisch-Partenkirchen", municipality.District.Name);
                    Assert.Equal("Landkreis", municipality.District.Type);
                    Assert.Equal("091", municipality.GovernmentRegion.Key);
                    Assert.Equal("Oberbayern", municipality.GovernmentRegion.Name);
                    Assert.Equal("09", municipality.FederalState.Key);
                    Assert.Equal("Bayern", municipality.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestMunicipalitiesByFederalState()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var municipalities = await client.GetMunicipalitiesByFederalStateAsync("09", 1, 10);

            Assert.Equal(1, municipalities.PageIndex);
            Assert.Equal(10, municipalities.PageSize);

            Assert.True(municipalities.Count > 0);
            Assert.True(municipalities.TotalPages >= 1);
            Assert.True(municipalities.TotalCount >= 1);

            var existsKey = false;

            foreach (var municipality in municipalities)
            {
                if (municipality.Key == "09161000")
                {
                    existsKey = true;

                    Assert.Equal("Ingolstadt", municipality.Name);
                    Assert.Equal("Kreisfreie Stadt", municipality.Type);
                    Assert.Equal("85047", municipality.PostalCode);
                    Assert.True(municipality.MultiplePostalCodes);
                    Assert.Equal("09161", municipality.District.Key);
                    Assert.Equal("Ingolstadt", municipality.District.Name);
                    Assert.Equal("Kreisfreie Stadt", municipality.District.Type);
                    Assert.Equal("091", municipality.GovernmentRegion.Key);
                    Assert.Equal("Oberbayern", municipality.GovernmentRegion.Name);
                    Assert.Equal("09", municipality.FederalState.Key);
                    Assert.Equal("Bayern", municipality.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsKey);
        }

        [Fact]
        public async Task TestStreets()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var streets = await client.GetStreetsAsync("Pariser Platz", null, null, 1, 10);

            Assert.Equal(1, streets.PageIndex);
            Assert.Equal(10, streets.PageSize);

            Assert.True(streets.Count > 0);
            Assert.True(streets.TotalPages >= 1);
            Assert.True(streets.TotalCount >= 1);

            var existsStreet = false;

            foreach (var street in streets)
            {
                if ((street.Name == "Pariser Platz") && (street.PostalCode == "10117"))
                {
                    existsStreet = true;

                    Assert.Equal("Berlin", street.Locality);
                    Assert.Equal("11000000", street.Municipality.Key);
                    Assert.Equal("Berlin, Stadt", street.Municipality.Name);
                    Assert.Equal("Kreisfreie Stadt", street.Municipality.Type);
                    Assert.Equal("11", street.FederalState.Key);
                    Assert.Equal("Berlin", street.FederalState.Name);

                    break;
                }
            }

            Assert.True(existsStreet);
        }
    }
}
