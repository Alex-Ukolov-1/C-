using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public class Player : ICreature
    {
        CreatureCommand ICreature.Act(int x, int y)
        {
            var width = Game.MapWidth;
            var height = Game.MapHeight;
            var key = Game.KeyPressed;
            var deltaX = GetOffX(key);
            var deltaY = GetOffY(key);
            if (x + deltaX >= width || x + deltaX < 0)
                deltaX = 0;
            if (y + deltaY >= height || y + deltaY < 0)
                deltaY = 0;
            return new CreatureCommand()
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                TransformTo = this,
            };
        }

        int GetOffY(Keys key)
        {
            if (key == Keys.S || key == Keys.Down)
                return 1;
            else if (key == Keys.W || key == Keys.Up)
                return -1;
            else
                return 0;
        }

        int GetOffX(Keys key)
        {
            if (key == Keys.A || key == Keys.Left)
                return -1;
            else if (key == Keys.D || key == Keys.Right)
                return 1;
            else
                return 0;
        }

        bool ICreature.DeadInConflict(ICreature conflictedObject) //T0D0
        {
            return conflictedObject is Monster ||
            (conflictedObject is Sack && ((Sack)conflictedObject).State > 0) ? true : false;
        }

        int ICreature.GetDrawingPriority()
        {
            return 0;
        }

        string ICreature.GetImageFileName()
        {
            return "Digger.png";
        }
    }

    public class Terrain : ICreature
    {
        CreatureCommand ICreature.Act(int x, int y)
        {
            return new CreatureCommand()
            {
                DeltaX = 0,
                DeltaY = 0,
                TransformTo = this,
            };
        }

        bool ICreature.DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Player ? true : false;
        }

        int ICreature.GetDrawingPriority()
        {
            return 100;
        }

        string ICreature.GetImageFileName()
        {
            return "Terrain.png";
        }

    }

    public class Sack : ICreature
    {
        public int State = 0;

        CreatureCommand ICreature.Act(int x, int y)
        {
            ICreature transform = this;
            var deltaY = 0;
            if (y + 1 < Game.MapHeight && (Game.Map[x, y + 1] == null ||
                ((Game.Map[x, y + 1] is Player || Game.Map[x, y + 1] is Monster) && State != 0)))
                deltaY = 1;
            if (y + 1 < Game.MapHeight && Game.Map[x, y + 1] == null && State == 0)
                State = 1;
            else if ((State == 1 || State == 2) &&
                y + 1 < Game.MapHeight && Game.Map[x, y + 1] == null)
                State = 2;
            else if ((State == 2 || State == 1) &&
                y + 1 < Game.MapHeight && Game.Map[x, y + 1] != null)
                if (Game.Map[x, y + 1] is Player || Game.Map[x, y + 1] is Monster)
                    State = 2;
                else if (State == 2)
                    transform = new Gold();
                else
                    State = 0;
            else if (y + 1 == Game.MapHeight && State == 2)
                transform = new Gold();
            return GetCommand(0, deltaY, transform);
        }

        CreatureCommand GetCommand(int deltaX, int deltaY, ICreature transformTo)
        {
            return new CreatureCommand()
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                TransformTo = transformTo,
            };
        }

        bool ICreature.DeadInConflict(ICreature conflictedObject)
        {
            return State > 0 ? false : true;
        }

        int ICreature.GetDrawingPriority()
        {
            return 70;
        }

        string ICreature.GetImageFileName()
        {
            return "Sack.png";
        }
    }

    public class Gold : ICreature
    {
        CreatureCommand ICreature.Act(int x, int y)
        {
            return new CreatureCommand()
            {
                DeltaY = 0,
                DeltaX = 0,
                TransformTo = this,

            };
        }

        bool ICreature.DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Game.Scores += 10;
            return conflictedObject is Player || conflictedObject is Monster ? true : false;
        }

        int ICreature.GetDrawingPriority()
        {
            return 50;
        }

        string ICreature.GetImageFileName()
        {
            return "Gold.png";
        }
    }

    public class Monster : ICreature
    {
        CreatureCommand ICreature.Act(int x, int y)
        {
            var map = Game.Map;
            if (FindDigger() == null)
                return GetCommand(0, 0, this);
            var diggerX = FindDigger()[0];
            var diggerY = FindDigger()[1];
            if (diggerX > x && (map[x + 1, y] == null || map[x + 1, y] is Gold))
                return GetCommand(1, 0, this);
            if (diggerX > x && (map[x + 1, y] == null || map[x + 1, y] is Gold))
                return GetCommand(-1, 0, this);
            if (diggerX > x && (map[x + 1, y] == null || map[x + 1, y] is Gold))
                return GetCommand(0, 1, this);
            if (diggerX > x && (map[x + 1, y] == null || map[x + 1, y] is Gold))
                return GetCommand(0, -1, this);
            return GetCommand(0, 0, this);
        }
        CreatureCommand GetCommand(int deltaX, int deltaY, ICreature transformTo)
        {
            return new CreatureCommand()
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                TransformTo = transformTo,
            };
        }
        int[] FindDigger()
        {
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    if (Game.Map[x, y] is Player)
                        return new int[] { x, y };
            return null;
        }

        bool ICreature.DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Sack && ((Sack)conflictedObject).State > 0 ? true : false;
        }

        int ICreature.GetDrawingPriority()
        {
            return 5;
        }

        string ICreature.GetImageFileName()
        {
            return "Monster.png";
        }
    }
}