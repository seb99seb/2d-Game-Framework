using System.Xml;
using System.Xml.Linq;

namespace Game_library
{
    /// <summary>
    /// The world, functions as a 2d map for the game to be played on - contains creatures and game objects
    /// </summary>
    public class World
    {
        /// <summary>
        /// List of all creatures existing in the world
        /// </summary>
        public List<Creature> CreatureList { get; set; }
        /// <summary>
        /// List of all world objects existing in the world
        /// </summary>
        public List<WorldObject> WorldObjectList { get; set; }
        /// <summary>
        /// Max x coordinate, world will span from 0 to this given value for x
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// Max y coordinate, world will span from 0 to this given value for y
        /// </summary>
        public int MaxY { get; set; }
        /// <summary>
        /// Constructor for world, will set the boundries for the map
        /// </summary>
        /// <param name="xMaxCoordinate">Decides the max x coordinate for the world</param>
        /// <param name="yMaxCoordinate">Decides the max y coordinate for the world</param>
        public World(int xMaxCoordinate, int yMaxCoordinate)
        {
            MaxX = xMaxCoordinate;
            MaxY = yMaxCoordinate;
            CreatureList = new List<Creature>();
            WorldObjectList = new List<WorldObject>();
        }
        public World()
        {
            string configPath = "..\\..\\..\\..\\..\\Game Library\\Game library\\Config.xml";
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException(configPath);
            }
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(configPath);
            XmlNode xNode = configDoc.DocumentElement.SelectSingleNode("xMaxCoordinate");
            XmlNode yNode = configDoc.DocumentElement.SelectSingleNode("yMaxCoordinate");

            MaxX = Convert.ToInt32(xNode.InnerText);
            MaxY = Convert.ToInt32(yNode.InnerText);
            CreatureList = new List<Creature>();
            WorldObjectList = new List<WorldObject>();
        }
        public List<Creature> FindEnemy(string creatureName)
        {
            var list = from creature in CreatureList
                                    where creature.Name.ToLower() == creatureName.ToLower()
                                    select creature;
            List<Creature> specificEnemyList = list.ToList();

            return specificEnemyList;
        }
    }
}