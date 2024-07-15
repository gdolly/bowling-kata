using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingKata.Tests;

public class GameOfLifeTest
{
    [Fact]
    public void ShouldStartWithFirstGenerationGrid()
    {
        var game = new GameOfLife(4, 8);
        Assert.Equal("........\n........\n........\n........", game.Show());
    }

    [Fact]
    public void ShouldStartWithSomeLivePopulation()
    {
        var livePopulation = new List<Tuple<int, int>> { new(1, 4), new(2, 3), new(2, 4) };


        var game = new GameOfLife(4, 8, livePopulation);
        Assert.Equal("........\n....*...\n...**...\n........", game.Show());
    }
    
    [Fact]
    public void ShouldKillLivePopulationWithFewerThan2LiveNeighbours()
    {
        var livePopulation = new List<Tuple<int, int>> { new(1, 4), new(2, 3)};
        var game = new GameOfLife(4, 8, livePopulation);
        Assert.Equal("........\n....*...\n...*....\n........", game.Show());
        game.NextGeneration();
        Assert.Equal("........\n........\n........\n........", game.Show());
    }
}