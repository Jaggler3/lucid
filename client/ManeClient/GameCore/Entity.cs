using Mane.Core;
using System;

namespace Mane.GameCore
{
    abstract class Entity : Renderable
    {
        public string Name = "Unnamed Entity";
        public abstract void Update();
    }
}
