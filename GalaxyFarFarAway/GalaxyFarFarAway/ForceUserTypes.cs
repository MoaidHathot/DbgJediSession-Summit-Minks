using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFarFarAway
{
    public enum LightsaberType
    {
        Lightsaber,
        DoubleLightsaber,
        CrossgaurdLightsaber
    }

    [Serializable]
    public class ForceUserWeapon
    {
        public LightsaberType LightsaberType { get; }
        public ConsoleColor Color { get; }

        public ForceUserWeapon(LightsaberType lightsaberType, ConsoleColor color)
        {
            LightsaberType = lightsaberType;
            Color = color;
        }
    }

    public interface IForceUser
    {
        int MidiChlorians { get; }
        ForceUserWeapon Weapon { get; }

        void UseForce();
    }

    [Serializable]
    public class LifeForm
    {
        public string Name { get; }

        public LifeForm(string name)
        {
            Name = name;
        }

        //public override string ToString() => Name;

    }

    [Serializable]
    [DebuggerDisplay("Jedi {this.Name} with {this.MidiChlorians} MidiChlorians, fights with {Weapon.Color} {Weapon.LightsaberType}")]
    public class JediKnight : LifeForm, IForceUser
    {
        public int MidiChlorians { get; }
        public ForceUserWeapon Weapon { get; }

        public void UseForce()
        {
            Debug.WriteLine($"*** {Name} is using the force for helping others");
        }

        public JediKnight(string name, int midiChlorians, ForceUserWeapon weapon)
            : base(name)
        {
            MidiChlorians = midiChlorians;
            Weapon = weapon;
        }
    }

    [Serializable]
    [DebuggerTypeProxy(typeof(SithLordDisplay))]
    public class SithLord : LifeForm, IForceUser
    {
        public int MidiChlorians { get; }
        public ForceUserWeapon Weapon { get; }

        public void UseForce()
        {
            Debug.WriteLine($"*** {Name} is using the force for hurting others.");
        }

        public string[] Abilities { get; }

        public SithLord(string name, int midiChlorians, ForceUserWeapon weapon, params string[] abilities)
            : base(name)
        {
            MidiChlorians = midiChlorians;
            Weapon = weapon;
            Abilities = abilities;
        }

        class SithLordDisplay
        {
            private readonly SithLord _sithLord;

            public SithLordDisplay(SithLord sithLord) => _sithLord = sithLord;

            public string Name => _sithLord.Name;
            public int MidiChlorians => _sithLord.MidiChlorians;
            public LightsaberType LightsaberType => _sithLord.Weapon.LightsaberType;
            public ConsoleColor LightsaberColor => _sithLord.Weapon.Color;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public string[] Abilities => _sithLord.Abilities;
        }
    }
}
