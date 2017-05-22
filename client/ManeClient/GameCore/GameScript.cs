using System;
using MoonSharp.Interpreter;
using Mane.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mane.SubSystems;
using Mane.Control;
using Mane.Foundation;

namespace Mane.GameCore
{
    class GameScript
    {

        public static void Initialize()
        {
            UserData.RegisterType<Vector2>();
            UserData.RegisterType<Entity>();
            UserData.RegisterType<Renderable>();
            UserData.RegisterType<GameObject>();
            UserData.RegisterType<Physics>();
            UserData.RegisterType<PhysicsObject>();
            UserData.RegisterType<Texture2D>();
            UserData.RegisterType<ScriptBindings.InputController>();
            UserData.RegisterType<ScriptBindings.Loader>();
            UserData.RegisterType<ScriptBindings.PhysicsController>();
            UserData.RegisterType<ScriptBindings.RenderingAccess>();
        }

        public static ScriptBindings.InputController input = new ScriptBindings.InputController();
        public static ScriptBindings.Loader loader = new ScriptBindings.Loader();
        public static ScriptBindings.PhysicsController physics = new ScriptBindings.PhysicsController();
        public static ScriptBindings.RenderingAccess renderingAccess = new ScriptBindings.RenderingAccess();

        public string Name;
        public string Path;

        public string Source;

        private Script _script;

        private Table maneObj;

        public GameObject Parent;

        public GameScript(GameObject Parent, string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
            this.Parent = Parent;
            Source = Utilities.LoadFile(Path);
            Load(Parent);
        }

        public GameScript(GameObject Parent, string Source)
        {
            this.Source = Source;
            this.Parent = Parent;
            Path = "(temp)";
            Name = "(temp)";

            Load(Parent);
        }

        private void Load(GameObject gameObject)
        {
            _script = new Script();
            
            //the game object
            SetGlobal("gameObject", gameObject);

            // Static method access classes
            SetGlobal("Input", input);
            SetGlobal("Loader", loader);
            SetGlobal("Physics", physics);
            SetGlobal("_UnitSize", GameData.UNIT_SIZE);
            SetGlobal("Rendering", renderingAccess);

            DynValue res = _script.DoString("ManeScript = {};" + Source + "return ManeScript;");
            maneObj = res.Table;
        }

        public void SetGlobal(string name, object value)
        {
            _script.Globals[name] = value;
        }

        public void Invoke(string MethodName)
        {
            DynValue func = maneObj.Get(MethodName);
            if(func != null && func.Type == DataType.Function)
            {
                func.Function.Call();
            }
        }
    }
}
