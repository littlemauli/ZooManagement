using ZooManagement.Models.Database;
using System;
using System.Collections.Generic;


namespace ZooManagement.Models.Response
{
    public class ZookeeperResponse
    {
        // private readonly Zookeeper _zookeeper;

        // public ZookeeperResponse(Zookeeper zookeeper)
        // {
        //     _zookeeper = zookeeper;
        // }

        // public int Id => _zookeeper.Id;
        // public string ZookeeperName => _zookeeper.ZookeeperName;
        // public string ZookeeperSex => _zookeeper.ZookeeperSex;

        // public List<Enclosure> Enclosures =>_zookeeper.Enclosures;

        // public List<Animal> Animals =>_zookeeper.Animals;

        public int Id { get; set;}
        public string ZookeeperName { get; set;}
        public string ZookeeperSex { get; set;}

        public List<Enclosure> Enclosures { get; set;}

        public List<Animal> Animals { get; set;}

    }

}