using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace cgds.manufacture.tests
{
    public class ManufactureAPIFactory : WebApplicationFactory<cgds.manufacture.api.Startup>
    {
    }
}