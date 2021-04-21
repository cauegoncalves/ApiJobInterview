using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using cgds.manufacture.api.Models.Order;
using cgds.manufacture.application.Enums;
using cgds.manufacture.application.Factories;
using NUnit.Framework;

namespace cgds.manufacture.tests
{

    [TestFixture]
    public class OrderAPITest
    {
        private AlbelliAPIFactory apiFactory;
        private HttpClient httpClient;

        [SetUp]
        public void SetUp()
        {
            apiFactory = new AlbelliAPIFactory();
            httpClient = apiFactory.CreateClient();
        }

        [Test]
        public async Task Get_WhenOrderNotExists_ShouldReturnNotFound()
        {
            var result = await httpClient.GetAsync("api/order/1");
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        }

        [TestCaseSource(nameof(GenerateOrdersTestCases))]
        public async Task Get_WhenOrderExists_ShouldReturnOkWithOrderResponse(OrderRequest orderRequest)
        {
            var json = GetJsonContent(orderRequest);
            var postResult = await httpClient.PostAsync("api/order/", json);
            Assert.AreEqual(postResult.StatusCode, HttpStatusCode.OK);

            var getResult = await httpClient.GetAsync($"api/order/{orderRequest.OrderId}");
            Assert.AreEqual(getResult.StatusCode, HttpStatusCode.OK);

            var orderResponse = await getResult.Content.ReadFromJsonAsync<OrderResponse>(options: GetJsonOptions());
            Assert.AreEqual(orderResponse.Items.Count, orderRequest.Items.Count);
            Assert.AreEqual(orderResponse.Items.Sum(i => i.Quantity), orderRequest.Items.Sum(i => i.Quantity));
        }

        [Test]
        public async Task Post_WhenOrderHasNoOrderId_ShouldReturnBadRequest()
        {
            var order = new OrderRequest
            {
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.calendar,
                        Quantity = 10
                    }
                }
            };
            var json = GetJsonContent(order);
            var result = await httpClient.PostAsync("api/order/", json);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Post_WhenOrderHasDuplicatedItems_ShouldAggregateAndReturnOk()
        {
            var order = new OrderRequest
            {
                OrderId = 1,
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.mug,
                        Quantity = 1
                    },
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.mug,
                        Quantity = 2
                    },
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.mug,
                        Quantity = 1
                    }
                }
            };
            var json = GetJsonContent(order);
            var result = await httpClient.PostAsync("/api/order/", json);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            var width = await result.Content.ReadAsStringAsync();
            var expectedWidth = ProductTypeFactory.Create(EnumProductType.mug).PackageWidth;
            Assert.AreEqual(Convert.ToDecimal(width), expectedWidth);
        }

        private JsonContent GetJsonContent<T>(T value)
        {
            var content = JsonContent.Create(value, options: GetJsonOptions());
            return content;
        }

        private JsonSerializerOptions GetJsonOptions()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            jsonOptions.Converters.Add(new JsonStringEnumConverter());
            return jsonOptions;
        }

        private static IEnumerable<OrderRequest> GenerateOrdersTestCases()
        {
            yield return new OrderRequest
            {
                OrderId = 1,
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.calendar,
                        Quantity = 10
                    }
                }
            };
            yield return new OrderRequest
            {
                OrderId = 2,
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.calendar,
                        Quantity = 2
                    },
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.canvas,
                        Quantity = 10
                    },
                }
            };
            yield return new OrderRequest
            {
                OrderId = 3,
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.mug,
                        Quantity = 6
                    },
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.cards,
                        Quantity = 1
                    },
                }
            };
            yield return new OrderRequest
            {
                OrderId = 4,
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        ProductType = EnumProductType.photoBook,
                        Quantity = 2
                    },
                }
            };
        }

    }
}
