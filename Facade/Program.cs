using System;

namespace Facade
{
    /**
    * Imagine a library of classes with a complex interface and/or complex 
    * interrelationships
    * 
    * Home Theater System
    * Amplifier, DvdPlayer, Projector, Screen, PopcornPopper and TheaterLights
    * each with its own interface and interclass dependencies
    * 
    * Imagine steps for “watch movie”
    * turn on popper, make popcorn, dim lights, screen down, projector on,
    * set projector to DVD, amplifier on, set amplifier to DVD, DVD on, etc.
    * Now imagine resetting everything after the movie is done, or configuring the 
    * system to play a CD, or play a video game, etc.
    */
    public class Program
    {
        static void Main(string[] args)
        {
            HomeTheaterSystem homeTheaterSystem = new HomeTheaterSystem(new Projector(), new DvdPlayer(), new Amplifier(), new PopcornPopper());
            homeTheaterSystem.WatchMovie("DUNE");
        }
    }

    public interface IAmplifier
    {
        public void DefaultVolume();
        public void VolumeUp(int amount);
        public void VolumeDown(int amount);
    }

    public interface IDvdPlayer
    {
        public void InsertDvd(string name);
    }
    public interface IProjector
    {
        public void TurnOn();
        public void DisplayVideo(string name);
    }
    public interface IPopcornPopper
    {
        public void MakePopcorn();
    }
    public class Amplifier : IAmplifier
    {
        private int Volume { get; set; } = 10;
        public void VolumeUp(int amount)
        {
            Volume = amount;
            Console.WriteLine($"Volume up by: {amount}");
        }
        public void VolumeDown(int amount)
        {
            Volume = amount;
            Console.WriteLine($"Volume down by: {amount}");
        }

        public void DefaultVolume()
        {
            Console.WriteLine($"Volume set to: {Volume}!");
        }
    }
    public class DvdPlayer : IDvdPlayer
    {
        public void InsertDvd(string name)
        {
            Console.WriteLine($"DVD inserted. Movie name: {name}");
        }
    }
    public class Projector : IProjector
    {
        public void TurnOn()
        {
            Console.WriteLine("Projector turned on.");
        }
        public void DisplayVideo(string name)
        {
            Console.WriteLine($"{name} projecting on the screen.");
        }
    }
    public class PopcornPopper : IPopcornPopper
    {
        public void MakePopcorn()
        {
            Console.WriteLine("Making popcorn.");
        }
    }
    public class HomeTheaterSystem
    {
        private readonly IProjector projector;
        private readonly IDvdPlayer dvdPlayer;
        private readonly IAmplifier amplifier;
        private readonly IPopcornPopper popcornPopper;

        public HomeTheaterSystem(IProjector projector, IDvdPlayer dvdPlayer, IAmplifier amplifier, IPopcornPopper popcornPopper)
        {
            this.projector = projector;
            this.dvdPlayer = dvdPlayer;
            this.amplifier = amplifier;
            this.popcornPopper = popcornPopper;
        }

        public void WatchMovie(string name)
        {
            popcornPopper.MakePopcorn();
            dvdPlayer.InsertDvd(name);
            amplifier.DefaultVolume();
            projector.TurnOn();
            projector.DisplayVideo(name);
        }

    }
}
