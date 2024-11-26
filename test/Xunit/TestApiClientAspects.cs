#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

using OpenPlzApi.Client.DE;
using System.Threading.Tasks;
using Xunit;

namespace OpenPlzApi.Client.Tests
{
    /// <summary>
    /// Unit tests for various aspects of <see cref="ApiBaseClient"/>.
    /// </summary>
    public class TestApiClientAspects
    {
        [Fact]
        public async Task TestPaging()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            var existsStreet = false;
            var pageIndex = 1;

            var streetsPage = await client.PerformFullTextSearchAsync("Berlin Platz", pageSize: 10);

            while (streetsPage != null)
            {
                Assert.Equal(pageIndex, streetsPage.PageIndex);
                Assert.Equal(10, streetsPage.PageSize);

                Assert.True(streetsPage.Count > 0);
                Assert.True(streetsPage.TotalPages >= 2);
                Assert.True(streetsPage.TotalCount >= 10);

                foreach (var street in streetsPage)
                {
                    if ((street.Name == "Pariser Platz") && (street.PostalCode == "10117"))
                    {
                        Assert.Equal("Berlin", street.Locality);
                        Assert.Equal("11000000", street.Municipality.Key);
                        Assert.Equal("Berlin, Stadt", street.Municipality.Name);
                        Assert.Equal("Kreisfreie Stadt", street.Municipality.Type);
                        Assert.Equal("11", street.FederalState.Key);
                        Assert.Equal("Berlin", street.FederalState.Name);
                        existsStreet = true;
                        break;
                    }
                }

                streetsPage = await streetsPage.GetNextPageAsync();
                pageIndex++;
            }
            Assert.True(existsStreet);
        }

        [Fact]
        public async Task TestProblemDetails()
        {
            var client = ApiClientFactory.CreateClient<ApiClientForGermany>();

            await Assert.ThrowsAsync<ProblemDetailsException>(() => client.PerformFullTextSearchAsync("Berlin Platz", pageSize: 99));
        }
    }
}
