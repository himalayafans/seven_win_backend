using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.ApplicationTests
{
    [CollectionDefinition("app collection")]
    public class AppCollection: ICollectionFixture<AppFixture>
    {
    }
}
