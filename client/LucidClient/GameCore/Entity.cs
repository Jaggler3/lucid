using Lucid.Core;
using System;

namespace Lucid.GameCore
{
    abstract class Entity : Renderable
    {
        public string Name = "Unnamed Entity";
        public abstract void Update();
    }
}
