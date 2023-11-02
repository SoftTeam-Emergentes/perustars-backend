using NUnit.Framework;

using System.Threading.Tasks;

namespace PERUSTARS.Test
{
    internal class ArtEventServiceTest
    {
        [SetUp]
        public void SetUp() { 
        }
        [Test]
        public async Task GetById() {
            var mockEventRepository = GetDefaulIArtEventRepository();
            var mockEvent = mockEventRepository.Get(1);
                
        }
    }
}
