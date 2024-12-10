using CApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;

namespace CApp.Services;
public class CharityService
{
    //all the charties on the detail page
    private readonly static IEnumerable<Charitiee> _Charitiess = new List<Charitiee>
        {
            new Charitiee

                {
                    Namee = "Save the whales",
                    Pic = "whale.png",
                    Info = "Whales, the majestic giants of our oceans, are facing unprecedented threats. From climate change to illegal hunting, pollution to " +
                "habitat destruction, these magnificent creatures are on the brink of extinction. Donate today to help."
                },

            new Charitiee

                {
                    Namee = "Help the homeless",
                    Pic = "homeless.png",
                    Info = "In our community, too many people are living without the basic necessity of shelter. Homelessness remains a pressing issue affecting millions worldwide. "  

                },

            new Charitiee

                {
                    Namee = "Save a refugee",
                    Pic = "refugee.png",
                    Info = "Around the world, countless individuals are forced to flee their homes due to conflict, persecution, and disaster. " +
                "These refugees urgently need your help to find safety and rebuild their lives. "
                },

            new Charitiee

                {
                    Namee = "Donate to cancer trust",
                    Pic = "cancer.png",
                    Info = "Cancer affects millions worldwide, touching families and communities with its challenges." +
                " With your support, we can fund groundbreaking research for new treatments. "
                }
        };

    //getting all charities
    public IEnumerable<Charitiee> GetAllCharitiess() => _Charitiess;

    //getting charities filtered by the search
    //if nothing is written return all the charities
    // filtering charities by checking if the name matches the search term
    public IEnumerable<Charitiee> GetCharitiess(string SearchTerm) => string.IsNullOrWhiteSpace(SearchTerm)
        ? _Charitiess
        : _Charitiess.Where(p=> p.Namee.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));




}

