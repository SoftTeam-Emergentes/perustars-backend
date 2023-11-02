using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
