using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    /// <summary>
    ///     Abstract class for All onscreen objects
    /// </summary>
    public abstract class GameObject : IDrawable,  IMovable
    {
        public Coord TopLeft { get; set; }
        public char[,] Image { get; set; }
        public bool Alive { get; set; }
        public ObjectTypes ObjectType { get; set; }
        
        public GameObject()
        {
        }
        
        public GameObject(Coord topLeft, char[,] image,ObjectTypes objectType)
        {
            this.TopLeft = topLeft;
            this.Image = image;
            this.ObjectType = objectType;
        }


        virtual public void Move(Coord vector)
        {
            this.TopLeft += vector;
        }       

        public virtual void Update()
        {           
        }

        public ICollection<GameObject> ProduceObject(GameObject producedObject)
        {
            ICollection<GameObject> gameObjects = new List<GameObject>();
            gameObjects.Add(producedObject);
            return gameObjects;
        }
    }
}
