using System.Collections.Generic;
using Business.Interfaces;
using CadastroTitulosAPI.Controllers;
using DAL.Base;
using Microsoft.AspNetCore.Mvc;
using Model;
using Moq;
using Xunit;

public class ODSControllerTests
{
    [Fact]
    public void Objetivos_DeveRetornarOkComListaDeObjetivos()
    {
        // Arrange
        var mockODSBUS = new Mock<IODSBUS>();
        var mockRepository = new Mock<IRepositoryBase>();
        var controller = new ODSController(mockODSBUS.Object, mockRepository.Object);

        // Certifique-se de configurar o mock para retornar algo válido
        mockODSBUS.Setup(x => x.BuscarObjetivos(It.IsAny<IRepositoryBase>()))
                  .Returns(new List<Indicador>()); // Certifique-se de configurar corretamente o retorno

        // Act
        var result = controller.Objetivos();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var objetivos = Assert.IsType<List<Indicador>>(okResult.Value);
        Assert.NotNull(objetivos);
    }


    [Fact]
    public void Indicador_DeveRetornarOkComIndicador()
    {
        // Arrange
        var mockODSBUS = new Mock<IODSBUS>();
        var mockRepository = new Mock<IRepositoryBase>();
        var controller = new ODSController(mockODSBUS.Object, mockRepository.Object);

        var codigo = new Indicador { codigo = "3.1.1" };

        // Certifique-se de configurar o mock para retornar algo válido
        mockODSBUS.Setup(x => x.BuscarIndicador(It.IsAny<IRepositoryBase>(), It.IsAny<string>()))
                  .Returns(new List<Indicador>()); // Certifique-se de configurar corretamente o retorno

        // Act
        var result = controller.Indicador(codigo);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var indicadores = Assert.IsType<List<Indicador>>(okResult.Value);
        Assert.NotNull(indicadores);
    }


    [Fact]
    public void GetByRegiao_DeveRetornarOkComIndicadorPorRegiao()
    {
        // Arrange
        var mockODSBUS = new Mock<IODSBUS>();
        var mockRepository = new Mock<IRepositoryBase>();
        var controller = new ODSController(mockODSBUS.Object, mockRepository.Object);

        // Certifique-se de configurar o mock para retornar algo válido
        mockODSBUS.Setup(x => x.BuscarIndicadorPorRegiao(It.IsAny<IRepositoryBase>(), It.IsAny<Indicador>()))
                  .Returns(new List<Indicador>());

        var indicador = new Indicador { /* configurar propriedades necessárias */ };

        // Act
        var result = controller.GetByRegiao(indicador);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var indicadorPorRegiao = Assert.IsType<List<Indicador>>(okResult.Value);
        Assert.NotNull(indicadorPorRegiao);
    }

    [Fact]
    public void ObjetivosIndicadores_DeveRetornarOkComListaDeObjetivosIndicadores()
    {
        // Arrange
        var mockODSBUS = new Mock<IODSBUS>();
        var mockRepository = new Mock<IRepositoryBase>();
        var controller = new ODSController(mockODSBUS.Object, mockRepository.Object);

        // Certifique-se de configurar o mock para retornar algo válido
        mockODSBUS.Setup(x => x.BuscarObjetivosIndicadores(It.IsAny<IRepositoryBase>()))
                  .Returns(new List<ObjetivoIndicador>()); // Certifique-se de configurar corretamente o retorno

        // Act
        var result = controller.ObjetivosIndicadores();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var objetivosIndicadores = Assert.IsType<List<ObjetivoIndicador>>(okResult.Value);
        Assert.NotNull(objetivosIndicadores);
    }
}
