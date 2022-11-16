using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.DataTests
{
    public class UnitOfWorkTests : IClassFixture<WebFixture>
    {
        public readonly WebFixture webFixture;

        public UnitOfWorkTests(WebFixture webFixture)
        {
            this.webFixture = webFixture ?? throw new ArgumentNullException(nameof(webFixture));
        }
        
    }
}
