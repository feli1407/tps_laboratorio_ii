using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class VideoJuegoTest
    {
        [TestMethod]
        public void TipoDeVideoJuego_Ok()
        {
            //Arrange
            JuegoPlay juegoPlay = new JuegoPlay();

            //Act
            bool rta = (VideoJuego.TipodDeVideoJuego(juegoPlay) == "PlayStation");

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void TipoDeVideoJuego_Falla()
        {
            //Arrange
            JuegoPlay juegoPlay = new JuegoPlay();

            //Act
            bool rta = (VideoJuego.TipodDeVideoJuego(juegoPlay) == "Xbox");

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void VerificarIgualdadDeVideoJuegos_Ok()
        {
            //Arrange
            JuegoPlay juegoPlay1 = new JuegoPlay("prueba", 1000, EGenero.Aventura, true);
            JuegoPlay juegoPlay2 = new JuegoPlay("prueba", 1000, EGenero.Aventura, true);

            //Act
            bool rta = (juegoPlay1 == juegoPlay2);

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void VerificarIgualdadDeVideoJuegos_Falla()
        {
            //Arrange
            JuegoPlay juegoPlay1 = new JuegoPlay("prueba", 1000, EGenero.Aventura, true);
            JuegoPlay juegoPlay2 = new JuegoPlay("pruebaFalla", 1000, EGenero.Aventura, true);

            //Act
            bool rta = (juegoPlay1 == juegoPlay2);

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void AsignarPrecioVenta_Ok()
        {
            //Arrange
            LocalDeVideoJuegos localPrueba = new LocalDeVideoJuegos();
            localPrueba.PorcentajeGanancia = 30;
            JuegoPlay juegoPlay = new JuegoPlay("prueba1", 100, EGenero.Aventura, true);
            localPrueba.VideoJuegos.Add(juegoPlay);
            bool rta = false;

            //Act
            localPrueba.AsignarPrecioVenta();
            foreach (var videojuego in localPrueba.VideoJuegos)
            {
                rta = (videojuego.PrecioVenta == 130);
            }

            //Assert
            Assert.IsTrue(rta);
        }
    }
}
