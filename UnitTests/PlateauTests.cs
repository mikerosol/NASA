using NASA;
using NUnit.Framework;

namespace UnitTests
{
    public class PlateauTests
    {
        [Test]
        public void AreCoordinatedInbound()
        {
            var plateau = new Plateau(5, 5);

            //INBOUND COORDINATES
            Assert.True(plateau.AreCoordinatedInbound(0, 0));
            Assert.True(plateau.AreCoordinatedInbound(1, 1));
            Assert.True(plateau.AreCoordinatedInbound(2, 2));
            Assert.True(plateau.AreCoordinatedInbound(3, 3));
            Assert.True(plateau.AreCoordinatedInbound(4, 4));
            Assert.True(plateau.AreCoordinatedInbound(5, 5));

            //OUTBOUND COORDINATES
            Assert.False(plateau.AreCoordinatedInbound(-1, 0));
            Assert.False(plateau.AreCoordinatedInbound(6, 0));
            Assert.False(plateau.AreCoordinatedInbound(0, -1));
            Assert.False(plateau.AreCoordinatedInbound(0, 6));

        }
    }
}