using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.JweToken.TestData
{
    internal class ValidJweTokenTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "a1..b2.c3.d4",
            "a1.e5.b2.c3.d4",
            "eyJhbGciOiJkaXIiLCJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwiZXhwIjoiMjAxOC0wNi0yMlQxNDo0OTozMy43MTYyNzQyWiJ9..8UyDLi8webLTe5PRu9JMrg.z872Tgbx0AyyOw41tABhVreUEtv1uyzfN8E8icoYy3QBWJz_4HPKl5DhoYxgU5Ghxy6DMMiUInykWxylthpOjPaSaHn0YRs7tnNR9KcRtaNOBeY1dY29wjfTwuPPO9c93JYB9cjkbxFJMyXpuD39xQnEmaTmTBzt6c-mN2QgeMbDyRnburpyjnxhgvMMaKHmVnaoMAZX_8cmk22RWRWe0WOuSxVAknNGbbZVHUyy57ALluvrcM62A0BHH-QlJf3dBPdP3FAo-8OUJj1y9oN3CqZ21tw4sAh85SsD9A9pMVV6iIEB6W9WQgs2HrvZtNjsnetXPiItdEh8OvzGfCkUFh7LBka-0bKSXWzJetNtEoNgAWpNZEMUJ2k0ZWnDtegE7BFef08NTAFcedcZmC84_j60jBHNCfVMBS9DAW3D0BE7XHR75wuHAMKUBlMM1zY6zc04sUIAszpmr-zh933fhEveNMtxOdLqKDo-5K_WkwitNPxOtDnVWSD8Wr42Y2FshL5Dh9r8uZpTuEjqrUCQkW0fLW66MrBkv5VCjTDZf60ZHM3xApnY9gxxpMXQLAP2xy1TcIBq358RkoaJYlkgYNeuSqmnypFkQH5a7j5V5DcA-IIasX71T5NMxRy1oYmujhkw2YrfFejsq0NBru2g7svbiCMCr88xSjJBhuYVM6LWRSK-O4XjUNJ4wYfwsrQpuzmdF08PYsaViWhZ6RHbrXk1_l861E9ONpg6FUGXPCi2iXGFy0qUu4cU4FCbzQJM1AGUCGhnz1uVZ9DgbuXI73wq9xtcXp2KbIgjR6TS4d2vKcgqZAlQxE-3WM7vyI3L8BGhjDR3odSuQZHNQU3UMjwvnw1U1D6ABkwztwr6PHTas0O3FoFQxFTcQ-DtrezsImJlV7cdA1IXqsUg62u-rVIat2ZqbyPSzbWHsnbO3R5AYRdFAPRHyELS3XEzdPYRywjFho50lrewQ68i_0nRWumD14_4Z8TqCtPLAS5B07mN-iGcy4DuDNJTPwMyQ6SlIHHRTFbysVPY7fX-aUox2y9weL_z84Z_wlEpOB-oaXBIsgkBIujrCWli83gEeH70HG416sn5-w561FBhOLnV4rthe7X6PsMHieA2oZpwJSq9wLFxDsw2D2tlhf9lAWUDYQNaNV3D4t5veBagm2iRbT47g4uN3k4Vp2eKWlME7tg7H-wpqGgt7WXbMSfqlVlRkmwqKZ2oKU9CPX5ZpNPU0HZQjg5hYy1Q3lYiloZkYi0Yr4XnRtSvOLWZeQKdY2GWPYQ1CkpdZxnvq7lsNwVNt2NyU8OB5Wkf9E9RBbajbS3pg5UkbWYTBZXwjBzNvZKcc2aBDwMzeFUhIVpi6OmgUlZsKGtbCcKekP6X2ycZocozifmo4GlChkY1f7Z9-qkd76UaEEWOx--UTSjjwy-Kmw.J7pw3ceUGRM6sScrXeHCuw"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}