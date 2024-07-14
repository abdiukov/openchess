namespace Chess.UnitTests.Extensions;
using Chess.Core.Extensions;
using Chess.Core.Models;
using NUnit.Framework;

[TestFixture]
public class MappingExtensionsTests
{
    [Test]
    public void ToDomainMapsFenCorrectly()
    {
        var request = new ChessMoveRequest { Fen = "e5" };
        var result = request.ToDomain();
        Assert.That(result.Fen, Is.EqualTo("e5"));
    }

    [Test]
    public void ToDomainMapsMoveCorrectly()
    {
        var request = new ChessMoveRequest { Move = "Qf3" };
        var result = request.ToDomain();
        Assert.That(result.Move, Is.EqualTo("Qf3"));
    }

    [Test]
    public void ToResponseMapsFenCorrectly()
    {
        var domainModel = new ChessMoveDomainModel { Fen = "e5" };
        var result = domainModel.ToResponse();
        Assert.That(result.Fen, Is.EqualTo("e5"));
    }

    [Test]
    public void ToResponseMapsMoveCorrectly()
    {
        var domainModel = new ChessMoveDomainModel { Move = "Qf3" };
        var result = domainModel.ToResponse();
        Assert.That(result.Move, Is.EqualTo("Qf3"));
    }

    // Null object scenarios
    [Test]
    public void ToDomainThrowsWhenRequestIsNull()
    {
        ChessMoveRequest request = null;
        Assert.Throws<NullReferenceException>(() => request.ToDomain());
    }

    [Test]
    public void ToResponseThrowsWhenDomainModelIsNull()
    {
        ChessMoveDomainModel domainModel = null;
        Assert.Throws<NullReferenceException>(() => domainModel.ToResponse());
    }

    [Test]
    public void ToDomainMapsEmptyFenAndMoveCorrectly()
    {
        var request = new ChessMoveRequest { Fen = "", Move = "" };
        var result = request.ToDomain();
        Assert.Multiple(() =>
        {
            Assert.That(result.Fen, Is.EqualTo(""));
            Assert.That(result.Move, Is.EqualTo(""));
        });
    }

    [Test]
    public void ToResponseMapsEmptyFenAndMoveCorrectly()
    {
        var domainModel = new ChessMoveDomainModel { Fen = "", Move = "" };
        var result = domainModel.ToResponse();
        Assert.Multiple(() =>
        {
            Assert.That(result.Fen, Is.EqualTo(""));
            Assert.That(result.Move, Is.EqualTo(""));
        });
    }

    [Test]
    public void ToDomainHandlesOnlyMoveProvidedCorrectly()
    {
        var request = new ChessMoveRequest { Move = "Qf3" };
        var result = request.ToDomain();
        Assert.Multiple(() =>
        {
            Assert.That(result.Fen, Is.Null.Or.Empty);
            Assert.That(result.Move, Is.EqualTo("Qf3"));
        });
    }

    [Test]
    public void ToResponseHandlesOnlyFenProvidedCorrectly()
    {
        var domainModel = new ChessMoveDomainModel { Fen = "e5" };
        var result = domainModel.ToResponse();
        Assert.Multiple(() =>
        {
            Assert.That(result.Fen, Is.EqualTo("e5"));
            Assert.That(result.Move, Is.Null.Or.Empty);
        });
    }

    [Test]
    public void ToResponseHandlesOnlyMoveProvidedCorrectly()
    {
        var domainModel = new ChessMoveDomainModel { Move = "Qf3" };
        var result = domainModel.ToResponse();
        Assert.Multiple(() =>
        {
            Assert.That(result.Fen, Is.Null.Or.Empty);
            Assert.That(result.Move, Is.EqualTo("Qf3"));
        });
    }

}
